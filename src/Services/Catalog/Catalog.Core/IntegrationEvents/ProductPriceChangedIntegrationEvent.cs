// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using IO.Compression;
using IO.Compression.Primitives;

namespace Catalog.Core.IntegrationEvents;

public record ProductPriceChangedIntegrationEvent
{
    public ProductPriceChangedIntegrationEvent(
        GuidType productId,
        Int32Type oldPrice,
        Int32Type newPrice)
    {
        ProductId = productId;
        OldPrice = oldPrice;
        NewPrice = newPrice;
    }

    public ProductPriceChangedIntegrationEvent(byte[] buffer)
    {
        ProductId = new GuidType(BitVector8.Unpack(buffer, 16, 16));
        OldPrice = new Int32Type(BitVector8.Unpack(buffer, 32, 32));
        NewPrice = new Int32Type(BitVector8.Unpack(buffer, 32, 36));
    }
    
    public ProductPriceChangedIntegrationEvent(
        Guid productId,
        int oldPrice,
        int newPrice)
    {
        ProductId = (GuidType)productId;
        OldPrice = (Int32Type)oldPrice;
        NewPrice = (Int32Type)newPrice;
    }

    public GuidType ProductId { get; init; }
    public Int32Type OldPrice { get; init; }
    public Int32Type NewPrice { get; init; }

    public void Pack(byte[] buffer, int index = 0, int bitIndex = 7)
    {
        ProductId.Pack(buffer, index + 2, bitIndex);
        OldPrice.Pack(buffer, index + 6,bitIndex); 
        NewPrice.Pack(buffer, index + 10, bitIndex + 2);       
    }
}
