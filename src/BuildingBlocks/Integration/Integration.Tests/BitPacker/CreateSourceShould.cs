// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Integration.Events;

namespace Integration.Tests.BitPacker;

public class CreateSourceShould {

    [Fact]
    public void Test()
    {
        var integrationEvent = new ProductPriceChangedIntegrationEvent(
            Guid.NewGuid(),
            Guid.NewGuid(),
            300,
            600);

        var bytes = new byte[40];

        Integration.BitPacker.PackIntoBuffer(integrationEvent, bytes);

        var result = Integration.BitPacker.Unpack(bytes, 320);

        var s = new ProductPriceChangedIntegrationEvent(result);

        Assert.Equal(integrationEvent, s);


    }
}

