using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2022.Day11
{
    public static class Day11
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringArrayBlankLineKeepInternalLineBreaks(day, "a");
            Dictionary<int, Monkey> monkeys = new();
            int rounds = 20;

            foreach (var monkey in input)
            {
                Monkey tmp = new(monkey);
                monkeys.Add(tmp.Id, tmp);
            }

            for (int i = 1; i <= rounds; i++)
            {
                foreach (var monkey in monkeys.Values)
                {
                    while (monkey.Items.Count() > 0)
                    {
                        var item = monkey.Items.First();
                        var (target, worry) = monkey.GetItemTarget(item);
                        monkey.Items.Remove(item);
                        monkeys[target].Items.Add(worry);
                    }
                }
            }

            var mostActive = monkeys.OrderByDescending(x => x.Value.InspectedItems).Take(2);
            var result = mostActive.First().Value.InspectedItems * mostActive.Last().Value.InspectedItems;

            IO.WriteOutput(day, "a", result);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArrayBlankLineKeepInternalLineBreaks(day, "a");
            Dictionary<int, Monkey> monkeys = new();
            int rounds = 10000;

            foreach (var monkey in input)
            {
                Monkey tmp = new(monkey);
                monkeys.Add(tmp.Id, tmp);
            }
            int mod = 1;
            foreach (int div in monkeys.Values.Select(x => x.DivisibilityTest))
                mod *= div;

            for (int i = 1; i <= rounds; i++)
            {
                foreach (var monkey in monkeys.Values)
                {
                    while (monkey.Items.Count() > 0)
                    {
                        var item = monkey.Items.First();
                        var (target, worry) = monkey.GetItemTargetVeryWorried(item,mod);
                        monkey.Items.Remove(item);
                        monkeys[target].Items.Add(worry);
                    }
                }
            }

            var mostActive = monkeys.OrderByDescending(x => x.Value.InspectedItems).Take(2);
            var result = (long)mostActive.First().Value.InspectedItems * (long)mostActive.Last().Value.InspectedItems;

            IO.WriteOutput(day, "b", string.Join('\n', result));
        }
    }
}
