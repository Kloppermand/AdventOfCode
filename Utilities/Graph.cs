using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class Graph<T>
    {
        public Graph() { }
        public Graph(IEnumerable<T> vertices, IEnumerable<(T, T)> edges)
        {
            foreach (var vertex in vertices)
                AddVertex(vertex);

            foreach (var edge in edges)
                AddEdge(edge);
        }

        public Dictionary<T, HashSet<T>> AdjacencyList { get; } = new Dictionary<T, HashSet<T>>();

        /// <summary>
        /// Adds an empty vertex to the graph. 
        /// </summary>
        /// <param name="vertex"></param>
        public void AddVertex(T vertex)
        {
            AdjacencyList[vertex] = new HashSet<T>();
        }

        /// <summary>
        /// Adds an undirected edge to the graph between 2 existing verticies.
        /// Meaning adding 2 edges, so that both verticies are a source and a target.
        /// </summary>
        /// <param name="edge"></param>
        public void AddEdge((T, T) edge)
        {
            if (AdjacencyList.ContainsKey(edge.Item1) && AdjacencyList.ContainsKey(edge.Item2))
            {
                AdjacencyList[edge.Item1].Add(edge.Item2);
                AdjacencyList[edge.Item2].Add(edge.Item1);
            }
        }

        /// <summary>
        /// Adds a directed edge to the graph between 2 existing verticies.
        /// </summary>
        /// <param name="edge"></param>
        public void AddDirectedEdge((T, T) edge)
        {
            if (AdjacencyList.ContainsKey(edge.Item1) && AdjacencyList.ContainsKey(edge.Item2))
            {
                AdjacencyList[edge.Item1].Add(edge.Item2);
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

            if (!AdjacencyList.ContainsKey(start))
                return visited;

            var queue = new Queue<T>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();

                if (visited.Contains(vertex))
                    continue;

                visited.Add(vertex);

                foreach (var neighbor in AdjacencyList[vertex])
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

            if (!AdjacencyList.ContainsKey(start))
                return null;

            var queue = new Queue<T>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();

                foreach (var neighbor in AdjacencyList[vertex])
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
    }
}
