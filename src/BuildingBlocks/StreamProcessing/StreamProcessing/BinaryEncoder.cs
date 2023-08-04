// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace StreamProcessing;

public static class BinaryEncoder
{
    public static void Encode(ReadOnlySpan<byte> input, int sizeInBits, Span<byte> buffer, int index = 0, int bitIndex = 7)
    {
        for (int j = 0; j < input.Length; j++)
        {
            int numberOfBits = sizeInBits % 8 > 0 ? sizeInBits % 8 : 8;

            sizeInBits -= numberOfBits;

            int value = input[j];

            while (numberOfBits > 0)
            {
                if (index >= buffer.Length) return;

                var numberOfBitsThatCanBePacked = bitIndex + 1;

                if (numberOfBits <= numberOfBitsThatCanBePacked)
                {
                    var mask = (1 << numberOfBits) - 1;

                    buffer[index] |= (byte)((value & mask) << (numberOfBitsThatCanBePacked - numberOfBits));

                    bitIndex -= numberOfBits;

                    if (bitIndex == -1)
                    {
                        bitIndex = 7;
                        index++;
                    }

                    numberOfBits = 0;
                }
                else
                {
                    var mask = ((1 << numberOfBitsThatCanBePacked) - 1) << (numberOfBits - numberOfBitsThatCanBePacked);
                    buffer[index] |= (byte)((value & mask) >>> (numberOfBits - numberOfBitsThatCanBePacked));
                    bitIndex = 7;
                    index++;
                    numberOfBits -= +numberOfBitsThatCanBePacked;
                }
            }
        }
    }
}

