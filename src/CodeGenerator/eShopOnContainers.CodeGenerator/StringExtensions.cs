// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using static System.Linq.Enumerable;

namespace eShopOnContainers.CodeGenerator;

public static class StringExtensions
{

    public static string Indent(this string value, int indent, int spaces = 4)
    {
        string[] values = value.Split(Environment.NewLine);

        var result = string.Join(Environment.NewLine, values.Select(v => string.IsNullOrEmpty(v) ? v : $"{string.Join("", Range(1, spaces * indent).Select(i => ' '))}{v}"));

        return result;
    }
}

