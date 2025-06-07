using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    internal class Utilities
    {
        private static readonly Random rnd = new Random();

        public static string DecToBin(int value)
        {
            return Convert.ToString(value, 2);
        }

        public static int BinToDec(string binary)
        {
            return Convert.ToInt32(binary, 2);
        }

        public static int GetStringLength(int maxValue)
        {
            return (int)Math.Ceiling(Math.Log(maxValue + 1, 2));
        }

        public static int RangeRandom(int min, int max)
        {
            return new Random(Guid.NewGuid().GetHashCode()).Next(min, max + 1);
        }

        public static string NormalizeBinaryString(string binary, int targetLength)
        {
            return binary.PadLeft(targetLength, '0');
        }

        private static int Clamp(int value,
                                 int min,
                                 int max)
        {
            if (value < min) { return min; }
            if (value > max) { return max; }
            return value;
        }
        public static string GetNormalizedBinary(string binary,  int lowerBound,
                                                 int upperBound, int targetLength)
        {
            int value = Clamp(BinToDec(binary), lowerBound, upperBound); return NormalizeBinaryString(DecToBin(value), targetLength);
        }
        public static string GetNormalizedBinaryFromValue(int value, int upperBound)
        {
            int clamped = Clamp(value, 1, upperBound); int length = DecToBin(value).Length;
            return NormalizeBinaryString(DecToBin(clamped), length);
        }
    }
}

