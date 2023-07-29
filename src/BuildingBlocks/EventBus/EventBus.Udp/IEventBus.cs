// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Integration.Events;
using Integration.Types;

namespace EventBus.Udp;

public interface IEventBus
{
    Task PublishAsync(IntegrationEvent @event);

    Task StartAsync(CancellationToken cancellationToken = default);

    void Subscribe(GuidType guid, Action<byte[]> onNext);

}


