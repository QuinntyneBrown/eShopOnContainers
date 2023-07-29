// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Integration.Types;

namespace Integration.Events;

public record ProductPriceChangedIntegrationEvent : IntegrationEvent
{
    public ProductPriceChangedIntegrationEvent(
        GuidType productId,
        Int32Type oldPrice,
        Int32Type newPrice)
        : base(Constants.ProductPriceChanged)
    {
        ProductId = productId;
        OldPrice = oldPrice;
        NewPrice = newPrice;
    }

    public ProductPriceChangedIntegrationEvent(byte[] buffer)
        : base(new GuidType(BitPacker.Unpack(buffer, GuidType.SizeInBits)))
    {
        ProductId = new GuidType(BitPacker.Unpack(buffer, GuidType.SizeInBits, 16));
        OldPrice = new Int32Type(BitPacker.Unpack(buffer, Int32Type.SizeInBits, 32));
        NewPrice = new Int32Type(BitPacker.Unpack(buffer, Int32Type.SizeInBits, 36));
    }
    public int SizeInBytes { get; } = 40;

    public const int SizeInBits = 320;

    public ProductPriceChangedIntegrationEvent(
        Guid productId,
        int oldPrice,
        int newPrice)
        : base(Constants.ProductPriceChanged)
    {
        ProductId = (GuidType)productId;
        OldPrice = (Int32Type)oldPrice;
        NewPrice = (Int32Type)newPrice;
    }

    public GuidType ProductId { get; init; }
    public Int32Type OldPrice { get; init; }
    public Int32Type NewPrice { get; init; }

    
    public override (int value, int numberOfBits)[] ToDescriptors()
    {
        return Id.ToDescriptors()
            .Concat(ProductId.ToDescriptors()
            .Concat(OldPrice.ToDescriptors())
            .Concat(NewPrice.ToDescriptors()))
            .ToArray();
    }

    public void SerializeIntoBuffer(byte[] buffer, int index = 0, int bitIndex = 7)
    {
        BitPacker.PackIntoBuffer(Id, buffer, index, bitIndex);
        BitPacker.PackIntoBuffer(ProductId, buffer, index + 16, bitIndex);
        BitPacker.PackIntoBuffer(OldPrice, buffer, index + 32, bitIndex);
        BitPacker.PackIntoBuffer(NewPrice, buffer, index + 36, bitIndex);
    }

    public static ProductPriceChangedIntegrationEvent Unpack(byte[] buffer)
    {
        var id = new GuidType(BitPacker.Unpack(buffer, GuidType.SizeInBits));

        if(id != Constants.ProductPriceChanged)
        {
            throw new Exception();
        }

        var productId = new GuidType(BitPacker.Unpack(buffer, GuidType.SizeInBits, 16));
        var oldPrice = new Int32Type(BitPacker.Unpack(buffer, Int32Type.SizeInBits, 32));
        var newPrice = new Int32Type(BitPacker.Unpack(buffer, Int32Type.SizeInBits, 36));

        return new ProductPriceChangedIntegrationEvent(productId, oldPrice, newPrice);
    }
}

