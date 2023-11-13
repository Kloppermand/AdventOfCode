using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2019.Day3
{
    public static class Day3
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringArray(day, "a");

            var wire1 = new Wire(input[0]);
            var wire2 = new Wire(input[1]);

            var overlap = wire1.Visits.Intersect(wire2.Visits);
            var origin = new Point();

            var result = overlap.Min(p => p.CityBlockDistance(origin));
            IO.WriteOutput(day, "a", result);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArray(day, "a");

            var wire1 = new Wire(input[0]);
            var wire2 = new Wire(input[1]);

            var overlap = wire1.Visits.Intersect(wire2.Visits);
            var origin = new Point();

            var result = overlap.Min(p => wire1.StepsToPoint(p) + wire2.StepsToPoint(p));

            IO.WriteOutput(day, "b", result);
        }
    }
}
