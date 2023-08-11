// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace eShopOnContainers.CodeGenerator.Domain;

public interface IDomainModelParser
{
    Task<DomainModel> ParseAsync(string path);
}


