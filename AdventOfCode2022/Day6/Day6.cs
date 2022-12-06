using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2022.Day6
{
    public static class Day6
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileString(day, "a");
            int n = 4;
            int i = 0;
            for (; i < input.Length - n; i++)
            {
                if (input.Substring(i, n).Distinct().Count() == n)
                    break;
            }

            IO.WriteOutput(day, "a", i + n);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileString(day, "a");
            int n = 14;
            int i = 0;
            for (; i < input.Length - n; i++)
            {
                if (input.Substring(i, n).Distinct().Count() == n)
                    break;
            }

            IO.WriteOutput(day, "b", i + n);
        }
    }
}
