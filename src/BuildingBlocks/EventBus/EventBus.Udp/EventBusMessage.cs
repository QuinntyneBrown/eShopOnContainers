// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using IO.Compression;
using IO.Compression.Primitives;

namespace EventBus.Udp;

public class EventBusMessage: IPackable {

    public EventBusMessage(GuidType id, IPackable body)
    {
        Span<byte> buffer = stackalloc byte[body.SizeInBits + 7 / 8];

        body.Pack(buffer, 0, 0);
    }

    public GuidType Id { get; set; }
    public byte[] Body { get; set; }

    public int SizeInBits { get; set; }

    public byte[] Pack()
    {
        throw new NotImplementedException();
    }

    public void Pack(Span<byte> buffer, int index, int bitIndex)
    {
        throw new NotImplementedException();
    }
}

