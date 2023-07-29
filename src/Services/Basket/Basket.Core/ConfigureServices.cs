// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Basket.Core;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static void AddCoreServices(this IServiceCollection services)
    { 
        services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblyContaining<IBasketDbContext>());
        services.AddValidatorsFromAssemblyContaining<IBasketDbContext>();
    }
}
