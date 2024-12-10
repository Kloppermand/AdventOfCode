using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2024.Day10
{
    public static class Day10
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileInt2DArray(day, "a");
            int result = 0;
            Graph<Point> graph = CreateGraph(input);

            foreach (var start in graph.WeightedAdjacencyList.Keys.Where(v => v.IntValue == 0))
            {
                result += graph.BFS_VisitedNotes(start).Count(x => x.IntValue == 9);
            }

            IO.WriteOutput(day, "a", result);
        }

        public static void CalculateB()
        {
            var input = IO.ReadInputFileInt2DArray(day, "a");
            int result = 0;
            Graph<Point> graph = CreateGraph(input);

            graph.WeightedAdjacencyList.Keys.Where(v => v.IntValue == 0).ToList()
                .ForEach(x0 =>
                {
                    graph.WeightedAdjacencyList[x0].Keys.ToList()
                    .ForEach(x1 =>
                    {
                        graph.WeightedAdjacencyList[x1].Keys.ToList()
                        .ForEach(x2 =>
                        {
                            graph.WeightedAdjacencyList[x2].Keys.ToList()
                            .ForEach(x3 =>
                            {
                                graph.WeightedAdjacencyList[x3].Keys.ToList()
                                .ForEach(x4 =>
                                {
                                    graph.WeightedAdjacencyList[x4].Keys.ToList()
                                    .ForEach(x5 =>
                                    {
                                        graph.WeightedAdjacencyList[x5].Keys.ToList()
                                        .ForEach(x6 =>
                                        {
                                            graph.WeightedAdjacencyList[x6].Keys.ToList()
                                            .ForEach(x7 =>
                                            {
                                                graph.WeightedAdjacencyList[x7].Keys.ToList()
                                                .ForEach(x8 =>
                                                {
                                                    graph.WeightedAdjacencyList[x8].Keys.ToList()
                                                    .ForEach(x9 =>
                                                     {
                                                         result++;
                                                     });
                                                });
                                            });
                                        });
                                    });
                                });
                            });
                        });
                    });
                });

            IO.WriteOutput(day, "b", result);
        }

        private static Graph<Point> CreateGraph(int[,] input)
        {
            Graph<Point> graph = new();
            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    if (i > 0 && input[i - 1, j] - input[i, j] == 1) graph.AddDirectedEdge_Force(new Point(i, j) { IntValue = input[i, j] }, new Point(i - 1, j) { IntValue = input[i - 1, j] });
                    if (i < input.GetLength(0) - 1 && input[i + 1, j] - input[i, j] == 1) graph.AddDirectedEdge_Force(new Point(i, j) { IntValue = input[i, j] }, new Point(i + 1, j) { IntValue = input[i + 1, j] });

                    if (j > 0 && input[i, j - 1] - input[i, j] == 1) graph.AddDirectedEdge_Force(new Point(i, j) { IntValue = input[i, j] }, new Point(i, j - 1) { IntValue = input[i, j - 1] });
                    if (j < input.GetLength(1) - 1 && input[i, j + 1] - input[i, j] == 1) graph.AddDirectedEdge_Force(new Point(i, j) { IntValue = input[i, j] }, new Point(i, j + 1) { IntValue = input[i, j + 1] });
                }
            }

            return graph;
        }
    }
}
