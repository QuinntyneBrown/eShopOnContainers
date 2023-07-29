// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Basket.Core;
using Basket.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static void AddInfrastructureServices(this IServiceCollection services, string connectionString)
    {

        services.AddScoped<IBasketDbContext, BasketDbContext>();
        services.AddDbContextPool<BasketDbContext>(options =>
        {
            options.UseSqlServer(connectionString, builder => builder.MigrationsAssembly("Basket.Infrastructure"))
            .EnableThreadSafetyChecks(false);
        });
    }
}
