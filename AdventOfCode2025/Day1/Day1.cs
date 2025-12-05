using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using Utilities;

namespace AdventOfCode2025.Day1
{
    public static class Day1
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            var turns = ParseTurns(input);

            int pointer = 50;
            int result = 0;

            foreach (var turn in turns)
            {
                pointer = (pointer + turn) % 100;
                if (pointer == 0)
                    result++;
            }

            IO.WriteOutput(day, "a", result);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            var turns = ParseTurns(input);

            int current = 50;
            int result = 0;

            foreach (var turn in turns)
            {
                var old = current;
                current += turn;
                if (current < 1)
                    result += Math.Abs(current) / 100 + (old != 0 ? 1 : 0);
                if (current > 99)
                    result += current / 100;

                current = UtilMath.Mod(current, 100);
            }

            IO.WriteOutput(day, "b", result);
        }

        private static IEnumerable<int> ParseTurns(string[] input)
        {
            return input.Select(t => t[0] == 'L' ? -int.Parse(t[1..]) : int.Parse(t[1..]));
        }
    }
}
