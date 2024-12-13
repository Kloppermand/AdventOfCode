using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Utilities;

namespace AdventOfCode2024.Day12
{
    public static class Day12
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;
        private static Graph<Point> map = new();
        private static List<List<KeyValuePair<Point, Dictionary<Point, int>>>> regionList = new();

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringArray(day, "a");

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    map.AddVertex(new(i, j) { CharValue = input[i][j] });
                }
            }

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    var current = map.WeightedAdjacencyList.Keys.First(x => x == new Point(i, j));
                    if (i > 0 && input[i - 1][j] == current.CharValue)
                        map.AddEdge(current, map.WeightedAdjacencyList.First(x => x.Key == new Point(i - 1, j)).Key);

                    if (j > 0 && input[i][j - 1] == current.CharValue)
                        map.AddEdge(current, map.WeightedAdjacencyList.First(x => x.Key == new Point(i, j - 1)).Key);
                }
            }

            int region = 1;
            Dictionary<int, List<Point>> regions = new();
            foreach (var node in map.WeightedAdjacencyList)
            {
                if (node.Key.StringValue == null)
                {
                    MarkNeighbours(map, node.Key, region);
                    region++;
                }
            }

            for (int i = 1; i < region; i++)
            {
                regionList.Add(map.WeightedAdjacencyList.Where(x => x.Key.StringValue == i.ToString()).ToList());
            }

            int result = 0;
            foreach (var reg in regionList)
            {
                int fences = 0;
                foreach (var node in reg)
                {
                    fences += 4 - node.Value.Count;
                }
                result += reg.Count * fences;
            }

            IO.WriteOutput(day, "a", result);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            int h = input.Length;
            int width = input[0].Length;
            int result = 0;
            foreach (var reg in regionList)
            {
                int fences = 0;
                foreach (var node in reg)
                {
                    if (node.Value.Count == 1) { fences += 2; continue; }
                    bool nw = false;
                    bool n = false;
                    bool ne = false;
                    bool w = false;
                    bool e = false;
                    bool sw = false;
                    bool s = false;
                    bool se = false;
                    if (node.Key.Y > 0)
                    {
                        if (node.Key.X > 0)
                            sw = map.WeightedAdjacencyList.First(x => x.Key == new Point(node.Key.X - 1, node.Key.Y - 1)).Key.CharValue == node.Key.CharValue;
                        s = map.WeightedAdjacencyList.First(x => x.Key == new Point(node.Key.X, node.Key.Y - 1)).Key.CharValue == node.Key.CharValue;
                        if (node.Key.X < h - 1)
                            se = map.WeightedAdjacencyList.First(x => x.Key == new Point(node.Key.X + 1, node.Key.Y - 1)).Key.CharValue == node.Key.CharValue;
                    }
                    if (node.Key.X > 0)
                        w = map.WeightedAdjacencyList.First(x => x.Key == new Point(node.Key.X - 1, node.Key.Y)).Key.CharValue == node.Key.CharValue;
                    if (node.Key.X < h - 1)
                        e = map.WeightedAdjacencyList.First(x => x.Key == new Point(node.Key.X + 1, node.Key.Y)).Key.CharValue == node.Key.CharValue;
                    if (node.Key.Y < (width - 1))
                    {
                        if (node.Key.X > 0)
                            nw = map.WeightedAdjacencyList.First(x => x.Key == new Point(node.Key.X - 1, node.Key.Y + 1)).Key.CharValue == node.Key.CharValue;
                        n = map.WeightedAdjacencyList.First(x => x.Key == new Point(node.Key.X, node.Key.Y + 1)).Key.CharValue == node.Key.CharValue;
                        if (node.Key.X < h - 1)
                            ne = map.WeightedAdjacencyList.First(x => x.Key == new Point(node.Key.X + 1, node.Key.Y + 1)).Key.CharValue == node.Key.CharValue;
                    }
                    if (n && e && !ne)
                        fences++;
                    if (s && e && !se)
                        fences++;
                    if (n && w && !nw)
                        fences++;
                    if (s && w && !sw)
                        fences++;

                    if (!n && !e)
                        fences++;
                    if (!s && !e)
                        fences++;
                    if (!n && !w)
                        fences++;
                    if (!s && !w)
                        fences++;
                }
                result += reg.Count * fences;
            }


            IO.WriteOutput(day, "b", result);
        }

        private static void MarkNeighbours(Graph<Point> map, Point p, int region)
        {
            p.StringValue = region.ToString();
            var neighbours = map.WeightedAdjacencyList[p];
            foreach (var node in neighbours.Where(x => x.Key.StringValue == null))
            {
                MarkNeighbours(map, node.Key, region);
            }
        }
    }
}
