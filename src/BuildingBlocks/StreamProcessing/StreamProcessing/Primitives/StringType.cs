// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace StreamProcessing.Primitives;


public record struct String255Type: IEncodable
{
    public String255Type(string value)
    {
        Value = value;
    }

    public Int16Type SizeInBits =>  (Int16Type)(255 * 8);

    public string Value { get; }

    public void Encode(Span<byte> buffer, int index, int bitIndex)
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
