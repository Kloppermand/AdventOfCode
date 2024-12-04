using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Utilities;

namespace AdventOfCode2024.Day3
{
    public static class Day3
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileString(day, "a");

            int result = new Regex("mul\\((?<a>\\d{1,3}),(?<b>\\d{1,3})\\)").Matches(input).Sum(match => int.Parse(match.Groups["a"].Value) * int.Parse(match.Groups["b"].Value));

            IO.WriteOutput(day, "a", result);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileString(day, "a");
            // Oneliner not quite working
            //var result = new Regex("(?<ignore>don't\\(\\).*?(do\\(\\)|$))|mul\\((?<a>\\d{1,3}),(?<b>\\d{1,3})\\)").Matches(input).Where(match => !match.Groups["ignore"].Success).Sum(match => int.Parse(match.Groups["a"].Value) * int.Parse(match.Groups["b"].Value));

            int result = 0;

            Regex regex = new Regex("mul\\((?<a>\\d{1,3}),(?<b>\\d{1,3})\\)|do\\(\\)|don't\\(\\)");
            MatchCollection matches = regex.Matches(input);

            bool doIt = true;
            foreach (Match match in matches)
            {
                if (match.Value.StartsWith("do"))
                    doIt = match.Value == "do()";
                else if (doIt)
                    result += int.Parse(match.Groups["a"].Value) * int.Parse(match.Groups["b"].Value);
            }

            IO.WriteOutput(day, "b", 00);
        }
    }
}
