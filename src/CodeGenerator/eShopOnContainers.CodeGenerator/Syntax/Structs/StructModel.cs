// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using eShopOnContainers.CodeGenerator.Syntax.Properties;

namespace eShopOnContainers.CodeGenerator.Syntax.Structs;

public class StructModel : SyntaxModel
{
    public StructModel(string name)
    {
        Name = name;
        Properties = new List<PropertyModel>();
    }

    public string Name { get; set; }
    public List<PropertyModel> Properties { get; set; }
}
