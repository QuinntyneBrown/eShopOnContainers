// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using StreamProcessing;
using StreamProcessing.Primitives;

namespace EventBus.Udp;

public class EventBusMessage: ICodable {

    public EventBusMessage(GuidType id, ICodable payload)
    {
        MessageHeader = new MessageHeader
        {
            Id = id,
            PayloadSizeInBits = payload.SizeInBits
        };

        Body = new byte[(payload.SizeInBits + 7) / 8];

        payload.Encode(Body);

        SizeInBits = (Int16Type)(MessageHeader.SizeInBits + payload.SizeInBits);
    }
    public MessageHeader MessageHeader { get; }
    public GuidType Id { get; set; }
    
    public byte[] Body { get; set; }

    public Int16Type SizeInBits { get; private set; }

    public void Encode(Span<byte> buffer, int index, int bitIndex)
    {
        MessageHeader.Encode(buffer, 0, bitIndex);

        BinaryEncoder.Encode(Body, MessageHeader.PayloadSizeInBits, buffer, 18, bitIndex);
    }
}

