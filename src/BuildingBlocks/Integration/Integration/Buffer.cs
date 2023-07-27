// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Extensions.Logging;

namespace Integration;

public class Buffer: IBuffer
{
    private readonly ILogger<Buffer> _logger;

    public Buffer(ILogger<Buffer> logger){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }
}


