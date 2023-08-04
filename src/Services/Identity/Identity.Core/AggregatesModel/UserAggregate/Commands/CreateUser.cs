// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Identity.Core.AggregatesModel.UserAggregate.Commands;

public class CreateUserRequestValidator: AbstractValidator<CreateUserRequest>
{
    public CreateUserRequestValidator(){

        RuleFor(x => x.Username).NotNull();
        RuleFor(x => x.Password).NotNull();
        RuleFor(x => x.Salt).NotNull();

    }

}


public class CreateUserRequest: IRequest<CreateUserResponse>
{
    public string Username { get; set; }
    public string Password { get; set; }
    public byte[] Salt { get; set; }
}


public class CreateUserResponse
{
    public required UserDto User { get; set; }
}


public class CreateUserRequestHandler: IRequestHandler<CreateUserRequest,CreateUserResponse>
{
    private readonly IIdentityDbContext _context;

    private readonly ILogger<CreateUserRequestHandler> _logger;

    public CreateUserRequestHandler(ILogger<CreateUserRequestHandler> logger,IIdentityDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<CreateUserResponse> Handle(CreateUserRequest request,CancellationToken cancellationToken)
    {
        var user = new User();

        _context.Users.Add(user);

        user.Username = request.Username;
        user.Password = request.Password;
        user.Salt = request.Salt;

        await _context.SaveChangesAsync(cancellationToken);

        return new ()
        {
            User = user.ToDto()
        };

    }

}



