// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Integration.Types;

public class PriceConverter : IConverter<PriceType>
{
    public List<Tuple<int, int>> Convert(PriceType value)
    {
        return new ()
        {
            new (0,0)
        };
    }
}


