// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Extensions.Logging;
using System.Text;

namespace eShopOnContainers.CodeGenerator.Syntax.Structs;

public class StructGenerationStrategy : ISyntaxGenerationStrategy<StructModel>
{
    private readonly ILogger<StructGenerationStrategy> _logger;

    public StructGenerationStrategy(ILogger<StructGenerationStrategy> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<string> GenerateAsync(ISyntaxGenerator generator, StructModel model)
    {

        _logger.LogInformation("Generating struct syntax. {name}", model.Name);

        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"partial record struct {model.Name}");

        sb.AppendLine("{");

        foreach (var property in model.Properties)
        {
            sb.AppendLine((await generator.GenerateAsync(property)).Indent(1));
        }

        sb.AppendLine("}");

        return sb.ToString();
    }
}
