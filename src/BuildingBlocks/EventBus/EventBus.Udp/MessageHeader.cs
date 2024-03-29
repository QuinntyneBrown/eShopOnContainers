// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using StreamProcessing;
using StreamProcessing.Primitives;

namespace EventBus.Udp;

public struct MessageHeader : ICodable
{
    public MessageHeader(byte[] buffer)
    {
        Id = new GuidType(BinaryDecoder.Decode(buffer, 128, 0, 0));
        PayloadSizeInBits = new Int16Type(BinaryDecoder.Decode(buffer, 16, 16, 0));
    }

    public Int16Type SizeInBits => (Int16Type)144;

    public GuidType Id { get; init; }

    public Int16Type PayloadSizeInBits { get; init; }

    public void Encode(Span<byte> buffer, int index = 0, int bitIndex = 7)
    {
        Id.Encode(buffer, index, bitIndex);
        PayloadSizeInBits.Encode(buffer, index + 16, bitIndex);
    }
}

