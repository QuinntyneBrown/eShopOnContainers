// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Integration;
using Integration.Events;
using SharedKernel;
using Microsoft.Extensions.Logging;
using System.Net.Sockets;
using System.Reactive.Linq;
using SharedKernel.Serialization;

namespace EventBus.Udp;

public class EventBus: IEventBus
{
    private readonly ILogger<EventBus> _logger;
    private static readonly Observable<byte[]> _observableBuffer = new();
    private UdpClient _sender;
    private UdpClient _receiver;

    public EventBus(ILogger<EventBus> logger, IUdpClientFactory clientFactory){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _sender = new UdpClient();
        _receiver = clientFactory.Create();
    }

    public async Task PublishAsync(IntegrationEvent @event)
    {        
        _logger.LogInformation("Publishing event. {0}", @event.Id);

        byte[] buffer = new byte[40];

        @event.Pack(buffer, 0, 0);

        await _sender.SendAsync(buffer, UdpClientFactory.MultiCastGroupIp, UdpClientFactory.BroadcastPort);
    }

    public void Subscribe(GuidType guid, Action<byte[]> onNext)
    {
/*        _observableBuffer
            .Where(x => new GuidType(BitVector8.Unpack(x, 32)) == guid)
            .Subscribe(onNext);*/
    }

    public async Task StartAsync(CancellationToken cancellationToken = default)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            var result = await _receiver.ReceiveAsync(cancellationToken);

            _observableBuffer.Broadcast(result.Buffer);
        }
    }
}


