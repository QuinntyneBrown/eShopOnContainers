// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace IO.Compression.Primitives;


public class String255Type: IEquatable<String255Type>, IPackable
{
    public String255Type(string value)
    {
        Value = value;
    }

    public int SizeInBits => 255 * 8;

    public string Value { get; }

    public bool Equals(String255Type? other)
    {
        throw new NotImplementedException();
    }

    public void Pack(Span<byte> buffer, int index, int bitIndex)
    {
        throw new NotImplementedException();
    }

    public static implicit operator string(String255Type type)
    {
        return type.Value;
    }

    public static explicit operator String255Type(string value)
    {
        return new String255Type(value);
    }

}
