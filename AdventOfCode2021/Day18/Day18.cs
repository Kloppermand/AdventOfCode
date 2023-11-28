using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Runtime;
using Utilities;

namespace AdventOfCode2021.Day18
{
    public static class Day18
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringArray(day, "a");

            var res = new SnailfishNumber(input.First());

            foreach (var num in input.Skip(1))
            {
                res += new SnailfishNumber(num);
            }

            IO.WriteOutput(day, "a", res.Magnitude());
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArray(day, "a");

            var numbers = input.Select(n => new SnailfishNumber(n));
            int maxMagnitude = 0;
            SnailfishNumber n1;
            SnailfishNumber n2;
            foreach (var num in numbers)
            {
                foreach (var num2 in numbers)
                {
                    if (num.ToString() == num2.ToString())
                        continue;

                    int sum = (num + num2).Magnitude();
                    if (sum > maxMagnitude)
                    {
                        maxMagnitude = sum;
                    }
                }
            }

            IO.WriteOutput(day, "b", maxMagnitude);
        }
    }
}
