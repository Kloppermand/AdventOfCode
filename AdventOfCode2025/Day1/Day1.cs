using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using Utilities;

namespace AdventOfCode2025.Day1
{
    public static class Day1
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringArray(day, "a");

            var turns = input.Select(t => t[0] == 'L' ? -int.Parse(t[1..]) : int.Parse(t[1..]));

            int pointer = 50;
            int result = 0;

            foreach (var turn in turns)
            {
                pointer = (pointer + turn) % 100;
                if (pointer == 0)
                    result++;
            }

            IO.WriteOutput(day, "a", result);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArray(day, "a");

            var turns = input.Select(t => t[0] == 'L' ? -int.Parse(t[1..]) : int.Parse(t[1..]));

            int pointer = 50;
            int result = 0;

            foreach (var turn in turns)
            {
                var old = pointer;
                pointer += turn;
                if (pointer < 1)
                {
                    result += Math.Abs(pointer) / 100 + (old != 0 ? 1 : 0);
                }
                if(pointer > 99)
                    result += pointer / 100;

                pointer = (10000 + pointer)%100;
            }

            IO.WriteOutput(day, "b", result);
        }
    }
}
