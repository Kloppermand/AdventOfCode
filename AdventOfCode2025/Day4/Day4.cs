using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2025.Day4
{
    public static class Day4
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            int result = 0;

            for (int y = 0; y < input.Length; y++)
            {
                for (int x = 0; x < input[y].Length; x++)
                {
                    if (input[y][x] == '@' && Neighbours.CountNeighbours8(x, y, input, '@') < 4)
                        result++;
                }
            }

            IO.WriteOutput(day, "a", result);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArray(day, "a");

            int result = 0;
            bool changed = true;
            while (changed)
            {
            var nextIter = new string[input.Length];
                changed = false;
                for (int y = 0; y < input.Length; y++)
                {
                    for (int x = 0; x < input[y].Length; x++)
                    {
                        if (input[y][x] == '@' && Neighbours.CountNeighbours8(x, y, input, '@') < 4)
                        {
                            changed = true;
                            result++;
                            nextIter[y] += '.';
                        }
                        else
                            nextIter[y] += input[y][x];
                    }
                }
                nextIter.CopyTo(input, 0);
            }

            IO.WriteOutput(day, "b", result);
        }
    }
}
