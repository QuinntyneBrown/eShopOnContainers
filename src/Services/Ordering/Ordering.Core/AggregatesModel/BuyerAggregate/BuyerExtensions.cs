// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Ordering.Core.AggregatesModel.BuyerAggregate;

public static class BuyerExtensions
{
    public static BuyerDto ToDto(this Buyer buyer)
    {
        return new BuyerDto
        {
            BuyerId = buyer.BuyerId,
        };

    }

    public async static Task<List<BuyerDto>> ToDtosAsync(this IQueryable<Buyer> buyers,CancellationToken cancellationToken)
    {
        return await buyers.Select(x => x.ToDto()).ToListAsync(cancellationToken);
    }

}


