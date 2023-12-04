using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;
using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day1
{
    public static class Day1
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringArray(day, "a");

            var result = input.Sum(s => int.Parse(s.First(c => c >= '0' && c <= '9').ToString() + s.Last(c => c >= '0' && c <= '9').ToString()));

            IO.WriteOutput(day, "a", result);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArray(day, "a");

            var result = input.Select(s => new Regex(@"(?=(\d|one|two|three|four|five|six|seven|eight|nine))").Matches(s)).Sum(m => int.Parse((m.First().Groups[1].Value + m.Last().Groups[1].Value).Replace("one", "1").Replace("two", "2").Replace("three", "3").Replace("four", "4").Replace("five", "5").Replace("six", "6").Replace("seven", "7").Replace("eight", "8").Replace("nine", "9")));
            //var oldResult = input.Sum(s => int.Parse(s.Replace("one", "one1one").Replace("two", "two2two").Replace("three", "three3three").Replace("four", "four4four").Replace("five", "five5five").Replace("six", "six6six").Replace("seven", "seven7seven").Replace("eight", "eight8eight").Replace("nine", "nine9nine").First(c => c >= '0' && c <= '9').ToString() + s.Replace("one", "one1one").Replace("two", "two2two").Replace("three", "three3three").Replace("four", "four4four").Replace("five", "five5five").Replace("six", "six6six").Replace("seven", "seven7seven").Replace("eight", "eight8eight").Replace("nine", "nine9nine").Last(c => c >= '0' && c <= '9').ToString()));

            IO.WriteOutput(day, "b", result);
        }
    }
}
