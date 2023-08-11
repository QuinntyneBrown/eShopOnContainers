// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace eShopOnContainers.CodeGenerator.Services;

public interface ITemplateProcessor
{
    Task<string> ProcessAsync<T>(string template, T model);

}


