// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace IO.Compression.Primitives;

public struct GuidType: IEquatable<GuidType>, IPackable
{
    public GuidType()
    {
        var guid = Guid.NewGuid();

        Value = guid;
    }
    public GuidType(Guid value)
    {
        Value = value;
    }

    public GuidType(string value)
    {
        Value = new Guid(value);
    }
    public GuidType(byte[] bytes)
    {
        Value = new Guid(bytes);
    }

    public Int16Type SizeInBits => (Int16Type)128;
    public Guid Value { get; }

    public void Pack(Span<byte> buffer, int index, int bitIndex)
    {        
        BitVector8.Pack(Value.ToByteArray(), SizeInBits, buffer, index, bitIndex);
    }

    public override bool Equals(object? obj) => obj is GuidType other && Equals(other);
    public bool Equals(GuidType other) => Value.Equals(other.Value);

    public static bool operator ==(GuidType left, GuidType right) => left.Equals(right);

    //public override int GetHashCode() => (X, Y).GetHashCode();
    public override int GetHashCode() => Value.GetHashCode();

    public static bool operator !=(GuidType lhs, GuidType rhs) => !(lhs == rhs);

    public static implicit operator Guid(GuidType type)
    {
        return type.Value;
    }

    public static explicit operator GuidType(Guid value)
    {
        return new GuidType(value);
    }
}
