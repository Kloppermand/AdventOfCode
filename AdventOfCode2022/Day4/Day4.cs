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

            IO.WriteOutput(day, "a", result);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArray(day, "a");

            int result = input.Where(x =>
                (int.Parse(x.Split(',')[0].Split('-')[0]) >= int.Parse(x.Split(',')[1].Split('-')[0]) &&
                int.Parse(x.Split(',')[0].Split('-')[0]) <= int.Parse(x.Split(',')[1].Split('-')[1])) ||

                (int.Parse(x.Split(',')[0].Split('-')[1]) >= int.Parse(x.Split(',')[1].Split('-')[0]) &&
                int.Parse(x.Split(',')[0].Split('-')[1]) <= int.Parse(x.Split(',')[1].Split('-')[1])) ||

                (int.Parse(x.Split(',')[1].Split('-')[0]) >= int.Parse(x.Split(',')[0].Split('-')[0]) &&
                int.Parse(x.Split(',')[1].Split('-')[0]) <= int.Parse(x.Split(',')[0].Split('-')[1])) ||

                (int.Parse(x.Split(',')[1].Split('-')[1]) >= int.Parse(x.Split(',')[0].Split('-')[0]) &&
                int.Parse(x.Split(',')[1].Split('-')[1]) <= int.Parse(x.Split(',')[0].Split('-')[0])) 
                ).Count();

            IO.WriteOutput(day, "b", result);
        }
    }
}
