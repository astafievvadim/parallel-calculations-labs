using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    internal class Utils
    {
        private static Random rnd = new Random();

        public static string Dec2Bin(int value)
        {
            return Convert.ToString(value, 2);
        }

        public static int Bin2Dec(string str)
        {
            return Convert.ToInt32(str, 2);
        }

        public static int rangeRandom(int l, int r)
        {
            return rnd.Next(l, r + 1);
        }

        public static string NormalizeString(string str, int length)
        {
            if (str.Length >= length) { return str.Substring(0, length); }
            return str.PadLeft(length, '0');
        }

        public static string strNormalizeDec2Bin(string chr)
        {
            int temp = Math.Min(Bin2Dec(chr), 100);
            return NormalizeString(Dec2Bin(temp), 7);
        }
    }
}
