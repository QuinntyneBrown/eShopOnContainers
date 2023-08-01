// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using IO.Compression.Primitives;

namespace EventBus.Udp;

public interface IEventBus
{
    Task PublishAsync(EventBusMessage @event);

    Task StartAsync(CancellationToken cancellationToken = default);

    void Subscribe(List<(GuidType id, Func<byte[], object> factory)> r, Action<object> onNext);

}


