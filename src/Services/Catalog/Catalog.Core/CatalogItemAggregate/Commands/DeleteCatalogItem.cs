// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Catalog.Core.CatalogItemAggregate.Commands;

public class DeleteCatalogItemRequestValidator: AbstractValidator<DeleteCatalogItemRequest>
{
    public DeleteCatalogItemRequestValidator(){

        RuleFor(x => x.CatalogItemId).NotEqual(default(Guid));

    }

}


public class DeleteCatalogItemRequest: IRequest<DeleteCatalogItemResponse>
{
    public Guid CatalogItemId { get; set; }
}


public class DeleteCatalogItemResponse
{
    public required CatalogItemDto CatalogItem { get; set; }
}


public class DeleteCatalogItemRequestHandler: IRequestHandler<DeleteCatalogItemRequest,DeleteCatalogItemResponse>
{
    private readonly ICatalogDbContext _context;

    private readonly ILogger<DeleteCatalogItemRequestHandler> _logger;

    public DeleteCatalogItemRequestHandler(ILogger<DeleteCatalogItemRequestHandler> logger,ICatalogDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<DeleteCatalogItemResponse> Handle(DeleteCatalogItemRequest request,CancellationToken cancellationToken)
    {
        var catalogItem = await _context.CatalogItems.FindAsync(request.CatalogItemId);

        _context.CatalogItems.Remove(catalogItem);

        await _context.SaveChangesAsync(cancellationToken);

        return new ()
        {
            CatalogItem = catalogItem.ToDto()
        };
    }

}



