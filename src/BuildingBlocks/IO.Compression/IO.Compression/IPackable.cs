// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace IO.Compression;

public interface IPackable
{
    void Pack(byte[] buffer, int index, int bitIndex);
}

