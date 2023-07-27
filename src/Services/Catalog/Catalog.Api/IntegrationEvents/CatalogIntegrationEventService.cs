// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using EventBus.Udp;
using Integration.Events;

namespace Catalog.Api.IntegrationEvents;

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

    public Task PublishThroughEventBusAsync(IntegrationEvent evt)
    {
        throw new NotImplementedException();
    }

    public Task SaveEventAndCatalogContextChangesAsync(IntegrationEvent evt)
    {
        throw new NotImplementedException();
    }
}


