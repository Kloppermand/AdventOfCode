using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2022.Day4
{
    public static class Day4
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            int result = 0;

            foreach (var pair in input)
            {
                var sections = pair.Split(',');
                var elf1 = sections[0].Split('-').Select(x => int.Parse(x)).ToArray();
                var elf2 = sections[1].Split('-').Select(x => int.Parse(x)).ToArray();

                if (elf1[0] <= elf2[0] && elf1[1] >= elf2[1])
                    result++;
                else if (elf1[0] >= elf2[0] && elf1[1] <= elf2[1])
                    result++;
            }

            IO.WriteOutput(day, "a", result);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            int result = 0;

            foreach (var pair in input)
            {
                var sections = pair.Split(',');
                var elf1 = sections[0].Split('-').Select(x => int.Parse(x)).ToArray();
                var elf2 = sections[1].Split('-').Select(x => int.Parse(x)).ToArray();

                if (elf1[0] >= elf2[0] && elf1[0] <= elf2[1])
                    result++;
                else if (elf1[1] >= elf2[0] && elf1[1] <= elf2[1])
                    result++;
                else if (elf2[0] >= elf1[0] && elf2[0] <= elf1[1])
                    result++;
                else if (elf2[1] >= elf1[0] && elf2[1] <= elf1[1])
                    result++;
            }

            IO.WriteOutput(day, "b", result);
        }
    }
}
