// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace eShopOnContainers.CodeGenerator.Syntax;

public interface ISyntaxGenerator
{
    Task<string> GenerateAsync<T>(T model);
}
