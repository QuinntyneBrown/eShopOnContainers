// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Integration.Types;

public class GuidType: ValueObject, IBitPackable
{
    public GuidType(Guid value)
    {
        Value = value;
    }

    public GuidType(byte[] bytes)
    {
        Value = new Guid(bytes);
    }

    public static int SizeInBits = 128;

    public Guid Value { get; }

    public (int value, int numberOfBits)[] ToDescriptors()
        => Value.ToByteArray().Select(x => ((int)x, 8)).ToArray();

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
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
