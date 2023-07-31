// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace SharedKernel;

public struct GuidType: IEquatable<GuidType>, IPackable
{
    public GuidType(Guid value)
    {
        Value = value;
    }

    public GuidType(byte[] bytes)
    {
        Value = new Guid(bytes);
    }

    public Guid Value { get; }


    public void Pack(byte[] buffer, int index, int bitIndex)
    {        
        BitVector8.Pack(Value.ToByteArray(), 16, buffer, index, bitIndex);
    }

    public bool Equals(GuidType other)
    {
        return Value.Equals(other.Value);
    }

    public static implicit operator Guid(GuidType type)
    {
        return type.Value;
    }

    public static explicit operator GuidType(Guid value)
    {
        return new GuidType(value);
    }

}
