// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Integration.Events;
using Microsoft.Extensions.Logging;

namespace EventBus.Udp;

public class EventBus: IEventBus
{
    private readonly ILogger<EventBus> _logger;

    public EventBus(ILogger<EventBus> logger){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public void Publish(IntegrationEvent @event)
    {
        throw new NotImplementedException();
    }
}


