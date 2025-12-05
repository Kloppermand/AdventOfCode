using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2025.Day3
{
    public static class Day3
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringArray(day, "a");

            var result = input.Sum(i => MaxJoltage2(i));

            IO.WriteOutput(day, "a", result);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArray(day, "a");

            var result = input.Sum(i => MaxJoltage(i,12));

            IO.WriteOutput(day, "b", result);
        }

        private static int MaxJoltage2(string input)
        {
            var tens = input[..^1].Max();
            var ones = input.Substring(input.IndexOf(tens)+1).Max();
            return (tens - '0') * 10 + (ones - '0');
        }

        private static long MaxJoltage(string input, int digits)
        {
            string joltage = "";
            for (int i = digits; i > 0; i--)
            {
                var part = input.Take(input.Length-i+1).Max();
                joltage += part;
                input = input.Substring(input.IndexOf(part)+1);
            }

            return long.Parse(joltage);
        }
    }
}
