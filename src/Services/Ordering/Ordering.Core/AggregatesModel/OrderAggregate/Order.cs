// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Ordering.Core.AggregatesModel.OrderAggregate;

public class Order
{
    public GUid OrderId { get; set; }
    public string Description { get; set; }
}


