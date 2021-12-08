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
            var input = IO.ReadInputFileIntArray(day, "a");
            input = input.Concat(new int[] { 0, input.Max() + 3 }).ToArray();
            Array.Sort(input);
            List<Adapter> adapters = new();
            foreach (var item in input)
            {
                adapters.Add(new Adapter() { Jolts = item });
            }
            adapters[0].WaysToReach = 1;

            for (int i = 1; i < adapters.Count; i++)
            {
                adapters[i].WaysToReach = adapters.Where(x => x.Jolts < adapters[i].Jolts && x.Jolts >= adapters[i].Jolts - 3).Select(x => x.WaysToReach).Sum();
            }


            IO.WriteOutput(day, "b", adapters.Last().WaysToReach.ToString());
        }
    }
}
