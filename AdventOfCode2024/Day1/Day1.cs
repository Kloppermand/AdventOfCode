using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2024.Day1
{
    public static class Day1
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            List<int> list1, list2;
            SetupLists(input, out list1, out list2);

            int result = 0;

            for (int i = 0; i < list1.Count; i++)
            {
                result += Math.Abs(list1[i] - list2[i]);
            }

            IO.WriteOutput(day, "a", result);
        }

        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            List<int> list1, list2;
            SetupLists(input, out list1, out list2);

            int result = 0;

            foreach (int num in list1) 
            {
                result += num * list2.Count(x => x == num);
            }

            IO.WriteOutput(day, "b", result);
        }

        private static void SetupLists(string[] input, out List<int> list1, out List<int> list2)
        {
            list1 = new();
            list2 = new();
            foreach (var row in input)
            {
                var tmp = row.Split("   ");
                list1.Add(int.Parse(tmp.First()));
                list2.Add(int.Parse(tmp.Last()));
            }

            list1.Sort();
            list2.Sort();
        }
    }
}
