// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using StreamProcessing.Primitives;

namespace StreamProcessing;

public interface IEncodable
{
    void Encode(Span<byte> buffer, int index= 0, int bitIndex = 7);
    Int16Type SizeInBits { get; }
}

