// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using EventBus.Udp;
using StreamProcessing.Primitives;
using Microsoft.Extensions.Hosting;
using Services.Common.IntegrationEvents;

namespace Catalog.Core;
public class EventBusMessageProducer : BackgroundService
{
    private readonly ILogger<EventBusMessageProducer> _logger;

    private IEventBus _eventBus;

    public EventBusMessageProducer(ILogger<EventBusMessageProducer> logger, IEventBus eventBus)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while(!stoppingToken.IsCancellationRequested)
        {

            var @event = new ProductPriceChangedIntegrationEvent(new Guid("f9636be0-6148-4bb4-adf9-dc0e7ad36766"), 1, 1);
            
            await _eventBus.PublishAsync(new EventBusMessage(new GuidType("f9636be0-6148-4bb4-adf9-dc0e7ad36766"), @event)); ;

            await Task.Delay(1000);
        }
    }
}


