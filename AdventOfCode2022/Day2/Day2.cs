using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2022.Day2
{
    public static class Day2
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringArray(day, "a");

            int score = input.Sum(x => x[2]-87 + (x[2] - x[0] -1) % 3 * 3);

            IO.WriteOutput(day, "a", score);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArray(day, "a");

            var score = input.Sum(x => (x[0] + x[2]-1) % 3 + 1 + (x[2]-88) * 3);

            IO.WriteOutput(day, "b", score);
        }
    }
}
