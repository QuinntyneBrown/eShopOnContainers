// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Catalog.Core.CatalogItemAggregate.Commands;

public class CreateCatalogItemRequestValidator: AbstractValidator<CreateCatalogItemRequest>
{
    public CreateCatalogItemRequestValidator(){

        RuleFor(x => x.Name).NotNull();
        RuleFor(x => x.Description).NotNull();
        RuleFor(x => x.Price).NotNull();
        RuleFor(x => x.PictureFileName).NotNull();
        RuleFor(x => x.PictureUrl).NotNull();
        RuleFor(x => x.CatalogTypeId).NotEqual(default(Guid));
        RuleFor(x => x.CatalogType).NotNull();
        RuleFor(x => x.CatalogBrandId).NotEqual(default(Guid));
        RuleFor(x => x.CatalogBrand).NotNull();
        RuleFor(x => x.AvailableStock).NotNull();
        RuleFor(x => x.RestockThreshold).NotNull();
        RuleFor(x => x.OnReorder).NotNull();

    }

}


public class CreateCatalogItemRequest: IRequest<CreateCatalogItemResponse>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public string PictureFileName { get; set; }
    public string PictureUrl { get; set; }
    public Guid CatalogTypeId { get; set; }
    public CatalogType CatalogType { get; set; }
    public Guid CatalogBrandId { get; set; }
    public CatalogBrand CatalogBrand { get; set; }
    public int AvailableStock { get; set; }
    public int RestockThreshold { get; set; }
    public bool OnReorder { get; set; }
}


public class CreateCatalogItemResponse
{
    public required CatalogItemDto CatalogItem { get; set; }
}


public class CreateCatalogItemRequestHandler: IRequestHandler<CreateCatalogItemRequest,CreateCatalogItemResponse>
{
    private readonly ICatalogDbContext _context;

    private readonly ILogger<CreateCatalogItemRequestHandler> _logger;

    public CreateCatalogItemRequestHandler(ILogger<CreateCatalogItemRequestHandler> logger,ICatalogDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<CreateCatalogItemResponse> Handle(CreateCatalogItemRequest request,CancellationToken cancellationToken)
    {
        var catalogItem = new CatalogItem();

        _context.CatalogItems.Add(catalogItem);

        catalogItem.Name = request.Name;
        catalogItem.Description = request.Description;
        catalogItem.Price = request.Price;
        catalogItem.PictureFileName = request.PictureFileName;
        catalogItem.PictureUrl = request.PictureUrl;
        catalogItem.CatalogTypeId = request.CatalogTypeId;
        catalogItem.CatalogType = request.CatalogType;
        catalogItem.CatalogBrandId = request.CatalogBrandId;
        catalogItem.CatalogBrand = request.CatalogBrand;
        catalogItem.AvailableStock = request.AvailableStock;
        catalogItem.RestockThreshold = request.RestockThreshold;
        catalogItem.OnReorder = request.OnReorder;

        await _context.SaveChangesAsync(cancellationToken);

        return new ()
        {
            CatalogItem = catalogItem.ToDto()
        };

    }

}



