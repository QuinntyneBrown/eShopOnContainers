// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace IO.Compression.Primitives;


public class StringType: IEquatable<StringType>, IPackable
{
    public StringType(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public bool Equals(StringType? other)
    {
        throw new NotImplementedException();
    }

    public void Pack(byte[] buffer, int index, int bitIndex)
    {
        throw new NotImplementedException();
    }

    public static implicit operator string(StringType type)
    {
        return type.Value;
    }

    public static explicit operator StringType(string value)
    {
        return new StringType(value);
    }

}
