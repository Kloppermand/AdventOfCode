using System.Collections.Generic;
using System.Linq;
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
            var bags = MakeBagStructure(rules);
            
            IO.WriteOutput(day, "a", bags.Count(x => x.CanContainShinyGold).ToString());
        }
        public static void CalculateB()
        {
            var rules = IO.ReadInputFileStringArray(day, "a");
            var bags = MakeBagStructure(rules);

            IO.WriteOutput(day, "b", bags.Where(x => x.Color.Equals("shiny gold")).First().GetTotalAmount().ToString());
        }

        private static List<Bag> MakeBagStructure(string[] rules)
        {
            List<Bag> bags = new();
            foreach (var rule in rules)
            {
                Bag bag = new();
                bag.ParseBag(rule);
                bags.Add(bag);
            }

            foreach (var bag in bags)
            {
                bag.AddContained(bags);
            }
            return bags;
        }
    }
}
