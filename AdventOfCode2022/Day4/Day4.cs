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
            int result = input.Where(x =>
                (int.Parse(x.Split(',')[0].Split('-')[0]) <= int.Parse(x.Split(',')[1].Split('-')[0]) &&
                int.Parse(x.Split(',')[0].Split('-')[1]) >= int.Parse(x.Split(',')[1].Split('-')[1])) ||
                (int.Parse(x.Split(',')[0].Split('-')[0]) >= int.Parse(x.Split(',')[1].Split('-')[0]) &&
                int.Parse(x.Split(',')[0].Split('-')[1]) <= int.Parse(x.Split(',')[1].Split('-')[1]))
                ).Count();

            int fap = input.Select(x => new
            {
                S1 = int.Parse(x.Split(',')[0].Split('-')[0]),
                E1 = int.Parse(x.Split(',')[0].Split('-')[1]),
                S2 = int.Parse(x.Split(',')[1].Split('-')[0]),
                E2 = int.Parse(x.Split(',')[1].Split('-')[1])
            }).Where(y =>
            (y.S1 <= y.S2 && y.E1 >= y.E2) ||
            (y.S1 >= y.S2 && y.E1 <= y.E2)
            ).Count();

            IO.WriteOutput(day, "a", result);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArray(day, "a");

            int result = input.Select(x => new
            {
                S1 = int.Parse(x.Split(',')[0].Split('-')[0]),
                E1 = int.Parse(x.Split(',')[0].Split('-')[1]),
                S2 = int.Parse(x.Split(',')[1].Split('-')[0]),
                E2 = int.Parse(x.Split(',')[1].Split('-')[1])
            }).Where(y => 
            (y.S1 >= y.S2 && y.S1 <= y.E2) ||
            (y.E1 >= y.S2 && y.E1 <= y.E2) ||
            (y.S2 >= y.S1 && y.S2 <= y.E1) ||
            (y.E2 >= y.S1 && y.E2 <= y.E1)
            ).Count();

            IO.WriteOutput(day, "b", result);
        }
    }
}
