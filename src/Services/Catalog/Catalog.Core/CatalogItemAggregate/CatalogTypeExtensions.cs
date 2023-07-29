// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Catalog.Core.CatalogItemAggregate;

public static class CatalogTypeExtensions
{
    public static CatalogTypeDto ToDto(this CatalogType catalogType)
    {
        return new CatalogTypeDto
        {
            CatalogTypeId = catalogType.CatalogTypeId,
            Type = catalogType.Type,
        };

    }

    public async static Task<List<CatalogTypeDto>> ToDtosAsync(this IQueryable<CatalogType> catalogTypes,CancellationToken cancellationToken)
    {
        return await catalogTypes.Select(x => x.ToDto()).ToListAsync(cancellationToken);
    }

}


