// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Integration;

public interface IConverter<T> {

    List<Tuple<int, int>> Convert(T value);
}

