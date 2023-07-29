// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Basket.Core.AggregatesModel.BasketItemAggregate;

public class BasketItemDto
{
    public Guid BasketItemId { get; set; }
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
    public int UnitPrice { get; set; }
    public int OldUnitPrice { get; set; }
    public int Quantity { get; set; }
    public string PictureUrl { get; set; }
}


