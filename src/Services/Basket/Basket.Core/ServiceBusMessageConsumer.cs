// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using EventBus.Udp;
using StreamProcessing.Primitives;
using Microsoft.Extensions.Hosting;
using Basket.Core.IntegrationEvents;

namespace Basket.Core;

public class ServiceBusMessageConsumer: BackgroundService
{
    private readonly ILogger<ServiceBusMessageConsumer> _logger;

    private readonly IEventBus _eventBus;

    public ServiceBusMessageConsumer(ILogger<ServiceBusMessageConsumer> logger, IEventBus eventBus){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        var tcs = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);

        var r = new List<(GuidType id, Func<byte[], object> factory)>()
        {
            ( new GuidType("f9636be0-6148-4bb4-adf9-dc0e7ad36766"), x => new ProductPriceChangedIntegrationEvent(x))
        };

        _eventBus.Subscribe(r, x =>
        {
            Console.WriteLine("?");
        });

        await tcs.Task;
    }
}