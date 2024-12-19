using MathNet.Numerics.RootFinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2024.Day16
{
    public static class Day16
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;
        private static Dictionary<Direction, Direction> NextDir = new Dictionary<Direction, Direction>() {
            { Direction.UP, Direction.LEFT},
            { Direction.LEFT, Direction.DOWN},
            { Direction.DOWN, Direction.RIGHT},
            { Direction.RIGHT, Direction.UP} };
        private static Dictionary<Direction, Direction> PrevDir = new Dictionary<Direction, Direction>() {
            { Direction.UP, Direction.RIGHT},
            { Direction.LEFT, Direction.UP},
            { Direction.DOWN, Direction.LEFT},
            { Direction.RIGHT, Direction.DOWN} };
        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            Graph16 map = new();

            MazeCell start = new(0, 0, Direction.RIGHT);
            MazeCell endU = new(0, 0, Direction.UP);
            MazeCell endD = new(0, 0, Direction.DOWN);
            MazeCell endR = new(0, 0, Direction.RIGHT);
            MazeCell endL = new(0, 0, Direction.LEFT);
            FillMap(input, map, ref start, ref endU, ref endD, ref endR, ref endL);

            var lU = map.DijkstraShortestPath(start, endU).Last().distance;
            var lD = map.DijkstraShortestPath(start, endD).Last().distance;
            var lR = map.DijkstraShortestPath(start, endR).Last().distance;
            var lL = map.DijkstraShortestPath(start, endL).Last().distance;

            IO.WriteOutput(day, "a", Math.Min(Math.Min(Math.Min(lU, lD), lR), lL));
        }

        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            Graph16 map = new();

            MazeCell start = new(0, 0, Direction.RIGHT);
            MazeCell endU = new(0, 0, Direction.UP);
            MazeCell endD = new(0, 0, Direction.DOWN);
            MazeCell endR = new(0, 0, Direction.RIGHT);
            MazeCell endL = new(0, 0, Direction.LEFT);
            FillMap(input, map, ref start, ref endU, ref endD, ref endR, ref endL);

            var paths = map.DijkstraShortestPaths(start, endU);

            string result = "NOT SOLVED YET";
            IO.WriteOutput(day, "b", result);
        }

        private static void FillMap(string[] input, Graph16 map, ref MazeCell start, ref MazeCell endU, ref MazeCell endD, ref MazeCell endR, ref MazeCell endL)
        {
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    if (input[i][j] == '.' || input[i][j] == 'S' || input[i][j] == 'E')
                    {
                        map.AddVertex(new MazeCell(j, i, Direction.UP));
                        map.AddVertex(new MazeCell(j, i, Direction.DOWN));
                        map.AddVertex(new MazeCell(j, i, Direction.LEFT));
                        map.AddVertex(new MazeCell(j, i, Direction.RIGHT));

                        if (input[i][j] == 'S')
                            start = new MazeCell(j, i, Direction.RIGHT);

                        if (input[i][j] == 'E')
                        {
                            endR = new MazeCell(j, i, Direction.RIGHT);
                            endL = new MazeCell(j, i, Direction.LEFT);
                            endU = new MazeCell(j, i, Direction.UP);
                            endD = new MazeCell(j, i, Direction.DOWN);
                        }

                    }
                }
            }

            foreach (var cell in map.WeightedAdjacencyList)
            {
                MazeCell tmp = new(0, 0, Direction.RIGHT);
                switch (cell.Key.Direction)
                {
                    case Direction.UP:
                        tmp = new MazeCell(cell.Key.X, cell.Key.Y - 1, cell.Key.Direction);
                        break;
                    case Direction.DOWN:
                        tmp = new MazeCell(cell.Key.X, cell.Key.Y + 1, cell.Key.Direction);
                        break;
                    case Direction.LEFT:
                        tmp = new MazeCell(cell.Key.X - 1, cell.Key.Y, cell.Key.Direction);
                        break;
                    case Direction.RIGHT:
                        tmp = new MazeCell(cell.Key.X + 1, cell.Key.Y, cell.Key.Direction);
                        break;
                }
                map.AddWeightedDirectedEdge((cell.Key, new MazeCell(cell.Key.X, cell.Key.Y, NextDir[cell.Key.Direction])), 1000);
                map.AddWeightedDirectedEdge((cell.Key, new MazeCell(cell.Key.X, cell.Key.Y, PrevDir[cell.Key.Direction])), 1000);
                if (map.WeightedAdjacencyList.ContainsKey(tmp))
                    map.AddWeightedDirectedEdge((cell.Key, tmp), 1);
            }
        }

        public class MazeCell : IEquatable<MazeCell>
        {
            public int X { get; set; }
            public int Y { get; set; }
            public Direction Direction { get; set; }

            public MazeCell(int x, int y, Direction direction)
            {
                X = x;
                Y = y;
                Direction = direction;
            }

            public override string ToString()
            {
                return $"({X},{Y}, {Direction.ToString()})";
            }

            public static bool operator ==(MazeCell a, MazeCell b)
            {
                if (b is null)
                    return false;
                return a.X == b.X && a.Y == b.Y && a.Direction == b.Direction;
            }

            public static bool operator !=(MazeCell a, MazeCell b) => !(a == b);
            public bool Equals(MazeCell other) => this == other;

            public override int GetHashCode() => (X, Y, Direction).GetHashCode();
        }

        public enum Direction
        {
            UP,
            DOWN,
            LEFT,
            RIGHT
        }

        private class Graph16
        {
            public Dictionary<MazeCell, Dictionary<MazeCell, int>> WeightedAdjacencyList { get; } = new();
            public Graph16() { }
            public Graph16(Dictionary<MazeCell, Dictionary<MazeCell, int>> adjacencyList)
            {
                WeightedAdjacencyList = adjacencyList.ToDictionary(k => k.Key, v => v.Value.ToDictionary(k2 => k2.Key, v2 => v2.Value));
            }
            public Graph16(IEnumerable<MazeCell> vertices, IEnumerable<(MazeCell, MazeCell)> edges)
            {
                foreach (var vertex in vertices)
                    AddVertex(vertex);

                foreach (var edge in edges)
                    AddEdge(edge);
            }
            public Graph16(IEnumerable<MazeCell> vertices, IEnumerable<(MazeCell, MazeCell, int)> edges)
            {
                foreach (var vertex in vertices)
                    AddVertex(vertex);

                foreach (var edge in edges)
                    AddWeightedEdge((edge.Item1, edge.Item2), edge.Item3);
            }

            public Graph16 DeepCopyGraph()
            {
                var graph = new Graph16(WeightedAdjacencyList.ToDictionary(k => k.Key, v => v.Value.ToDictionary(k2 => k2.Key, v2 => v2.Value)));
                return graph;
            }

            /// <summary>
            /// Adds an empty vertex to the graph, if it doesn't exist. 
            /// </summary>
            /// <param name="vertex"></param>
            public void AddVertex(MazeCell vertex)
            {
                if (!WeightedAdjacencyList.ContainsKey(vertex))
                    WeightedAdjacencyList[vertex] = new();
            }

            /// <summary>
            /// Removes an empty vertex to the graph. 
            /// </summary>
            /// <param name="vertex"></param>
            public void RemoveVertex(MazeCell vertex)
            {
                WeightedAdjacencyList.Remove(vertex);
                foreach (var v in WeightedAdjacencyList)
                {
                    v.Value.Remove(vertex);
                }
            }

            /// <summary>
            /// Adds a weighted undirected edge to the graph between 2 existing verticies
            /// </summary>
            /// <param name="edge"></param>
            /// <param name="weight"></param>
            public void AddWeightedEdge((MazeCell, MazeCell) edge, int weight)
            {
                if (WeightedAdjacencyList.ContainsKey(edge.Item1) && WeightedAdjacencyList.ContainsKey(edge.Item2))
                {
                    WeightedAdjacencyList[edge.Item1].Add(edge.Item2, weight);
                    WeightedAdjacencyList[edge.Item2].Add(edge.Item1, weight);
                }
            }

            /// <summary>
            /// Adds a weighted undirected edge to the graph between 2 existing verticies
            /// </summary>
            /// <param name="edge"></param>
            /// <param name="weight"></param>
            public void AddEdge((MazeCell, MazeCell) edge)
            {
                AddEdge(edge.Item1, edge.Item2);
                //if (WeightedAdjacencyList.ContainsKey(edge.Item1) && WeightedAdjacencyList.ContainsKey(edge.Item2))
                //{
                //    WeightedAdjacencyList[edge.Item1].Add(edge.Item2, 1);
                //    WeightedAdjacencyList[edge.Item2].Add(edge.Item1, 1);
                //}
            }

            /// <summary>
            /// Adds a weighted undirected edge to the graph between 2 existing verticies
            /// </summary>
            /// <param name="edge"></param>
            /// <param name="weight"></param>
            public void AddEdge(MazeCell vertex1, MazeCell vertex2)
            {
                if (WeightedAdjacencyList.ContainsKey(vertex1) && WeightedAdjacencyList.ContainsKey(vertex2))
                {
                    WeightedAdjacencyList[vertex1].Add(vertex2, 1);
                    WeightedAdjacencyList[vertex2].Add(vertex1, 1);
                }
            }

            /// <summary>
            /// Adds a weighted directed edge to the graph between 2 existing verticies.
            /// </summary>
            /// <param name="edge"></param>
            public void AddWeightedDirectedEdge((MazeCell, MazeCell) edge, int weight)
            {
                if (WeightedAdjacencyList.ContainsKey(edge.Item1) && WeightedAdjacencyList.ContainsKey(edge.Item2))
                {
                    WeightedAdjacencyList[edge.Item1].Add(edge.Item2, weight);
                }
            }

            /// <summary>
            /// Adds a weighted directed edge to the graph between 2 existing verticies.
            /// </summary>
            /// <param name="edge"></param>
            public void AddDirectedEdge((MazeCell, MazeCell) edge)
            {
                if (WeightedAdjacencyList.ContainsKey(edge.Item1) && WeightedAdjacencyList.ContainsKey(edge.Item2))
                {
                    WeightedAdjacencyList[edge.Item1].Add(edge.Item2, 1);
                }
            }

            /// <summary>
            /// Adds a weighted directed edge to the graph between 2 existing verticies.
            /// </summary>
            /// <param name="edge"></param>
            public void AddDirectedEdge(MazeCell vertex1, MazeCell vertex2)
            {
                AddDirectedEdge((vertex1, vertex2));
            }

            /// <summary>
            /// Adds a weighted directed edge to the graph between 2 existing verticies.
            /// If the verticies doesn't exist it will create them.
            /// </summary>
            /// <param name="edge"></param>
            public void AddDirectedEdge_Force((MazeCell, MazeCell) edge)
            {
                AddVertex(edge.Item1);
                AddVertex(edge.Item2);
                AddDirectedEdge(edge);
            }

            /// <summary>
            /// Adds a weighted directed edge to the graph between 2 existing verticies.
            /// If the verticies doesn't exist it will create them.
            /// </summary>
            /// <param name="edge"></param>
            public void AddDirectedEdge_Force(MazeCell vertex1, MazeCell vertex2)
            {
                AddVertex(vertex1);
                AddVertex(vertex2);
                AddDirectedEdge(vertex1, vertex2);
            }


            public List<(MazeCell node, int distance)> DijkstraShortestPath(MazeCell start, MazeCell end)
            {
                var previousNodes = new Dictionary<MazeCell, MazeCell>();
                var distances = new Dictionary<MazeCell, int>();
                var queue = new SortedDictionary<int, Queue<MazeCell>>();

                foreach (var vertex in WeightedAdjacencyList.Keys)
                {
                    if (vertex.Equals(start))
                    {
                        distances[vertex] = 0;
                        queue[0] = new Queue<MazeCell>();
                        queue[0].Enqueue(start);
                    }
                    else
                    {
                        distances[vertex] = int.MaxValue;
                    }
                }

                while (queue.Count > 0)
                {
                    var currentDistance = queue.First().Key;
                    var currentVertex = queue.First().Value.Dequeue();
                    if (queue.First().Value.Count == 0)
                    {
                        queue.Remove(currentDistance);
                    }

                    foreach (var neighbor in WeightedAdjacencyList[currentVertex].Keys)
                    {
                        int alternatePathDistance = distances[currentVertex] + WeightedAdjacencyList[currentVertex][neighbor];
                        if (alternatePathDistance < distances[neighbor])
                        {
                            distances[neighbor] = alternatePathDistance;
                            previousNodes[neighbor] = currentVertex;

                            if (!queue.ContainsKey(alternatePathDistance))
                            {
                                queue[alternatePathDistance] = new Queue<MazeCell>();
                            }
                            queue[alternatePathDistance].Enqueue(neighbor);
                        }
                    }
                }

                var shortestPath = new List<(MazeCell, int)>();
                var currentNode = end;
                while (currentNode != null && previousNodes.ContainsKey(currentNode))
                {
                    shortestPath.Insert(0, (currentNode, distances[currentNode]));
                    currentNode = previousNodes[currentNode];
                }

                return shortestPath;
            }

            public List<List<(MazeCell node, int distance)>> DijkstraShortestPaths(MazeCell start, MazeCell end)
            {
                var previousNodes = new Dictionary<MazeCell, MazeCell>();
                var distances = new Dictionary<MazeCell, int>();
                var queue = new SortedDictionary<int, Queue<MazeCell>>();
                var shortestDistance = int.MaxValue;
                var shortestPaths = new List<List<(MazeCell node, int distance)>>();

                foreach (var vertex in WeightedAdjacencyList.Keys)
                {
                    if (vertex.Equals(start))
                    {
                        distances[vertex] = 0;
                        queue[0] = new Queue<MazeCell>();
                        queue[0].Enqueue(start);
                    }
                    else
                    {
                        distances[vertex] = int.MaxValue;
                    }
                }

                while (queue.Count > 0)
                {
                    var currentDistance = queue.First().Key;
                    var currentVertex = queue.First().Value.Dequeue();
                    if (queue.First().Value.Count == 0)
                    {
                        queue.Remove(currentDistance);
                    }

                    foreach (var neighbor in WeightedAdjacencyList[currentVertex].Keys)
                    {
                        int alternatePathDistance = distances[currentVertex] + WeightedAdjacencyList[currentVertex][neighbor];
                        if (alternatePathDistance < distances[neighbor])
                        {
                            distances[neighbor] = alternatePathDistance;
                            previousNodes[neighbor] = currentVertex;

                            if (!queue.ContainsKey(alternatePathDistance))
                            {
                                queue[alternatePathDistance] = new Queue<MazeCell>();
                            }
                            queue[alternatePathDistance].Enqueue(neighbor);
                        }
                        else if (alternatePathDistance == distances[neighbor])
                        {
                            // Collect all equally short paths
                            var path = new List<(MazeCell node, int distance)>();
                            var currentNode = neighbor;
                            while (currentNode != null && previousNodes.ContainsKey(currentNode))
                            {
                                path.Insert(0, (currentNode, distances[currentNode]));
                                currentNode = previousNodes[currentNode];
                            }
                            shortestPaths.Add(path);
                        }
                    }
                }

                // Yield all shortest paths
                return shortestPaths.Where(path => path.Last().Equals(end)).ToList();
            }
        }
    }
}
