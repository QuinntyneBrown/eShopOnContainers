// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace eShopOnContainers.CodeGenerator.Syntax;

public interface ISyntaxGenerationStrategy<T>
{
    Task<string> GenerateAsync(ISyntaxGenerator generator, T model);
}


