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
            string seed = input[0];

            // Make map
            var map = new Dictionary<string, string>();
            foreach (var pair in input[2..])
            {
                map.Add(pair[0..2], pair[6].ToString());
            }

            // Populate pairs
            var pairs = new Dictionary<string, long>();
            foreach (var pair in map)
            {
                pairs.Add(pair.Key, 0);
            }

            // Set pairs values from input seed
            for (var i = 1;i < seed.Length; i++)
            {
                pairs[seed.Substring(i - 1, 2)]++;
            }

            // Run insertion
            for (var i = 0;i < 40; i++) 
            {
                // Populate tmpPairs
                var tmpPairs = new Dictionary<string, long>();
                foreach (var pair in map)
                {
                    tmpPairs.Add(pair.Key, 0);
                }

                foreach (var pair in pairs)
                {
                    tmpPairs[pair.Key.Substring(0, 1) + map[pair.Key]] += pair.Value;
                    tmpPairs[map[pair.Key] + pair.Key.Substring(1, 1)] += pair.Value;
                }

                pairs = tmpPairs.ToDictionary(x => x.Key, x => x.Value);
            }

            // Get element frequency
            var freq = new Dictionary<char, long>();
            foreach(var pair in pairs)
            {
                freq.TryAdd(pair.Key[0], 0);
                freq.TryAdd(pair.Key[1], 0);

                freq[pair.Key[0]] += pair.Value;
                freq[pair.Key[1]] += pair.Value;
            }
            // Adjust for start/end element, and half due to double counting
            freq[seed[0]]++;
            freq[seed[^1]]++;
            foreach (var c in freq)
                freq[c.Key] /= 2;

            string result = (freq.Max(x => x.Value) - freq.Min(x => x.Value)).ToString();
            IO.WriteOutput(day, "b", result);
        }
    }
}
