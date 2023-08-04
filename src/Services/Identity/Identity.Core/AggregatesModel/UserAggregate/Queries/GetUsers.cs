// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Identity.Core.AggregatesModel.UserAggregate.Queries;

public class GetUsersRequest: IRequest<GetUsersResponse> { }

public class GetUsersResponse
{
    public required List<UserDto> Users { get; set; }
}


public class GetUsersRequestHandler: IRequestHandler<GetUsersRequest,GetUsersResponse>
{
    private readonly IIdentityDbContext _context;

    private readonly ILogger<GetUsersRequestHandler> _logger;

    public GetUsersRequestHandler(ILogger<GetUsersRequestHandler> logger,IIdentityDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<GetUsersResponse> Handle(GetUsersRequest request,CancellationToken cancellationToken)
    {
        return new () {
            Users = await _context.Users.AsNoTracking().ToDtosAsync(cancellationToken)
        };

    }

}



