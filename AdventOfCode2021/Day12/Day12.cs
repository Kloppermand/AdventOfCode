using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2021.Day12
{
    public static class Day12
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringArray(day, "a");

            Graph<string> network = new Graph<string>();
            List<string> caves = new List<string>();
            foreach (var c in input)
            {
                var tmp = c.Split("-");
                network.AddVertex(tmp[0]);
                network.AddVertex(tmp[1]);
                network.AddEdge((tmp[0], tmp[1]));
            }

            int result = GetNumberOfPaths(network, "start", new List<string>());

            IO.WriteOutput(day, "a", result);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArray(day, "a");

            Graph<string> network = new Graph<string>();
            List<string> caves = new List<string>();
            foreach (var c in input)
            {
                var tmp = c.Split("-");
                network.AddVertex(tmp[0]);
                network.AddVertex(tmp[1]);
                network.AddEdge((tmp[0], tmp[1]));
            }

            int result = GetNumberOfPaths2(network, "start", new List<string>(), false);
            IO.WriteOutput(day, "b", result);
        }

        private static int GetNumberOfPaths(Graph<string> network, string fromCave, List<string> path)
        {
            int result = 0;

            var steppedNetwork = network.DeepCopyGraph();
            if (fromCave == fromCave.ToLower())
                steppedNetwork.RemoveVertex(fromCave);

            var newPath = new List<string>(path);
            newPath.Add(fromCave);

            foreach (var step in network.WeightedAdjacencyList[fromCave].Keys)
            {

                if (step.Equals("end"))
                {
                    result++;
                    continue;
                }

                result += GetNumberOfPaths(steppedNetwork, step, newPath);
            }

            return result;
        }

        private static int GetNumberOfPaths2(Graph<string> network, string fromCave, List<string> path, bool visitedSmallTwice)
        {
            int result = 0;
            if (fromCave == fromCave.ToLower() && path.Contains(fromCave) && visitedSmallTwice)
                return result;

            var steppedNetwork = network.DeepCopyGraph();
            if ((fromCave == fromCave.ToLower() && (path.Contains(fromCave) || visitedSmallTwice)) || fromCave.Equals("start") || fromCave.Equals("end"))
            {
                if (path.Contains(fromCave))
                    visitedSmallTwice = true;

                steppedNetwork.RemoveVertex(fromCave);
            }

            var newPath = new List<string>(path);
            newPath.Add(fromCave);

            foreach (var step in network.WeightedAdjacencyList[fromCave].Keys)
            {

                if (step.Equals("end"))
                {
                    result++;
                    //Console.WriteLine(string.Join(',', newPath));
                    continue;
                }

                result += GetNumberOfPaths2(steppedNetwork, step, newPath, visitedSmallTwice);
            }

            return result;
        }
    }
}
