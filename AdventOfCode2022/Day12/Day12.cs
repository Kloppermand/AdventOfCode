using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2022.Day12
{
    public static class Day12
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringArray(day, "a");

            var (start, end, map, _) = GetMap(input);

            var result = map.BFS_ShortestPath(start, end).Count();

            IO.WriteOutput(day, "a", result);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArray(day, "a");

            var (_, end, map, possibleStarts) = GetMap(input);
            int min = int.MaxValue;

            foreach (var start in possibleStarts)
            {
                var pathLength = map.BFS_ShortestPath(start, end).Count();
                if (pathLength > 0)
                    min = Math.Min(min, pathLength);
            }

            IO.WriteOutput(day, "b", min);
        }

        private static ((int, int) start, (int, int) end, Graph<(int, int)> graph, List<(int, int)> possibleStarts) GetMap(string[] input)
        {

            (int, int) start = (0, 0);
            (int, int) end = (0, 0);
            List<(int, int)> possibleStarts = new();

            Graph<(int, int)> map = new();

            for (int y = 0; y < input.Length; y++)
            {
                for (int x = 0; x < input[y].Length; x++)
                {
                    if (input[y][x] == 'S')
                    {
                        start = (x, y);
                        input[y] = input[y].Replace('S', 'a');
                    }
                    if (input[y][x] == 'E')
                    {
                        end = (x, y);
                        input[y] = input[y].Replace('E', 'z');
                    }
                    var vertex = (x, y);
                    map.AddVertex(vertex);
                    if (input[y][x] == 'a')
                        possibleStarts.Add(vertex);
                }
            }

            for (int y = 0; y < input.Length; y++)
            {
                for (int x = 0; x < input[y].Length; x++)
                {

                    if (x > 0 && input[y][x] - input[y][x - 1] > -2)
                        map.AddDirectedEdge(((x, y), (x - 1, y)));

                    if (x < input[y].Length - 1 && input[y][x] - input[y][x + 1] > -2)
                        map.AddDirectedEdge(((x, y), (x + 1, y)));

                    if (y > 0 && input[y][x] - input[y - 1][x] > -2)
                        map.AddDirectedEdge(((x, y), (x, y - 1)));

                    if (y < input.Length - 1 && input[y][x] - input[y + 1][x] > -2)
                        map.AddDirectedEdge(((x, y), (x, y + 1)));
                }
            }

            return (start, end, map, possibleStarts);
        }
    }
}
