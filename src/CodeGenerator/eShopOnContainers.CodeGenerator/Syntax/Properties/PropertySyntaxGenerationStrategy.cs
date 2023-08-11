// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Extensions.Logging;
using System.Text;

namespace eShopOnContainers.CodeGenerator.Syntax.Properties;

public class PropertyGenerationStrategy : ISyntaxGenerationStrategy<PropertyModel>
{
    private readonly ILogger<PropertyGenerationStrategy> _logger;

    public PropertyGenerationStrategy(ILogger<PropertyGenerationStrategy> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<string> GenerateAsync(ISyntaxGenerator generator, PropertyModel model)
    {
        _logger.LogInformation("Generating syntax. {name}", model.Name);

        StringBuilder sb = new StringBuilder();

        sb.Append($"public string {model.Name}" + " { get; set; }");

        return sb.ToString();
    }
}