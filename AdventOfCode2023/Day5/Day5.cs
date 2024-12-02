using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2023.Day5
{
    public static class Day5
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringArrayBlankLineKeepInternalLineBreaks(day, "a");

            var seeds = input[0].Split(": ")[1].Split().Select(s => long.Parse(s));

            var maps = new List<Map>();

            foreach (var map in input[1..])
            {
                maps.Add(new Map(map.Split("\n")[1..]));
            }

            var locations = new List<long>();

            foreach (var seed in seeds)
            {
                var tmpSeed = seed;
                foreach (var map in maps)
                {
                    tmpSeed = map.Apply(tmpSeed);
                }
                locations.Add(tmpSeed);
            }

            IO.WriteOutput(day, "a", locations.Min());
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArrayBlankLineKeepInternalLineBreaks(day, "test");

            var seeds = input[0].Split(": ")[1].Split().Select(s => long.Parse(s));

            var maps = new List<Map>();

            foreach (var map in input[1..])
            {
                maps.Add(new Map(map.Split("\n")[1..]));
            }

            var locations = new List<Range>();

            var tmpSeed = seeds.Chunk(2).Select(s => new Range {RangeStart = s.First(), RangeLength = s.Last() });
            foreach (var map in maps)
            {
                var nextSeeds = new List<Range>();
                foreach (var seed in tmpSeed)
                {
                    nextSeeds.AddRange(map.ApplyRange(seed));
                }
                tmpSeed = nextSeeds;
            }
            locations.AddRange(tmpSeed);

            string result = "NOT SOLVED YET";
            IO.WriteOutput(day, "b", result);
        }
    }
}
