// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Concurrent;
using System.IO.Abstractions;

namespace eShopOnContainers.CodeGenerator.Services;

public class TemplateLocator : ITemplateLocator
{
    private readonly ILogger<TemplateLocator> _logger;
    private readonly IFileSystem _fileSystem;
    private readonly CodeGeneratorOptions _options;
    private readonly ConcurrentDictionary<string, string> _cache = new ConcurrentDictionary<string, string>();
    public TemplateLocator(ILogger<TemplateLocator> logger, IFileSystem fileSystem, IOptions<CodeGeneratorOptions> optionsAccessor)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
        _options = optionsAccessor.Value;
    }

    public async Task<string> Get(string name)
    {
        _logger.LogInformation("Get template. {name}", name);

        var result = _cache.TryGetValue(name, out string? _cachedTemplate);

        if (!result)
        {
            _cachedTemplate = _fileSystem.File.ReadAllText(Path.Combine(_options.TemplatesDirectory, $"{name}.txt"));

            _cache.TryAdd(name, _cachedTemplate);
        }

        return _cachedTemplate!;
    }

}

