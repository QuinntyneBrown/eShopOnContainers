// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using SharedKernel;
using SharedKernel.Serialization;

namespace Integration.Events;

public abstract record IntegrationEvent: IBitPackable {

    public IntegrationEvent(GuidType id)
    {
        Id =  id;
    }
    public GuidType Id { get; set; } 

    public abstract (int value, int numberOfBits)[] ToDescriptors();
}

