// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using BenchmarkDotNet.Attributes;

namespace Integration.Benchmarks;

[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class ProductPriceChangedIntegrationEventBenchmarks
{
    private Integration.Events.ProductPriceChangedIntegrationEvent _event;

    [GlobalCleanup]
    public void Setup()
    {
        _event = new Integration.Events.ProductPriceChangedIntegrationEvent(Guid.NewGuid(), Guid.NewGuid(), 5000, 5000);
    }

    [Benchmark]
    public void PackIntoBuffer()
    {
        var buffer = new byte[40];

        var @event = new Integration.Events.ProductPriceChangedIntegrationEvent(Guid.NewGuid(), Guid.NewGuid(), 5000, 5000);

        @event.SerializeIntoBuffer(buffer);
    }
}

