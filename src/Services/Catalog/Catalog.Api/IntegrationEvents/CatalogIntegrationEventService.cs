// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Catalog.Api.IntegrationEvents;

public class CatalogIntegrationEventService: ICatalogIntegrationEventService
{
    private readonly ILogger<CatalogIntegrationEventService> _logger;
    private readonly IEventBus

    public CatalogIntegrationEventService(ILogger<CatalogIntegrationEventService> logger){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }


}


