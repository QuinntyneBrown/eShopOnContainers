// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Catalog.Core;
using Catalog.Core.CatalogItemAggregate;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure.Data;

public class CatalogDbContext: DbContext,ICatalogDbContext
{
    public CatalogDbContext(DbContextOptions<CatalogDbContext> options)    
        : base(options)
    {
    }

    public DbSet<CatalogItem> CatalogItems { get; private set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Catalog");

        base.OnModelCreating(modelBuilder);

    }

}


