// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Catalog.Core.CatalogItemAggregate.Queries;

public class GetCatalogItemByIdRequest: IRequest<GetCatalogItemByIdResponse>
{
    public Guid CatalogItemId { get; set; }
}


public class GetCatalogItemByIdResponse
{
    public required CatalogItemDto CatalogItem { get; set; }
}


public class GetCatalogItemByIdRequestHandler: IRequestHandler<GetCatalogItemByIdRequest,GetCatalogItemByIdResponse>
{
    private readonly ICatalogDbContext _context;

    private readonly ILogger<GetCatalogItemByIdRequestHandler> _logger;

    public GetCatalogItemByIdRequestHandler(ILogger<GetCatalogItemByIdRequestHandler> logger,ICatalogDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<GetCatalogItemByIdResponse> Handle(GetCatalogItemByIdRequest request,CancellationToken cancellationToken)
    {
        return new () {
            CatalogItem = (await _context.CatalogItems.AsNoTracking().SingleOrDefaultAsync(x => x.CatalogItemId == request.CatalogItemId)).ToDto()
        };

    }

}



