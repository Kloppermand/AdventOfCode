using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2024.Day7
{
    public static class Day7
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            long result = 0;

            foreach (var item in input)
            {
                var eq = new Equation(item);
                if (eq.MatchTarget1())
                    result += eq.result;
            }

            IO.WriteOutput(day, "a", result);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            long result = 0;

            foreach (var item in input)
            {
                var eq = new Equation(item);
                if (eq.MatchTarget2())
                    result += eq.result;
            }

            IO.WriteOutput(day, "b", result);
        }
    }

    public class Equation
    {
        public long result { get; set; }
        public IEnumerable<long> values { get; set; }
        public Equation(string input)
        {
            var tmp = input.Split(":");
            result = long.Parse(tmp.First());
            values = tmp.Last().Trim().Split(" ").Select(x => long.Parse(x));
        }

        public List<long> Combine1(long num1, long num2)
        {
            var lst = new List<long>();
            long sum = num1 + num2;
            long product = num1 * num2;

            if (sum <= result)
                lst.Add(sum);

            if (product <= result)
                lst.Add(product);

            return lst;
        }

        public List<long> Combine2(long num1, long num2)
        {
            var lst = new List<long>();
            long sum = num1 + num2;
            long product = num1 * num2;
            long concat = long.Parse(num1.ToString() + num2.ToString());

            if (sum <= result)
                lst.Add(sum);

            if (product <= result)
                lst.Add(product);

            if (concat <= result)
                lst.Add(concat);

            return lst;
        }

        public bool MatchTarget1()
        {
            List<long> results = new() { values.First()};
            for (int i = 1; i < values.Count(); i++)
            {
                List<long> tmpResults = new();
                foreach (long value in results)
                {
                    tmpResults.AddRange(Combine1(value, values.ElementAt(i)));
                }
                results = tmpResults;
            }
            return results.Contains(result);
        }

        public bool MatchTarget2() 
        {
            List<long> results = new() { values.First() };
            for (int i = 1; i < values.Count(); i++)
            {
                List<long> tmpResults = new();
                foreach (long value in results)
                {
                    tmpResults.AddRange(Combine2(value, values.ElementAt(i)));
                }
                results = tmpResults;
            }
            return results.Contains(result);
        }
    }
}
