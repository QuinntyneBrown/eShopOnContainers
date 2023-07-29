// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Basket.Core.AggregatesModel.BasketItemAggregate;

namespace Basket.Core;

public interface IBasketDbContext
{
    DbSet<BasketItem> BasketItems { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

}


