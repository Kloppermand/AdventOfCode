using System.Collections.Generic;
using System.Reflection;
using Utilities;

namespace AdventOfCode2020.Day7
{
    public static class Day7
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var rules = IO.ReadInputFileStringArray(day, "a");

            List<Bag> bags = new();
            foreach (var rule in rules)
            {
                Bag bag = new();
                bag.ParseBag(rule);
                bags.Add(bag);
            }


            string result = "";
            IO.WriteOutput(day, "a", result);
        }
        public static void CalculateB()
        {
            var commands = IO.ReadInputFileStringArray(day, "a");



            string result = "";
            IO.WriteOutput(day, "b", result);
        }
    }
}
