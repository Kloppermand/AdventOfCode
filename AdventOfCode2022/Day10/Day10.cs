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

            int regX = 1;
            int cycle = 1;
            List<string> CRT = new();

            foreach (var instruction in input)
            {
                WritePixelToCrt(cycle, regX, CRT);
                cycle++;
                if (instruction.Equals("noop"))
                    continue;

                WritePixelToCrt(cycle, regX, CRT);
                cycle++;
                regX += int.Parse(instruction.Split(' ')[1]);
            }

            IO.WriteOutput(day, "b", string.Join('\n',CRT));
        }

        private static int GetResultPart(int cycle, int regX)
        {
            if (cycle < 230 && (cycle % 40) - 20 == 0)
                return cycle * regX;
            return 0;
        }

        private static void WritePixelToCrt(int cycle, int regX, List<string> CRT)
        {
            if (CRT.Count() < cycle / 40 + 1)
                CRT.Add("");
            CRT[(cycle-1) / 40] += Math.Abs(regX-((cycle-1)%40)) < 2 ? "#" : ".";
        }
    }
}
