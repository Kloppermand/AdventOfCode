using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2021.Day7
{
    public static class Day7
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileIntArraySingleLine(day, "a");
            Array.Sort(input);
            int fuelSpend = 0;
            foreach (var pos in input)
            {
                fuelSpend += Math.Abs(input[input.Length / 2] - pos);
            }

            IO.WriteOutput(day, "a", fuelSpend.ToString());
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileIntArraySingleLine(day, "a");
            int maxPos = input.Max();
            long[] fuelSpend = new long[maxPos];
            for (int i = 0; i < maxPos; i++)
            {
                foreach (var pos in input)
                {
                    fuelSpend[i] += GetTriangleNumber(Math.Abs(pos - i));
                }
            }

            IO.WriteOutput(day, "b", fuelSpend.Min().ToString());
        }

        private static long GetTriangleNumber(int n)
        {
            return (n * (n + 1)) / 2;
        }
    }
}
