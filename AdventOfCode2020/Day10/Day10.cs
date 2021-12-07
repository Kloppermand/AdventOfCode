using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Utilities;

namespace AdventOfCode2020.Day10
{
    public static class Day10
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileIntArray(day, "a");
            Array.Sort(input);
            int[] differences = new int[3];
            differences[2]++;
            differences[input[0] - 1]++;
            for (int i = 0; i < input.Length - 1; i++)
            {
                differences[input[i + 1] - input[i] - 1]++;
            }

            IO.WriteOutput(day, "a", (differences[0] * differences[2]).ToString());
        }


        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArray(day, "a");



            string result = "NOT SOLVED YET";
            IO.WriteOutput(day, "b", result);
        }
    }
}
