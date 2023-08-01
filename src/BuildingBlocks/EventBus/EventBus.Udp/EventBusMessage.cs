// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using IO.Compression;
using IO.Compression.Primitives;

namespace EventBus.Udp;

public class EventBusMessage: IPackable {

    public GuidType Id { get; set; }
    public byte[] Body { get; set; }

    public byte[] Pack()
    {
        throw new NotImplementedException();
    }

    public void Pack(byte[] buffer, int index, int bitIndex)
    {
        throw new NotImplementedException();
    }
}

