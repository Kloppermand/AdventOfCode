using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2022.Day3
{
    public static class Day3
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            /*string priorties = "¤abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int result = 0;

            foreach (var rucksack in input)
            {
                int middle = rucksack.Length/2;
                string compartment1 = rucksack[..middle];
                string compartment2 = rucksack[middle..];
                char common = compartment1.Intersect(compartment2).FirstOrDefault();
                result += priorties.IndexOf(common);
            }*/

            int result = input.Sum(x => "¤abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(x.Substring(0, x.Length / 2).Intersect(x.Substring(x.Length / 2)).FirstOrDefault()));

            IO.WriteOutput(day, "a", result);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArray(day, "a");

            int result = input.Select((x, i) => new { X = x, I = i }).GroupBy(y => y.I / 3).Sum(z => "¤abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(z.ElementAt(0).X.Intersect(z.ElementAt(1).X).Intersect(z.ElementAt(2).X).FirstOrDefault()));

            IO.WriteOutput(day, "b", result);
        }
    }
}
