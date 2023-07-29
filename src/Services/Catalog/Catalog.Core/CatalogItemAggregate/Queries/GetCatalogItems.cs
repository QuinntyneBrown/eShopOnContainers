// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Catalog.Core.CatalogItemAggregate.Queries;

public class GetCatalogItemsRequest: IRequest<GetCatalogItemsResponse> { }

public class GetCatalogItemsResponse
{
    public required List<CatalogItemDto> CatalogItems { get; set; }
}


public class GetCatalogItemsRequestHandler: IRequestHandler<GetCatalogItemsRequest,GetCatalogItemsResponse>
{
    private readonly ICatalogDbContext _context;

    private readonly ILogger<GetCatalogItemsRequestHandler> _logger;

    public GetCatalogItemsRequestHandler(ILogger<GetCatalogItemsRequestHandler> logger,ICatalogDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<GetCatalogItemsResponse> Handle(GetCatalogItemsRequest request,CancellationToken cancellationToken)
    {
        return new () {
            CatalogItems = await _context.CatalogItems.AsNoTracking().ToDtosAsync(cancellationToken)
        };

    }

}



