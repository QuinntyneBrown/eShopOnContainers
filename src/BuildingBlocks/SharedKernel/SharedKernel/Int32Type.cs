// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Buffers.Binary;
using SharedKernel.Abstractions;

namespace SharedKernel;

public class Int32Type : ValueObject, IBitPackable
{
    public Int32Type(Int32 value)
    {
        Value = value;
    }

    public Int32Type(byte[] bytes)
    {
        Value = BinaryPrimitives.ReadInt32BigEndian(bytes);
    }

    public Int32 Value { get; }

    public static int SizeInBits = 32;

    public (int value, int numberOfBits)[] ToDescriptors()
    {
        byte[] buffer = new byte[4];

        BinaryPrimitives.WriteInt32BigEndian(buffer, Value);

        return buffer.Select(x => ((int)x, 8)).ToArray();
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static implicit operator Int32(Int32Type type)
    {
        return type.Value;
    }

    public static explicit operator Int32Type(Int32 value)
    {
        return new Int32Type(value);
    }

}
