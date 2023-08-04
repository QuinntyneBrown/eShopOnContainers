// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Ordering.Core.AggregatesModel.OrderAggregate;

public static class OrderExtensions
{
    public static OrderDto ToDto(this Order order)
    {
        return new OrderDto
        {
            OrderId = order.OrderId,
            Description = order.Description,
        };

    }

    public async static Task<List<OrderDto>> ToDtosAsync(this IQueryable<Order> orders,CancellationToken cancellationToken)
    {
        return await orders.Select(x => x.ToDto()).ToListAsync(cancellationToken);
    }

}


