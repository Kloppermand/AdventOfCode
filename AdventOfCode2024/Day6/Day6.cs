using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2024.Day6
{
    public static class Day6
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;
        static HashSet<(int, int)> visited_A = new();

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            var dir = (-1, 0);
            Dictionary<(int, int), (int, int)> dirChange = new() { { (-1, 0), (0, 1) }, { (0, 1), (1, 0) }, { (1, 0), (0, -1) }, { (0, -1), (-1, 0) } };
            (int, int) pos = (0, 0);

            int h = input.Length;
            int w = input[0].Length;

            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    if (input[i][j] == '^')
                        pos = (i, j);
                }
            }

            while (true)
            {
                visited_A.Add(pos);
                var look = (pos.Item1 + dir.Item1, pos.Item2 + dir.Item2);
                if (look.Item1 < 0 || look.Item1 >= h || look.Item2 < 0 || look.Item2 >= w)
                    break;

                if (input[look.Item1][look.Item2] != '#')
                    pos = look;
                else
                    dir = dirChange[dir];
            }

            IO.WriteOutput(day, "a", visited_A.Count);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            var dir = (-1, 0);
            Dictionary<(int, int), (int, int)> dirChange = new() { { (-1, 0), (0, 1) }, { (0, 1), (1, 0) }, { (1, 0), (0, -1) }, { (0, -1), (-1, 0) } };
            (int, int) originalPos = (0, 0);
            int loops = 0;

            int h = input.Length;
            int w = input[0].Length;

            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    if (input[i][j] == '^')
                        originalPos = (i, j);
                }
            }

            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    if (input[i][j] == '#' || !visited_A.Contains((i,j)))
                        continue;

                    HashSet<((int, int), (int, int))> visited = new();
                    (int, int) pos = originalPos;
                    dir = (-1, 0);
                    while (true)
                    {
                        if (visited.Contains((pos, dir)))
                        {
                            loops++;
                            break;
                        }
                        visited.Add((pos, dir));
                        var look = (pos.Item1 + dir.Item1, pos.Item2 + dir.Item2);
                        if (look.Item1 < 0 || look.Item1 >= h || look.Item2 < 0 || look.Item2 >= w)
                            break;

                        if (input[look.Item1][look.Item2] == '#' || look == (i,j))
                            dir = dirChange[dir];
                        else
                            pos = look;
                    }

                }
            }


            IO.WriteOutput(day, "b", loops);
        }
    }
}
