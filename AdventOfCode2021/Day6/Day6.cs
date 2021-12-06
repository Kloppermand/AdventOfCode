using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2021.Day6
{
    public static class Day6
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileIntArraySingleLine(day, "a");

            var timers = GroupFishSchools(input);
            SimulateDays(ref timers, 80);
            
            IO.WriteOutput(day, "a", timers.Sum().ToString());
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileIntArraySingleLine(day, "a");

            var timers = GroupFishSchools(input);
            SimulateDays(ref timers, 256);

            IO.WriteOutput(day, "b", timers.Sum().ToString());
        }

        private static long[] GroupFishSchools(int[] fish)
        {
            var timers = new long[9];
            for (int i = 0; i < 9; i++)
            {
                timers[i] = fish.Count(x => x == i);
            }
            return timers;
        }

        private static void SimulateDays(ref long[] timers, int days)
        {
            for (int i = 0; i < days; i++)
            {
                Tick(ref timers);
            }
        }
        private static void Tick(ref long[] timers)
        {
            long toBeBorn = timers[0];
            for (int i = 0; i < timers.Length-1; i++)
            {
                timers[i] = timers[i + 1];
            }
            timers[6] += toBeBorn;
            timers[8] = toBeBorn;
        }
    }
}
