using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2021.Day13
{
    public static class Day13
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileString(day, "a");

            Paper paper = new Paper(input);
            paper.Fold(paper.Folds.First());
            paper.RemoveDuplicates();

            string result = paper.Points.Count.ToString();
            IO.WriteOutput(day, "a", result);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileString(day, "a");

            Paper paper = new Paper(input);
            foreach (var fold in paper.Folds)
            {
                paper.Fold(fold);
            }
            paper.RemoveDuplicates();
            

            string result = paper.ToString();
            IO.WriteOutput(day, "b", result);
        }
    }
}
