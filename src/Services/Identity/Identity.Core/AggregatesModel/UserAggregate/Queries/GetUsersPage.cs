// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Identity.Core.AggregatesModel.UserAggregate.Queries;

public class GetUsersPageRequest: IRequest<GetUsersPageResponse>
{
    public int PageSize { get; set; }
    public int Index { get; set; }
    public int Length { get; set; }
}


public class GetUsersPageResponse
{
    public required int Length { get; set; }
    public required List<UserDto> Entities  { get; set; }
}


public class CreateUserRequestHandler: IRequestHandler<GetUsersPageRequest,GetUsersPageResponse>
{
    private readonly IIdentityDbContext _context;

    private readonly ILogger<CreateUserRequestHandler> _logger;

    public CreateUserRequestHandler(ILogger<CreateUserRequestHandler> logger,IIdentityDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<GetUsersPageResponse> Handle(GetUsersPageRequest request,CancellationToken cancellationToken)
    {
        var query = from user in _context.Users
            select user;

        var length = await _context.Users.AsNoTracking().CountAsync();

        var users = await query.Page(request.Index, request.PageSize).AsNoTracking()
            .Select(x => x.ToDto()).ToListAsync();

        return new ()
        {
            Length = length,
            Entities = users
        };

    }

}



