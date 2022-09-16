using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2021.Day14
{
    public static class Day14
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            var polymer = new Polymer(input);
            polymer.StepMultiple(10);

            var groups = polymer.Value.GroupBy(i => i).OrderByDescending(grp => grp.Count());
            var high = groups.Select(grp => grp.Count()).First();
            var low = groups.Select(grp => grp.Count()).Last();

            string result = (high - low).ToString();
            IO.WriteOutput(day, "a", result);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArray(day, "a");



            string result = "NOT SOLVED YET";
            IO.WriteOutput(day, "b", result);
        }
    }
}
