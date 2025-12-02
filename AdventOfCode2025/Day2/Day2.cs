using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2025.Day2
{
    public static class Day2
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringRaw(day, "a");
            var ranges = input.Split(',').Select(r => new LongRange(r));

            long result = 0;
            foreach (var range in ranges)
            {
                for (long i = range.start; i <= range.end; i++)
                {
                    var tmp = i.ToString();
                    var t1 = tmp.Substring(0, tmp.Length / 2);
                    var t2 = tmp.Substring(tmp.Length / 2);

                    if (t1 == t2)
                        result += i;
                }
            }

            IO.WriteOutput(day, "a", result);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringRaw(day, "a");
            var ranges = input.Split(',').Select(r => new LongRange(r));

            long result = 0;
            foreach (var range in ranges)
            {
                for (long i = range.start; i <= range.end; i++)
                {
                    var tmp = i.ToString();
                    for (int j = 1; j <= tmp.Length / 2; j++)
                    {
                        if (!tmp.Split(tmp.Substring(0, j)).Any(l => !string.IsNullOrEmpty(l)))
                        {
                            result += i;
                            break;
                        }                        
                    }
                }
            }

            IO.WriteOutput(day, "b", result);
        }
    }
}
