// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Catalog.Core;
using Catalog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static void AddInfrastructureServices(this IServiceCollection services, string connectionString)
    {

        services.AddScoped<ICatalogDbContext, CatalogDbContext>();
        services.AddDbContextPool<CatalogDbContext>(options =>
        {
            options.UseSqlServer(connectionString, builder => builder.MigrationsAssembly("Catalog.Infrastructure"))
            .EnableThreadSafetyChecks(false);
        });
    }
}
