// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Identity.Core.AggregatesModel.UserAggregate.Commands;

public class UpdateUserRequestValidator: AbstractValidator<UpdateUserRequest>
{
    public UpdateUserRequestValidator(){

        RuleFor(x => x.UserId).NotEqual(default(Guid));
        RuleFor(x => x.Username).NotNull();
        RuleFor(x => x.Password).NotNull();
        RuleFor(x => x.Salt).NotNull();

    }

}


public class UpdateUserRequest: IRequest<UpdateUserResponse>
{
    public Guid UserId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public byte[] Salt { get; set; }
}


public class UpdateUserResponse
{
    public required UserDto User { get; set; }
}


public class UpdateUserRequestHandler: IRequestHandler<UpdateUserRequest,UpdateUserResponse>
{
    private readonly IIdentityDbContext _context;

    private readonly ILogger<UpdateUserRequestHandler> _logger;

    public UpdateUserRequestHandler(ILogger<UpdateUserRequestHandler> logger,IIdentityDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<UpdateUserResponse> Handle(UpdateUserRequest request,CancellationToken cancellationToken)
    {
        var user = await _context.Users.SingleAsync(x => x.UserId == request.UserId);

        user.UserId = request.UserId;
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



