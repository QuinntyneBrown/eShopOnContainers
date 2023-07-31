// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using BenchmarkDotNet.Attributes;

namespace Integration.Benchmarks;

[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class ProductPriceChangedIntegrationEventBenchmarks
{
    [Benchmark]
    public void PackIntoBuffer()
    {
        var buffer = new byte[40];

        var @event = new Integration.Events.ProductPriceChangedIntegrationEvent(Guid.NewGuid(), 5000, 5000);

        @event.Pack(buffer);
    }
}

