using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2021.Day15
{
    public static class Day15
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileInt2DArray(day, "a");

            var map = GetMap(input);

            var path = map.DijkstraShortestPath((0, 0), (input.GetLength(0) - 1, input.GetLength(1) - 1));

            var result = path.Last().distance;
            IO.WriteOutput(day, "a", result);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileInt2DArray(day, "a");
            
            var largeInput = new int[input.GetLength(0)*5,input.GetLength(1)*5];

            for (int i = 0; i < largeInput.GetLength(0); i++)
            {
                for (int j = 0; j < largeInput.GetLength(1); j++)
                {
                    var weight = input[i%input.GetLength(0),j%input.GetLength(1)] + i / input.GetLength(0) + j / input.GetLength(1);
                    while (weight > 9) weight -= 9;
                    largeInput[i, j] = weight;
                }
            }

            var map = GetMap(largeInput);

            

            var path = map.DijkstraShortestPath((0, 0), (input.GetLength(0) * 5 - 1, input.GetLength(1) * 5 - 1));

            var result = path.Last().distance;
            IO.WriteOutput(day, "b", result);
        }

        private static Graph<(int, int)> GetMap(int[,] input)
        {
            var map = new Graph<(int, int)>();

            // Add verticies
            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    map.AddVertex((i, j));
                }
            }

            // Add Edges to the right
            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1) - 1; j++)
                {
                    map.AddWeightedDirectedEdge(((i, j), (i, j + 1)), input[i, j + 1]);
                }
            }

            // Add Edges to the left
            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 1; j < input.GetLength(1); j++)
                {
                    map.AddWeightedDirectedEdge(((i, j), (i, j - 1)), input[i, j - 1]);
                }
            }

            // Add Edges to the up
            for (int i = 0; i < input.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    map.AddWeightedDirectedEdge(((i, j), (i + 1, j)), input[i + 1, j]);
                }
            }

            // Add Edges to the down
            for (int i = 1; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    map.AddWeightedDirectedEdge(((i, j), (i - 1, j)), input[i - 1, j]);
                }
            }

            return map;
        }
    }
}
