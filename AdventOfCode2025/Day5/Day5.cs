using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2025.Day5
{
    public static class Day5
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringRaw(day, "a");
            var tmp = input.Split("\n\n");
            var ranges = tmp[0].Split("\n").Select(r => new LongRange(r));
            var ids = tmp[1].Trim().Split("\n").Select(id => long.Parse(id));

            int result = 0;

            foreach(var id in ids)
            {
                if (ranges.Any(r => r.IsInRange(id)))
                    result++;
            }

            IO.WriteOutput(day, "a", result);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringRaw(day, "a");
            var tmp = input.Split("\n\n");
            var ranges = tmp[0].Split("\n").Select(r => new LongRange(r)).ToList();
            var newRanges = new List<LongRange>();

            while (ranges.Count > 0)
            {
                var current = ranges.First();
                var compatible = ranges.FirstOrDefault(r => r.CanMerge(current) && r != current);
                if (compatible == null)
                {
                    newRanges.Add(current);
                    ranges.Remove(current);
                    continue;
                }

                ranges.Add(current.Merge(compatible));
                ranges.Remove(current);
                ranges.Remove(compatible);
            }

            var result = newRanges.Sum(r => r.Length);

            IO.WriteOutput(day, "b", result);
        }
    }
}
