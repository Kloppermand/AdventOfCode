using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2019.Day1
{
    public static class Day1
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileIntArray(day, "a");

            int result = input.Sum(x => x / 3 - 2);

            IO.WriteOutput(day, "a", result);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileIntArray(day, "a");

            int sum = 0;
            foreach (var x in input)
            {
                int tmp = x;
                while (tmp > 0)
                {
                    tmp = Math.Max(tmp / 3 - 2,0);
                    sum += tmp;
                }
            }

            IO.WriteOutput(day, "b", sum);
        }
    }
}
