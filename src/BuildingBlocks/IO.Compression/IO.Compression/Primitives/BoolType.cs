// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace IO.Compression.Primitives;

public struct BoolType: IEquatable<BoolType>, IPackable
{
    public BoolType(bool value)
    {
        Value = value;
    }

    public BoolType(byte[] value)
    {
        Value = value[0] == 1 ? true : false;
    }

    public bool Value { get; }

    public bool Equals(BoolType other)
    {
        return Value == other.Value;
    }

    public Int16Type SizeInBits => (Int16Type)1;

    public void Pack(Span<byte> buffer, int index, int bitIndex)
    {
        Span<byte> bytes = stackalloc byte[1];

        bytes[0] = (byte)(Value == true ? 1: 0);

        BitVector8.Pack(bytes, SizeInBits, buffer, index, bitIndex);
    }

    public static implicit operator bool(BoolType type)
    {
        return type.Value;
    }

    public static explicit operator BoolType(bool value)
    {
        return new BoolType(value);
    }
}
