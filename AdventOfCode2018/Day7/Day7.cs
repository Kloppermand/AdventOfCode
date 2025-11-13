using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Utilities;

namespace AdventOfCode2018.Day7
{
    public static class Day7
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            var graph = BuildGraphFromInput(input);


            string result = "";

            while (graph.WeightedAdjacencyList.Count() > 0)
            {
                var frontier = graph.WeightedAdjacencyList.Keys
                    .Where(v => !graph.WeightedAdjacencyList.Any(kvp => kvp.Value.ContainsKey(v))).ToList();

                var current = frontier.Min();
                result += current;
                graph.RemoveVertex(current);
            }

            IO.WriteOutput(day, "a", result);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            var graph = BuildGraphFromInput(input);

            int workerNumber = 5;
            int baseDuration = 60;

            var workers = new List<Worker>();
            for (int i = 0; i < workerNumber; i++)
                workers.Add(new Worker());
            
            int t = 0;
            while (graph.WeightedAdjacencyList.Count() > 0)
            {
                var frontier = graph.WeightedAdjacencyList.Keys
                    .Where(v => !graph.WeightedAdjacencyList.Any(kvp => kvp.Value.ContainsKey(v))).ToList();

                while (frontier.Where(n => !workers.Any(w => w.CurrentTask == n)).Any() &&
                       workers.Any(w => w.IsIdle))
                {
                    var nextTask = frontier
                        .Where(n => !workers.Any(w => w.CurrentTask == n))
                        .Min();
                    var idleWorker = workers.First(w => w.IsIdle);
                    idleWorker.AssignTask(nextTask, baseDuration);
                }
                foreach (var worker in workers)
                {
                    var completedTask = worker.WorkOneSecond();
                    if (completedTask.HasValue)
                    {
                        graph.RemoveVertex(completedTask.Value);
                    }
                }

                t++;
            }

            IO.WriteOutput(day, "b", t);
        }

        private static Graph<char> BuildGraphFromInput(string[] input)
        {
            if (input == null)
                return new Graph<char>();

            var rx = new Regex(@"Step\s+([A-Z])\s+must\s+be\s+finished\s+before\s+step\s+([A-Z])\s+can\s+begin\.",
                RegexOptions.Compiled | RegexOptions.IgnoreCase);

            var graph = new Graph<char>();

            foreach (var line in input)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var m = rx.Match(line);
                if (!m.Success)
                    continue;

                char prereq = m.Groups[1].Value[0];
                char dependent = m.Groups[2].Value[0];

                graph.AddDirectedEdge_Force(prereq, dependent);
            }

            return graph;
        }
    }
}
