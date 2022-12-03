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
            string priorties = "¤abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int result = 0;

            foreach (var rucksack in input)
            {
                int middle = rucksack.Length/2;
                string compartment1 = rucksack[..middle];
                string compartment2 = rucksack[middle..];
                char common = compartment1.Intersect(compartment2).FirstOrDefault();
                result += priorties.IndexOf(common);
            }

            IO.WriteOutput(day, "a", result);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            string priorties = "¤abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int result = 0;

            for (int i = 0; i < input.Length/3; i++)
            {
                char common = input[i*3].Intersect(input[i*3+1]).Intersect(input[i * 3 + 2]).FirstOrDefault();
                result += priorties.IndexOf(common);
            }

            IO.WriteOutput(day, "b", result);
        }
    }
}
