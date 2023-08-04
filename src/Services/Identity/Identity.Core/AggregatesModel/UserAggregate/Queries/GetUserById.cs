// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Identity.Core.AggregatesModel.UserAggregate.Queries;

public class GetUserByIdRequest: IRequest<GetUserByIdResponse>
{
    public Guid UserId { get; set; }
}


public class GetUserByIdResponse
{
    public required UserDto User { get; set; }
}


public class GetUserByIdRequestHandler: IRequestHandler<GetUserByIdRequest,GetUserByIdResponse>
{
    private readonly IIdentityDbContext _context;

    private readonly ILogger<GetUserByIdRequestHandler> _logger;

    public GetUserByIdRequestHandler(ILogger<GetUserByIdRequestHandler> logger,IIdentityDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<GetUserByIdResponse> Handle(GetUserByIdRequest request,CancellationToken cancellationToken)
    {
        return new () {
            User = (await _context.Users.AsNoTracking().SingleOrDefaultAsync(x => x.UserId == request.UserId)).ToDto()
        };

    }

}



