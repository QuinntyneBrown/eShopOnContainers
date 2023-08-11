// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Extensions.Logging;
using System.IO.Abstractions;
using System.Xml.Linq;

namespace eShopOnContainers.CodeGenerator.Domain;

public class DomainModelParser : IDomainModelParser
{
    private readonly ILogger<DomainModelParser> _logger;
    private readonly IFileSystem _fileSystem;
    private DomainModel _domainModel;
    public DomainModelParser(ILogger<DomainModelParser> logger, IFileSystem fileSystem)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
    }

    public async Task<DomainModel> ParseAsync(string path)
    {
        _domainModel = new DomainModel();

        return _domainModel;
    }

}


