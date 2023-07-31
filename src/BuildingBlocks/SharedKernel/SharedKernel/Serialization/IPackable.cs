﻿// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace SharedKernel.Serialization;

public interface IPackable
{
    void Pack(byte[] buffer, int index, int bitIndex);
}
