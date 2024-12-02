using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2024.Day2
{
    public static class Day2
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            int result = 0;

            foreach (var row in input)
            {
                var nums = row.Split(" ").Select(x => int.Parse(x));
                if (IsReportSafe(nums))
                    result++;
            }


            IO.WriteOutput(day, "a", result);
        }

        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            int result = 0;

            foreach (var row in input)
            {
                var nums = row.Split(" ").Select(x => int.Parse(x));
                var dir = nums.First() > nums.ElementAt(1);
                var valid = false;

                for (int i = 0; i < nums.Count(); i++)
                {
                    var tmpNums = nums.Take(i);
                    foreach (var tmpNum in nums.TakeLast(nums.Count() - 1 - i))
                    {
                        tmpNums = tmpNums.Append(tmpNum);
                    }

                    if (IsReportSafe(tmpNums))
                        valid = true;
                }

                if (valid)
                    result++;
            }

            IO.WriteOutput(day, "b", result);
        }

        private static bool IsReportSafe(IEnumerable<int> nums)
        {
            var dir = nums.First() > nums.ElementAt(1);
            var valid = true;

            for (int i = 0; i < nums.Count() - 1; i++)
            {
                if (nums.ElementAt(i) == nums.ElementAt(i + 1)) // No change
                {
                    valid = false;
                    continue;
                }

                if (Math.Abs(nums.ElementAt(i) - nums.ElementAt(i + 1)) > 3) // Change more than 3
                {
                    valid = false;
                    continue;
                }

                if (nums.ElementAt(i) > nums.ElementAt(i + 1) != dir) // Changed direction
                {
                    valid = false;
                    continue;
                }
            }

            return valid;
        }
    }
}
