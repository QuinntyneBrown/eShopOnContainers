// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace SharedKernel.Abstractions;

public abstract class ValueObject
{
    protected abstract IEnumerable<object> GetEqualityComponents();

    public override bool Equals(object obj)
    {
        if (obj == null)
            return false;

        if (GetType() != obj.GetType())
            return false;

        var valueObject = (ValueObject)obj;

        return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
    }

    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Aggregate(1, (current, obj) =>
            {
                unchecked
                {
                    return current * 23 + (obj?.GetHashCode() ?? 0);
                }
            });
    }

    public static bool operator ==(ValueObject a, ValueObject b)
    {
        if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            return true;

        if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(ValueObject a, ValueObject b)
    {
        return !(a == b);
    }
}
