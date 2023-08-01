// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using IO.Compression;
using IO.Compression.Primitives;
using Microsoft.Extensions.Logging;
using System.Buffers.Binary;
using System.Net.Sockets;
using System.Reactive.Linq;


namespace EventBus.Udp;

public class EventBus: IEventBus
{
    private readonly ILogger<EventBus> _logger;
    private static readonly Observable<byte[]> _observableBuffer = new();
    private UdpClient _udpClient;

    public EventBus(ILogger<EventBus> logger, IUdpClientFactory clientFactory){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _udpClient = clientFactory.Create();
    }

    public async Task PublishAsync(EventBusMessage @event)
    {        
        _logger.LogInformation("Publishing event. {0}", @event.Id);

        byte[] buffer = new byte[(@event.SizeInBits + 7) / 8];

        @event.Pack(buffer, 0, 7);

        await _udpClient.SendAsync(buffer, buffer.Length, UdpClientFactory.MultiCastGroupIp, UdpClientFactory.BroadcastPort);
    }

    public void Subscribe(List<(GuidType id, Func<byte[], object> factory)> r, Action<object> onNext)
    {
        _observableBuffer
            .Where(x => Where(r,x))
            .Select(x => Select(r,x))
            .Subscribe(onNext);

        bool Where(List<(GuidType id, Func<byte[], object> factory)> r, byte[] buffer)
        {
            var messageHeader = new MessageHeader(BitVector8.Unpack(buffer, 144));

            return r.Select(x => x.id).Contains(messageHeader.Id);
        }

        object Select(List<(GuidType id, Func<byte[], object> factory)> r, byte[] buffer)
        {
            var messageHeader = new MessageHeader(BitVector8.Unpack(buffer, 144));

            Span<byte> input = stackalloc byte[2];

            int payloadSizeInBits = messageHeader.PayloadSizeInBits;

            var payload = BitVector8.Unpack(buffer, payloadSizeInBits, 18);

            return r.Single(x => x.id == messageHeader.Id).factory(payload);
        }
    }


    public async Task StartAsync(CancellationToken cancellationToken = default)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            var result = await _udpClient.ReceiveAsync(cancellationToken);

            _observableBuffer.Broadcast(result.Buffer);
        }
    }
}


