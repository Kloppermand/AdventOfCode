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
            Dictionary<char, int> shapeScore = new() { { 'X', 1 }, { 'Y', 2 }, { 'Z', 3 }, { 'A', 1 }, { 'B', 2 }, { 'C', 3 } };

            int score = input.Sum(round => shapeScore[round[2]] + ((shapeScore[round[2]] - shapeScore[round[0]] + 4) % 3) * 3);

            IO.WriteOutput(day, "a", score);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            Dictionary<char, int> shapeScore = new() { { 'X', -1 }, { 'Y', 0 }, { 'Z', 1 }, { 'A', 1 }, { 'B', 2 }, { 'C', 3 } };

            var score = input.Sum(round => (shapeScore[round[0]] + shapeScore[round[2]] + 2) % 3 + 1 + (shapeScore[round[2]] + 1) * 3);

            IO.WriteOutput(day, "b", score);
        }
    }
}
