// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using StreamProcessing;
using StreamProcessing.Primitives;

namespace Basket.Core.IntegrationEvents;

public record ProductPriceChangedIntegrationEvent: ICodable, INotification
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
        ProductId = new GuidType(BinaryDecoder.Decode(buffer, 128, 0));
        OldPrice = new Int32Type(BinaryDecoder.Decode(buffer, 32, 16));
        NewPrice = new Int32Type(BinaryDecoder.Decode(buffer, 32, 20));
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

    public void Encode(Span<byte> buffer, int index = 0, int bitIndex = 7)
    {
        ProductId.Encode(buffer, index, bitIndex);
        OldPrice.Encode(buffer, index + 16, bitIndex); 
        NewPrice.Encode(buffer, index + 20, bitIndex);       
    }

}
