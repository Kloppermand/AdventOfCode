using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2022.Day10
{
    public static class Day10
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            int regX = 1;
            int cycle = 1;
            int result = 0;

            foreach (var instruction in input)
            {
                result += GetResultPart(cycle, regX);
                cycle++;
                if (instruction.Equals("noop"))
                    continue;

                result += GetResultPart(cycle, regX);
                cycle++;
                regX += int.Parse(instruction.Split(' ')[1]);
            }

            IO.WriteOutput(day, "a", result);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArray(day, "a");


            IO.WriteOutput(day, "b", "gg");
        }

        private static int GetResultPart(int cycle, int regX)
        {
            if (cycle < 230 && (cycle % 40) - 20 == 0)
                return cycle * regX;
            return 0;
        }
    }
}
