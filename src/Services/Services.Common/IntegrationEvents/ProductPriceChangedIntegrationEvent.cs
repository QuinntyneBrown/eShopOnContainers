// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using StreamProcessing;
using StreamProcessing.Primitives;

namespace Services.Common.IntegrationEvents;

public record ProductPriceChangedIntegrationEvent: IPackable
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
        ProductId = new GuidType(BitVector8.Inflate(buffer, 128, 0));
        OldPrice = new Int32Type(BitVector8.Inflate(buffer, 32, 16));
        NewPrice = new Int32Type(BitVector8.Inflate(buffer, 32, 20));
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

    public Int16Type SizeInBits => (Int16Type)192;

    public void Pack(Span<byte> buffer, int index = 0, int bitIndex = 7)
    {
        ProductId.Pack(buffer, index, bitIndex);
        OldPrice.Pack(buffer, index + 16, bitIndex); 
        NewPrice.Pack(buffer, index + 20, bitIndex);       
    }

}
