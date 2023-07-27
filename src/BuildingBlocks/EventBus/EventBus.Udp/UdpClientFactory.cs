// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace EventBus.Udp;

public class UdpClientFactory: IUdpClientFactory
{
    private readonly ILogger<UdpClientFactory> _logger;

    public UdpClientFactory(ILogger<UdpClientFactory> logger){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task DoWorkAsync()
    {
        _logger.LogInformation("DoWorkAsync");
    }

}


