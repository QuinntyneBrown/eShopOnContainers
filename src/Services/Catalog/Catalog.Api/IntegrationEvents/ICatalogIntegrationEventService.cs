// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Integration.Events;

namespace Catalog.Api.IntegrationEvents;

public interface ICatalogIntegrationEventService
{
    Task SaveEventAndCatalogContextChangesAsync(IntegrationEvent evt);
    Task PublishThroughEventBusAsync(IntegrationEvent evt);

}


