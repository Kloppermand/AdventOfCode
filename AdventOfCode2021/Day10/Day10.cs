using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2021.Day10
{
    public static class Day10
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            int errorSum = 0;
            Dictionary<char, int> errorValues = new() 
            { 
                { ')', 3 }, 
                { ']', 57 }, 
                { '}', 1197 }, 
                { '>', 25137 } 
            };
            foreach (var row in input)
            {
                string tempRow = row;
                int lastLength = 0;
                while (tempRow.Length != lastLength)
                {
                    lastLength = tempRow.Length;
                    tempRow = tempRow.Replace("()", "").Replace("[]", "").Replace("{}", "").Replace("<>", "");
                }
                string removedStarters = tempRow.Replace("(", "").Replace("[", "").Replace("{", "").Replace("<", "");
                if (removedStarters.Length > 0)
                    errorSum += errorValues[removedStarters[0]];
            }

            IO.WriteOutput(day, "a", errorSum.ToString());
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            List<long> completionScores = new();
            Dictionary<char, int> scores = new()
            {
                { '(', 1 },
                { '[', 2 },
                { '{', 3 },
                { '<', 4 }
            };
            foreach (var row in input)
            {
                string tempRow = row;
                int lastLength = 0;
                long rowScore = 0;
                while (tempRow.Length != lastLength)
                {
                    lastLength = tempRow.Length;
                    tempRow = tempRow.Replace("()", "").Replace("[]", "").Replace("{}", "").Replace("<>", "");
                }
                string removedStarters = tempRow.Replace("(", "").Replace("[", "").Replace("{", "").Replace("<", "");
                if (removedStarters.Length > 0)
                    continue;
                foreach (var token in tempRow.Reverse())
                {
                    rowScore *= 5;
                    rowScore += scores[token];
                }
                completionScores.Add(rowScore);
            }
            completionScores.Sort();

            IO.WriteOutput(day, "b", completionScores[completionScores.Count/2].ToString());
        }
    }
}
