// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Catalog.Core.CatalogItemAggregate;

public static class CatalogBrandExtensions
{
    public static CatalogBrandDto ToDto(this CatalogBrand catalogBrand)
    {
        return new CatalogBrandDto
        {
            CatalogBrandId = catalogBrand.CatalogBrandId,
            Brand = catalogBrand.Brand
        };

    }

    public async static Task<List<CatalogBrandDto>> ToDtosAsync(this IQueryable<CatalogBrand> catalogBrands,CancellationToken cancellationToken)
    {
        return await catalogBrands.Select(x => x.ToDto()).ToListAsync(cancellationToken);
    }

}


