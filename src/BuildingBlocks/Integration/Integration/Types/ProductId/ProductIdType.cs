// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Integration.Types.ProductId;

public class ProductIdType : ValueObject
{
    protected override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }

}


