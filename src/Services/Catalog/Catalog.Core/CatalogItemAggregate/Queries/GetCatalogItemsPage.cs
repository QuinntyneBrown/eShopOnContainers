// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Catalog.Core.CatalogItemAggregate.Queries;

public class GetCatalogItemsPageRequest: IRequest<GetCatalogItemsPageResponse>
{
    public int PageSize { get; set; }
    public int Index { get; set; }
    public int Length { get; set; }
}


public class GetCatalogItemsPageResponse
{
    public required int Length { get; set; }
    public required List<CatalogItemDto> Entities  { get; set; }
}


public class CreateCatalogItemRequestHandler: IRequestHandler<GetCatalogItemsPageRequest,GetCatalogItemsPageResponse>
{
    private readonly ICatalogDbContext _context;

    private readonly ILogger<CreateCatalogItemRequestHandler> _logger;

    public CreateCatalogItemRequestHandler(ILogger<CreateCatalogItemRequestHandler> logger,ICatalogDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<GetCatalogItemsPageResponse> Handle(GetCatalogItemsPageRequest request,CancellationToken cancellationToken)
    {
        var query = from catalogItem in _context.CatalogItems
            select catalogItem;

        var length = await _context.CatalogItems.AsNoTracking().CountAsync();

        var catalogItems = await query.Page(request.Index, request.PageSize).AsNoTracking()
            .Select(x => x.ToDto()).ToListAsync();

        return new ()
        {
            Length = length,
            Entities = catalogItems
        };

    }

}



