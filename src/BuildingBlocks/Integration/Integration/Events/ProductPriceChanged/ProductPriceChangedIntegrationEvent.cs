// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Integration.Types;
using Integration.Types.ProductId;
using System;

namespace Integration.Events.ProductPriceChanged;

public record ProductPriceChangedIntegrationEvent : IntegrationEvent
{
    public ProductIdType ProductId { get; init; }
    public PriceType NewPrice { get; set; }
    public PriceType OldPrice { get; set; }

}

