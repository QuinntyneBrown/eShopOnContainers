// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Integration.Events;

public abstract record IntegrationEvent: IPackable {

    public IntegrationEvent(GuidType id)
    {
        Id =  id;
    }
    public GuidType Id { get; set; }

    public void Pack(byte[] buffer, int index, int bitIndex)
    {
        Id.Pack(buffer, index, bitIndex);
    }
}

