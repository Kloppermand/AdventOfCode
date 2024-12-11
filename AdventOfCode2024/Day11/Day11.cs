using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2024.Day11
{
    public static class Day11
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileString(day, "a");
            long result = RunStoneSimulation(input, 25);

            IO.WriteOutput(day, "a", result);
        }

        public static void CalculateB()
        {
            var input = IO.ReadInputFileString(day, "a");
            long result = RunStoneSimulation(input, 75);

            IO.WriteOutput(day, "b", result);
        }

        private static long RunStoneSimulation(string input, int iterations)
        {
            Dictionary<long, long> numbers = new();

            foreach (var value in input.Split(" "))
            {
                long num = long.Parse(value);
                if (!numbers.ContainsKey(num))
                    numbers.Add(num, 0);

                numbers[num]++;
            }

            for (int i = 0; i < iterations; i++)
            {
                Dictionary<long, long> tmp = new(numbers);
                foreach (var value in tmp)
                {
                    string str = value.Key.ToString();

                    if (value.Key == 0)
                    {
                        numbers[0] -= value.Value;

                        if (!numbers.ContainsKey(1))
                            numbers.Add(1, 0);

                        numbers[1] += value.Value;
                    }
                    else if (str.Length % 2 == 0)
                    {
                        var num1 = long.Parse(str.Substring(0, str.Length / 2));
                        var num2 = long.Parse(str.Substring(str.Length / 2));

                        if (!numbers.ContainsKey(num1))
                            numbers.Add(num1, 0);
                        numbers[num1] += value.Value;

                        if (!numbers.ContainsKey(num2))
                            numbers.Add(num2, 0);
                        numbers[num2] += value.Value;

                        numbers[value.Key] -= value.Value;
                    }
                    else
                    {
                        numbers[value.Key] -= value.Value;
                        if (!numbers.ContainsKey(value.Key * 2024))
                            numbers.Add(value.Key * 2024, 0);

                        numbers[value.Key * 2024] += value.Value;
                    }
                }
            }

            long result = numbers.Sum(s => s.Value);
            return result;
        }

    }
}
