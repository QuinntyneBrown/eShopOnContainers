// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Basket.Core.AggregatesModel.BasketItemAggregate;

public static class BasketItemExtensions
{
    public static BasketItemDto ToDto(this BasketItem basketItem)
    {
        return new BasketItemDto
        {
            BasketItemId = basketItem.BasketItemId,
            ProductId = basketItem.ProductId,
            ProductName = basketItem.ProductName,
            UnitPrice = basketItem.UnitPrice,
            OldUnitPrice = basketItem.OldUnitPrice,
            Quantity = basketItem.Quantity,
            PictureUrl = basketItem.PictureUrl,
        };

    }

    public async static Task<List<BasketItemDto>> ToDtosAsync(this IQueryable<BasketItem> basketItems,CancellationToken cancellationToken)
    {
        return await basketItems.Select(x => x.ToDto()).ToListAsync(cancellationToken);
    }

}


