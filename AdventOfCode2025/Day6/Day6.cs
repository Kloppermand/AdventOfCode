using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Utilities;

namespace AdventOfCode2025.Day6
{
    public static class Day6
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            var matches = new List<List<string>>();
            long result = 0;

            foreach (var row in input)
            {
                var tmp = new List<string>();
                foreach (var item in Regex.Matches(row, "[1-9*\\+]+"))
                {
                    tmp.Add(item.ToString());
                }
                matches.Add(tmp);
            }

            for (int i = 0; i < matches[0].Count(); i++)
            {
                long tmp;
                if (matches.Last()[i] == "*")
                    tmp = 1;
                else
                    tmp = 0;

                for (int j = 0; j < matches.Count() - 1; j++)
                {
                    if (matches.Last()[i] == "*")
                        tmp *= long.Parse(matches[j][i]);
                    else
                        tmp += long.Parse(matches[j][i]);
                }
                result += tmp;
            }

            IO.WriteOutput(day, "a", result);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            var transposed = new List<string>();
            long result = 0;

            for (int i = 0; i < input[0].Count(); i++)
            {
                string tmp = "";
                transposed.Add(input.Last()[i].ToString());

                for (int j = 0; j < input.Count() - 1; j++)
                {
                    tmp += input[j][i];
                }
                transposed.Add(tmp);
            }

            string op = "+";
            long tmpNum = 0;

            foreach (var item in transposed)
            {
                if (string.IsNullOrWhiteSpace(item))
                    continue;
                if (item == "+")
                {
                    result += tmpNum;
                    op = item;
                    tmpNum = 0;
                    continue;
                }
                if (item == "*")
                {
                    result += tmpNum;
                    op = item;
                    tmpNum = 1;
                    continue;
                }

                if(op == "+")
                {
                    tmpNum += long.Parse(item);
                    continue;
                }    

                if(op == "*")
                {
                    tmpNum *= long.Parse(item);
                    continue;
                }
            }
            result += tmpNum;
            IO.WriteOutput(day, "b", result);
        }
    }
}
