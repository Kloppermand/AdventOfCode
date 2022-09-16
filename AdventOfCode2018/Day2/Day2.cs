using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Utilities;

namespace AdventOfCode2018.Day2
{
    public static class Day2
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringArray(day, "a");

            var twos = input.Where(str => str.GroupBy(chr => chr).Where(grp => grp.Count() == 2).Count() > 0).Count();
            var threes = input.Where(str => str.GroupBy(chr => chr).Where(grp => grp.Count() == 3).Count() > 0).Count();

            IO.WriteOutput(day, "a", twos * threes);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            int n = input[0].Length;
            bool done = false;
            string common = "";

            foreach (var item in input)
            {
                foreach (var item2 in input)
                {
                    common = GetCommonLetters(item, item2);
                    if (common.Length == n - 1)
                    {
                        done = true;
                        break;
                    }
                }
                if (done) break;
            }

            IO.WriteOutput(day, "b", common);
        }

        private static string GetCommonLetters(string string1, string string2)
        {
            var retString = new StringBuilder();

            for (int i = 0; i < string1.Length; i++)
            {
                if (string1[i] == string2[i])
                    retString.Append(string1[i]);
            }

            return retString.ToString();
        }
    }
}
