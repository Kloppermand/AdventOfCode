using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2022.Day1
{
    public static class Day1
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringArrayBlankLine(day, "a");
            
            var result = input.Max(x => x.Split(' ').Sum(y => int.Parse(y)));

            IO.WriteOutput(day, "a", result);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArrayBlankLine(day, "a");

            var result = input.Select(x => x.Split(' ').Sum(y => int.Parse(y))).OrderBy(z => z).TakeLast(3).Sum();

            IO.WriteOutput(day, "b", result);
        }
    }
}
