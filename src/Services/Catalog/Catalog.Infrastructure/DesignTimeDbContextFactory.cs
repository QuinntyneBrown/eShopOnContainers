// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Catalog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CatalogDbContext>
{
    public CatalogDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<CatalogDbContext>();

        var basePath = Path.GetFullPath("../Catalog.Api");

        var configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", false)
            .Build();

        var connectionString = configuration.GetConnectionString("DefualtConnection");

        builder.UseSqlServer(connectionString);

        return new CatalogDbContext(builder.Options);
    }
}
