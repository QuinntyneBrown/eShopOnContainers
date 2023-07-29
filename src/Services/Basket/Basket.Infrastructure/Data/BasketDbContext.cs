// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Basket.Core;
using Microsoft.EntityFrameworkCore;
using Basket.Core.AggregatesModel.BasketItemAggregate;

namespace Basket.Infrastructure.Data;

public class BasketDbContext: DbContext,IBasketDbContext
{
    public BasketDbContext(DbContextOptions<BasketDbContext> options)    : base(options)
    {
    }

    public DbSet<BasketItem> BasketItems { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Basket");

        base.OnModelCreating(modelBuilder);

    }

}


