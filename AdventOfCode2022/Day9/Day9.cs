using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2022.Day9
{
    public static class Day9
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            Rope rope = new(2);

            foreach (var item in input)
            {
                var move = item.Split(' ');
                rope.UpdateRope(move[0], int.Parse(move[1]));
            }

            IO.WriteOutput(day, "a", rope.GetUniqueVisitCount());
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            Rope rope = new(10);

            foreach (var item in input)
            {
                var move = item.Split(' ');
                rope.UpdateRope(move[0], int.Parse(move[1]));
            }

            IO.WriteOutput(day, "b", rope.GetUniqueVisitCount());
        }
    }
}
