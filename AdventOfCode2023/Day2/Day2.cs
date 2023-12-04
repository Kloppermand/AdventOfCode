using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2023.Day2
{
    public static class Day2
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            int res = 0;
            foreach (var game in input)
            {
                var gameDef = game.Split(": ");
                var draws = gameDef[1].Split("; ");
                bool failed = false;
                foreach (var draw in draws)
                {
                    var cubes = draw.Split(", ");
                    foreach (var cube in cubes)
                    {
                        var separateCubes = cube.Split(" ");
                        var num = int.Parse(separateCubes[0]);
                        var col = separateCubes[1];

                        if (col == "red" && num > 12)
                        {
                            failed = true;
                            break;
                        }

                        if (col == "green" && num > 13)
                        {
                            failed = true;
                            break;
                        }
                        if (col == "blue" && num > 14)
                        {
                            failed = true;
                            break;
                        }
                    }
                    if (failed)
                        break;
                }

                if (!failed)
                    res += int.Parse(gameDef[0].Split(" ")[1]);

            }

            IO.WriteOutput(day, "a", res);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            var result = 0;
            foreach (var game in input)
            {
                var gameDef = game.Split(": ");
                var draws = gameDef[1].Split("; ");
                int red = 0;
                int green = 0;
                int blue = 0;
                foreach (var draw in draws)
                {
                    var cubes = draw.Split(", ");
                    foreach (var cube in cubes)
                    {
                        var separateCubes = cube.Split(" ");
                        var num = int.Parse(separateCubes[0]);
                        var col = separateCubes[1];

                        if (col == "red" && num > red)
                            red = num;

                        if (col == "green" && num > green)
                            green = num;

                        if (col == "blue" && num > blue)
                            blue = num;
                    }
                }
                result += red * green * blue;
            }
            IO.WriteOutput(day, "b", result);
        }
    }
}
