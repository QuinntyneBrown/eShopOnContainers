// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using SharedKernel.Abstractions;

namespace SharedKernel;


public class StringType: ValueObject, IBitPackable
{
    public StringType(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public (int value, int numberOfBits)[] ToDescriptors()
    {
        throw new NotImplementedException();
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
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
