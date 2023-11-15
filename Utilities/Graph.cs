using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class Graph<T>
    {
        public Dictionary<T, Dictionary<T, int>> WeightedAdjacencyList { get; } = new();
        public Graph() { }
        public Graph(Dictionary<T, Dictionary<T, int>> adjacencyList)
        {
            WeightedAdjacencyList = adjacencyList.ToDictionary(k => k.Key, v => v.Value.ToDictionary(k2 => k2.Key, v2 => v2.Value));
        }
        public Graph(IEnumerable<T> vertices, IEnumerable<(T, T)> edges)
        {
            foreach (var vertex in vertices)
                AddVertex(vertex);

            foreach (var edge in edges)
                AddEdge(edge);
        }
        public Graph(IEnumerable<T> vertices, IEnumerable<(T, T, int)> edges)
        {
            foreach (var vertex in vertices)
                AddVertex(vertex);

            foreach (var edge in edges)
                AddWeightedEdge((edge.Item1, edge.Item2), edge.Item3);
        }

        public Graph<T> DeepCopyGraph()
        {
            var graph = new Graph<T>(WeightedAdjacencyList.ToDictionary(k => k.Key, v => v.Value.ToDictionary(k2 => k2.Key, v2 => v2.Value)));
            return graph;
        }

        /// <summary>
        /// Adds an empty vertex to the graph, if it doesn't exist. 
        /// </summary>
        /// <param name="vertex"></param>
        public void AddVertex(T vertex)
        {
            if (!WeightedAdjacencyList.ContainsKey(vertex))
                WeightedAdjacencyList[vertex] = new();
        }

        /// <summary>
        /// Removes an empty vertex to the graph. 
        /// </summary>
        /// <param name="vertex"></param>
        public void RemoveVertex(T vertex)
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
        public void AddWeightedEdge((T, T) edge, int weight)
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
        public void AddEdge((T, T) edge)
        {
            if (WeightedAdjacencyList.ContainsKey(edge.Item1) && WeightedAdjacencyList.ContainsKey(edge.Item2))
            {
                WeightedAdjacencyList[edge.Item1].Add(edge.Item2, 1);
                WeightedAdjacencyList[edge.Item2].Add(edge.Item1, 1);
            }
        }

        /// <summary>
        /// Adds a weighted directed edge to the graph between 2 existing verticies.
        /// </summary>
        /// <param name="edge"></param>
        public void AddWeightedDirectedEdge((T, T) edge, int weight)
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
        public void AddDirectedEdge((T, T) edge)
        {
            if (WeightedAdjacencyList.ContainsKey(edge.Item1) && WeightedAdjacencyList.ContainsKey(edge.Item2))
            {
                WeightedAdjacencyList[edge.Item1].Add(edge.Item2, 1);
            }
        }

        /// <summary>
        /// Retuens all nodes reachable from the start posistion
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        public HashSet<T> BFS_VisitedNotes(T start)
        {
            var visited = new HashSet<T>();

            if (!WeightedAdjacencyList.ContainsKey(start))
                return visited;

            var queue = new Queue<T>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();

                if (visited.Contains(vertex))
                    continue;

                visited.Add(vertex);

                foreach (var neighbor in WeightedAdjacencyList[vertex].Keys)
                    if (!visited.Contains(neighbor))
                        queue.Enqueue(neighbor);
            }

            return visited;
        }

        /// <summary>
        /// Returns the shortest path from the start node to the end node using Bredth First Search
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public List<T> BFS_ShortestPath(T start, T end)
        {
            var previous = new Dictionary<T, T>();

            if (!WeightedAdjacencyList.ContainsKey(start))
                return null;

            var queue = new Queue<T>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();

                foreach (var neighbor in WeightedAdjacencyList[vertex].Keys)
                    if (!previous.ContainsKey(neighbor) && !neighbor.Equals(start))
                    {
                        queue.Enqueue(neighbor);
                        previous.Add(neighbor, vertex);
                    }
            }

            List<T> path = new();
            var currentVertex = end;
            while (previous.ContainsKey(currentVertex))
            {
                path.Add(currentVertex);
                currentVertex = previous[currentVertex];
            }
            path.Reverse();

            return path;
        }

        public Dictionary<T, int> DijkstraShortestPath(T start)
        {
            // Initialize the distances dictionary
            var distances = new Dictionary<T, int>();
            foreach (var vertex in WeightedAdjacencyList.Keys)
            {
                distances[vertex] = int.MaxValue;
            }
            distances[start] = 0;

            // Create a set to track unvisited nodes
            var unvisited = new HashSet<T>(WeightedAdjacencyList.Keys);

            while (unvisited.Count > 0)
            {
                // Select the unvisited node with the smallest distance
                T currentVertex = unvisited.OrderBy(v => distances[v]).First();

                // Remove the current vertex from unvisited set
                unvisited.Remove(currentVertex);

                // Update distances of adjacent vertices
                foreach (var neighbor in WeightedAdjacencyList[currentVertex].Keys)
                {
                    int alternatePathDistance = distances[currentVertex] + WeightedAdjacencyList[currentVertex][neighbor];
                    if (alternatePathDistance < distances[neighbor])
                    {
                        distances[neighbor] = alternatePathDistance;
                    }
                }
            }

            return distances;
        }
    }
}
