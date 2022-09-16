using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2018.Day1
{
    public static class Day1
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringArray(day, "a");

            int tot = 0;
            foreach (var item in input)
            {
                tot += int.Parse(item.Replace("+", ""));
            }

            IO.WriteOutput(day, "a", tot.ToString());
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArray(day, "a");

            int tot = 0;
            List<int> reached = new();
            int index = 0;

            while(true)
            {
                tot += int.Parse(input[index].Replace("+", ""));
                if (reached.Contains(tot)) break;
                reached.Add(tot);

                index = (index + 1) % input.Length;
            }

            IO.WriteOutput(day, "b", tot.ToString());
        }
    }
}
