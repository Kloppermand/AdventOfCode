using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2021.Day8
{
    public static class Day8
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            List<string> uniqueLengthOutputs = new();
            foreach (var row in input)
            {
                foreach (var digit in row.Split(" | ")[1].Split(' '))
                {
                    if (digit.Length == 2 || digit.Length == 3 || digit.Length == 4 || digit.Length == 7)
                        uniqueLengthOutputs.Add(digit);

                }
            }

            IO.WriteOutput(day, "a", uniqueLengthOutputs.Count.ToString());
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            int result = 0;
            foreach (var row in input)
            {
                var clues = row.Split(" | ")[0].Split(' ');
                var one = clues.Where(x => x.Length == 2).First();
                var seven = clues.Where(x => x.Length == 3).First();
                var four = clues.Where(x => x.Length == 4).First();
                var eight = clues.Where(x => x.Length == 7).First();
                var three = clues.Where(x => x.Length == 5 && x.Contains(one[0]) && x.Contains(one[1])).First();
                var six = clues.Where(x => x.Length == 6 && !(x.Contains(one[0]) && x.Contains(one[1]))).First();
                var nine = clues.Where(x => x.Length == 6 && x.Contains(three[0]) && x.Contains(three[1]) && x.Contains(three[2]) && x.Contains(three[3]) && x.Contains(three[4])).First();
                var bd = four.Replace(one[0].ToString(), "").Replace(one[1].ToString(), "");
                var five = clues.Where(x => x.Length == 5 && x.Contains(bd[0]) && x.Contains(bd[1])).First();
                var two = clues.Where(x => x.Length == 5 && !x.Equals(three) && !x.Equals(five)).First();
                var zero = clues.Where(x => x.Length == 6 && !x.Equals(six) && !x.Equals(nine)).First();

                Dictionary<string, int> trans = new();
                trans.Add(SortString(zero), 0);
                trans.Add(SortString(one), 1);
                trans.Add(SortString(two), 2);
                trans.Add(SortString(three), 3);
                trans.Add(SortString(four), 4);
                trans.Add(SortString(five), 5);
                trans.Add(SortString(six), 6);
                trans.Add(SortString(seven), 7);
                trans.Add(SortString(eight), 8);
                trans.Add(SortString(nine), 9);

                var values = row.Split(" | ")[1].Split(' ');
                for (int i = 0; i < values.Length; i++)
                {
                    result += (int)Math.Pow(10, values.Length - i - 1) * trans[SortString(values[i])];
                }

            }

            IO.WriteOutput(day, "b", result.ToString());
        }

        private static string SortString(string raw)
        {
            char[] charArr = raw.ToCharArray();
            Array.Sort(charArr);
            return new string(charArr);
        }

    }
}
