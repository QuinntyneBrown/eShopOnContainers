// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using IO.Compression;
using IO.Compression.Primitives;

namespace EventBus.Udp;

public class EventBusMessage: IPackable {

    public EventBusMessage(GuidType id, IPackable payload)
    {
        MessageHeader = new MessageHeader
        {
            Id = id,
            PayloadSizeInBits = payload.SizeInBits
        };

        Body = new byte[(payload.SizeInBits + 7) / 8];

        payload.Pack(Body);

        SizeInBits = (Int16Type)(MessageHeader.SizeInBits + payload.SizeInBits);
    }
    public MessageHeader MessageHeader { get; }
    public GuidType Id { get; set; }
    
    public byte[] Body { get; set; }

    public Int16Type SizeInBits { get; private set; }

    public void Pack(Span<byte> buffer, int index, int bitIndex)
    {
        MessageHeader.Pack(buffer, 0, bitIndex);

        BitVector8.Pack(Body, MessageHeader.PayloadSizeInBits, buffer, 18, bitIndex);
    }
}

