// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Catalog.Core.CatalogItemAggregate;
using System;

namespace Catalog.Core;

public interface ICatalogDbContext { 

    DbSet<CatalogItem> CatalogItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}

