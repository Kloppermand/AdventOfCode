using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2024.Day5
{
    public static class Day5
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;
        private static Graph<string> ruleGraph;
        public static void CalculateA()
        {
            var input = IO.ReadInputFileString(day, "a");

            var input2 = input.Split("\n\n");
            var rules = input2.First().Split("\n");
            int result = 0;
            ruleGraph = CreateGraph(rules);

            foreach (var manual in input2.Last().Split("\n"))
            {
                bool valid = true;
                var pages = manual.Split(",");
                for (int i = 0; i < pages.Length - 1; i++)
                {
                    if (IsPageBefore(pages[i],pages[i + 1]))
                    {
                        valid = false;
                        break;
                    }
                }
                if (valid)
                    result += int.Parse(pages.ElementAt(pages.Length / 2));
            }

            IO.WriteOutput(day, "a", result);
        }

        public static void CalculateB()
        {
            var input = IO.ReadInputFileString(day, "a");

            var input2 = input.Split("\n\n");
            var rules = input2.First().Split("\n");
            int result = 0;
            ruleGraph = CreateGraph(rules);

            foreach (var manual in input2.Last().Split("\n"))
            {
                bool valid = true;
                var pages = manual.Split(",");
                for (int i = 0; i < pages.Length - 1; i++)
                {
                    if (IsPageBefore(pages[i], pages[i + 1]))
                    {
                        valid = false;
                        break;
                    }
                }
                if (!valid)
                {
                    var newPages = pages.ToList();
                    newPages.Sort(ComparePages);
                    result += int.Parse(newPages.ElementAt(newPages.Count() / 2));
                }
            }

            IO.WriteOutput(day, "b", result);
        }

        private static Graph<string> CreateGraph(string[] rules)
        {
            Graph<string> ruleGraph = new();

            foreach (var rule in rules)
            {
                var ruleSplit = rule.Split("|");
                ruleGraph.AddDirectedEdge_Force(new(ruleSplit.First(), ruleSplit.Last()));
            }

            return ruleGraph;
        }

        private static bool IsPageBefore(string left, string right) 
        {
            return !ruleGraph.PointsTo(left, right);
        }

        private static int ComparePages(string left, string right)
        {
            if (left == right)
            {
                return 0;
            }
            else if (IsPageBefore(left, right))
            {
                return -1;
            }
            else if (IsPageBefore(right, left))
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }
    }
}
