// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace eShopOnContainers.CodeGenerator.Syntax.Properties;

public class PropertyModel : SyntaxModel
{
    public PropertyModel(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}
