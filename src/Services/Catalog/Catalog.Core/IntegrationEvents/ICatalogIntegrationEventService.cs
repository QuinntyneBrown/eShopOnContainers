// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using EventBus.Udp;

namespace Catalog.Core.IntegrationEvents;

public interface ICatalogIntegrationEventService
{
    Task SaveEventAndCatalogContextChangesAsync(EventBusMessage evt);
    Task PublishThroughEventBusAsync(EventBusMessage evt);

}


