// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using EventBus.Udp;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static void AddUdpServices(this IServiceCollection services)
    {

        services.AddSingleton<IUdpClientFactory, UdpClientFactory>();
        services.AddSingleton<IEventBus, EventBus.Udp.EventBus>();
    }

}


