using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2018.Day5
{
    public static class Day5
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var polymer = IO.ReadInputFileString(day, "a");
            int length;
            do
            {
                length = polymer.Length;
                polymer = ReducePolymer(polymer);
            } while (length > polymer.Length);

            IO.WriteOutput(day, "a", length);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileString(day, "a");
            var units = input.ToLower().Distinct();
            var best = new Tuple<char, int>(' ', input.Length);
            foreach (var unit in units)
            {
                var polymer = input.Replace(unit.ToString(), "").Replace(unit.ToString().ToUpper(), "");
                int length;
                do
                {
                    length = polymer.Length;
                    polymer = ReducePolymer(polymer);
                } while (length > polymer.Length);

                if (length < best.Item2)
                    best = new Tuple<char, int>(unit, length);
            }

            IO.WriteOutput(day, "b", best.Item2);
        }

        private static string ReducePolymer(string polymer)
        {
            List<int> remove = new();
            for (int i = 0; i < polymer.Length - 1; i++)
            {
                if (Math.Abs(polymer[i] - polymer[i + 1]) == 32)
                {
                    remove.Add(i);
                    i++;
                }

            }

            remove.Reverse();
            foreach (int index in remove)
            {
                polymer = polymer.Remove(index, 2);
            }

            return polymer;
        }
    }
}
