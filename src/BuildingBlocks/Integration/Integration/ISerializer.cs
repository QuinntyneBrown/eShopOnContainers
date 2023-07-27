// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Integration;

public interface ISerializer<T> {
    byte[] Serialize(T value);
    T Deserialize(byte[] data);
}

public abstract class SerializerBase<T>: ISerializer<T>
{
    public abstract byte[] Serialize(T value);
    public abstract T Deserialize(byte[] data);
}

