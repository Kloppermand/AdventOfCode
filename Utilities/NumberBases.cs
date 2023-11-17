using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class NumberBases
    {

        public static string HexToBin(string input)
        {
            return string.Join("", input.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));

        }

        public static int BinToInt(string binary)
        {
            return Convert.ToInt32(binary, 2);
        }

        public static long BinToLong(string binary)
        {
            return Convert.ToInt64(binary, 2);
        }
    }
}
