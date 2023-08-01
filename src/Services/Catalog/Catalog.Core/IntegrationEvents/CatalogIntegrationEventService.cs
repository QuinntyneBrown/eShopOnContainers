// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using EventBus.Udp;

namespace Catalog.Core.IntegrationEvents;

public class CatalogIntegrationEventService: ICatalogIntegrationEventService
{
    private readonly ILogger<CatalogIntegrationEventService> _logger;
    private readonly IEventBus _eventBus;

    public CatalogIntegrationEventService(
        ILogger<CatalogIntegrationEventService> logger,
        IEventBus eventBus
        ){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
    }

    public async Task PublishThroughEventBusAsync(EventBusMessage evt)
    {
        _logger.LogInformation("PublishThroughEventBusAsync");

        await _eventBus.PublishAsync(evt);
    }

    public Task SaveEventAndCatalogContextChangesAsync(EventBusMessage evt)
    {
        throw new NotImplementedException();
    }
}