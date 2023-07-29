// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Catalog.Core.CatalogItemAggregate;

public static class CatalogItemExtensions
{
    public static CatalogItemDto ToDto(this CatalogItem catalogItem)
    {
        return new CatalogItemDto
        {
            CatalogItemId = catalogItem.CatalogItemId,
            Name = catalogItem.Name,
            Description = catalogItem.Description,
            Price = catalogItem.Price,
            PictureFileName = catalogItem.PictureFileName,
            PictureUrl = catalogItem.PictureUrl,
            CatalogTypeId = catalogItem.CatalogTypeId,
            CatalogType = catalogItem.CatalogType,
            CatalogBrandId = catalogItem.CatalogBrandId,
            CatalogBrand = catalogItem.CatalogBrand,
            AvailableStock = catalogItem.AvailableStock,
            RestockThreshold = catalogItem.RestockThreshold,
            OnReorder = catalogItem.OnReorder,
        };

    }

    public async static Task<List<CatalogItemDto>> ToDtosAsync(this IQueryable<CatalogItem> catalogItems,CancellationToken cancellationToken)
    {
        return await catalogItems.Select(x => x.ToDto()).ToListAsync(cancellationToken);
    }

}


