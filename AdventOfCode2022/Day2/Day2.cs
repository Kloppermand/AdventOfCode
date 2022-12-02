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

            int score = input.Sum(round => round[2]-87 + ((round[2] - round[0] -19) % 3) * 3);

            IO.WriteOutput(day, "a", score);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArray(day, "a");

            var score = input.Sum(round => (round[0] + round[2]-151) % 3 + 1 + (round[2]-88) * 3);

            IO.WriteOutput(day, "b", score);
        }
    }
}
