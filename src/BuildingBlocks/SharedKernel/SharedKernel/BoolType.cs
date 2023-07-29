// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using SharedKernel.Abstractions;
using SharedKernel.Serialization;

namespace SharedKernel;

public class BoolType: ValueObject, IBitPackable
{
    public BoolType(bool value)
    {
        Value = value;
    }

    public bool Value { get; }

    public (int value, int numberOfBits)[] ToDescriptors()
    {
        return new (int, int)[]
        {

            (Value ? 1: 0, 1)
        };
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
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
