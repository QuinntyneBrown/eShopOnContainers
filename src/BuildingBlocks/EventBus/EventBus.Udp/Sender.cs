// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Extensions.Logging;
using System.Net.Sockets;

namespace EventBus.Udp;

public class Sender: ISender
{
    private readonly ILogger<Sender> _logger;
    private readonly UdpClient _udpClient;

    public Sender(ILogger<Sender> logger, IUdpClientFactory udpClientFactory){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _udpClient = udpClientFactory.Create();
    }

    public async Task SendAsync()
    {
        await _udpClient.SendAsync(new byte[1], 1, UdpClientFactory.MultiCastGroupIp, UdpClientFactory.BroadcastPort);
    }

}


