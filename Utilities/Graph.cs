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
        public void AddEdge(T vertex1, T vertex2)
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
        /// Adds a weighted directed edge to the graph between 2 existing verticies.
        /// </summary>
        /// <param name="edge"></param>
        public void AddDirectedEdge(T vertex1, T vertex2)
        {
            AddDirectedEdge((vertex1, vertex2));
        }

        /// <summary>
        /// Adds a weighted directed edge to the graph between 2 existing verticies.
        /// If the verticies doesn't exist it will create them.
        /// </summary>
        /// <param name="edge"></param>
        public void AddDirectedEdge_Force((T, T) edge)
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
        public void AddDirectedEdge_Force(T vertex1, T vertex2)
        {
            AddVertex(vertex1);
            AddVertex(vertex2);
            AddDirectedEdge(vertex1, vertex2);
        }

        public bool PointsTo(T source, T target)
        {
            if (WeightedAdjacencyList.ContainsKey(source))
                return WeightedAdjacencyList[source].ContainsKey(target);

            return false;
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

        public List<(T node, int distance)> DijkstraShortestPath(T start, T end)
        {
            var previousNodes = new Dictionary<T, T>();
            var distances = new Dictionary<T, int>();
            var queue = new SortedDictionary<int, Queue<T>>();

            foreach (var vertex in WeightedAdjacencyList.Keys)
            {
                if (vertex.Equals(start))
                {
                    distances[vertex] = 0;
                    queue[0] = new Queue<T>();
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
                            queue[alternatePathDistance] = new Queue<T>();
                        }
                        queue[alternatePathDistance].Enqueue(neighbor);
                    }
                }
            }

            var shortestPath = new List<(T, int)>();
            var currentNode = end;
            while (currentNode != null && previousNodes.ContainsKey(currentNode))
            {
                shortestPath.Insert(0, (currentNode, distances[currentNode]));
                currentNode = previousNodes[currentNode];
            }

            return shortestPath;
        }

        public void Print(int width = 80, int height = 25, int labelMaxLength = 6)
        {
            // Ensure sensible minimums
            if (width < 10) width = 10;
            if (height < 5) height = 5;

            // Auto-expand to a larger visualization if caller used defaults.
            try
            {
                if (width == 80)
                {
                    if (!Console.IsOutputRedirected && Console.WindowWidth > 0)
                        width = Math.Min(Math.Max(width, Console.WindowWidth - 4), 160);
                    else
                        width = Math.Min(Math.Max(width, 120), 200);
                }

                if (height == 25)
                {
                    if (!Console.IsOutputRedirected && Console.WindowHeight > 0)
                        height = Math.Min(Math.Max(height, Console.WindowHeight - 4), 60);
                    else
                        height = Math.Min(Math.Max(height, 36), 80);
                }
            }
            catch
            {
                // Fallback larger safe defaults on platforms where console dimensions can't be read
                if (width == 80) width = 120;
                if (height == 25) height = 36;
            }

            if (WeightedAdjacencyList.Count == 0)
            {
                Console.WriteLine("[Graph is empty]");
                return;
            }

            var nodes = WeightedAdjacencyList.Keys.ToList();
            int n = nodes.Count;
            double cx = (width - 1) / 2.0;
            double cy = (height - 1) / 2.0;
            // Use more of the available area to spread nodes farther out
            double r = Math.Max(4.0, Math.Min(width, height) / 2.0 - 1.0);

            // Horizontal stretching factor to make the circle 3x as wide
            double horizontalScale = 3.0;
            double rx = r * horizontalScale;
            double ry = r;

            var positions = new Dictionary<T, (int x, int y)>();
            var used = new HashSet<(int x, int y)>();

            for (int i = 0; i < n; i++)
            {
                double angle = 2.0 * Math.PI * i / n;
                int x = (int)Math.Round(cx + rx * Math.Cos(angle));
                int y = (int)Math.Round(cy + ry * Math.Sin(angle));
                x = Clamp(x, 0, width - 1);
                y = Clamp(y, 0, height - 1);

                // Nudge if collision; allow larger nudges and more attempts to reduce overlap
                int attempts = 0;
                while (used.Contains((x, y)) && attempts < 500)
                {
                    // wider deterministic nudge to spread nodes
                    int dx = ((attempts % 9) - 4); // -4..4
                    int dy = (((attempts + 3) % 9) - 4);
                    // biased nudge based on node index to avoid clustering
                    x = Clamp(x + dx + ((i % 3) - 1), 0, width - 1);
                    y = Clamp(y + dy + (((i + 1) % 3) - 1), 0, height - 1);
                    attempts++;
                }

                positions[nodes[i]] = (x, y);
                used.Add((x, y));
            }

            // connection mask grid: bits N=1, E=2, S=4, W=8
            var conn = new int[height, width];
            // overlay for arrows (directed edge heads) - using simple ascii arrows: '>' '<' 'v' '^'
            var arrowOverlay = new char[height, width];
            for (int yy = 0; yy < height; yy++)
                for (int xx = 0; xx < width; xx++)
                {
                    conn[yy, xx] = 0;
                    arrowOverlay[yy, xx] = '\0';
                }

            var indexOf = new Dictionary<T, int>();
            for (int i = 0; i < nodes.Count; i++)
                indexOf[nodes[i]] = i;

            // Bresenham line helper that returns list of points including endpoints
            List<(int x, int y)> GetLinePoints(int x0, int y0, int x1, int y1)
            {
                var points = new List<(int x, int y)>();
                int dx = Math.Abs(x1 - x0);
                int sx = x0 < x1 ? 1 : -1;
                int dy = -Math.Abs(y1 - y0);
                int sy = y0 < y1 ? 1 : -1;
                int err = dx + dy;
                int x = x0, y = y0;
                while (true)
                {
                    points.Add((x, y));
                    if (x == x1 && y == y1) break;
                    int e2 = 2 * err;
                    if (e2 >= dy)
                    {
                        err += dy;
                        x += sx;
                    }
                    if (e2 <= dx)
                    {
                        err += dx;
                        y += sy;
                    }
                }
                return points;
            }

            static int DirBit((int x, int y) a, (int x, int y) b)
            {
                if (b.x == a.x && b.y == a.y - 1) return 1; // N
                if (b.x == a.x + 1 && b.y == a.y) return 2; // E
                if (b.x == a.x && b.y == a.y + 1) return 4; // S
                if (b.x == a.x - 1 && b.y == a.y) return 8; // W
                // For diagonal steps (rare with Bresenham), approximate by choosing dominant direction
                int dx = b.x - a.x;
                int dy = b.y - a.y;
                if (Math.Abs(dx) > Math.Abs(dy)) return dx > 0 ? 2 : 8;
                return dy > 0 ? 4 : 1;
            }

            // Add connections for each edge
            foreach (var src in WeightedAdjacencyList.Keys)
            {
                foreach (var tgt in WeightedAdjacencyList[src].Keys)
                {
                    if (!positions.ContainsKey(src) || !positions.ContainsKey(tgt)) continue;
                    var a = positions[src];
                    var b = positions[tgt];

                    bool reverseExists = WeightedAdjacencyList.ContainsKey(tgt) && WeightedAdjacencyList[tgt].ContainsKey(src);
                    if (reverseExists)
                    {
                        // Draw only once for bidirectional pairs
                        if (indexOf[src] > indexOf[tgt]) continue;
                    }

                    var pts = GetLinePoints(a.x, a.y, b.x, b.y);
                    for (int i = 0; i < pts.Count - 1; i++)
                    {
                        var p = pts[i];
                        var q = pts[i + 1];
                        if (p.x < 0 || p.x >= width || p.y < 0 || p.y >= height) continue;
                        if (q.x < 0 || q.x >= width || q.y < 0 || q.y >= height) continue;
                        int bitP = DirBit(p, q);
                        int bitQ = DirBit(q, p);
                        conn[p.y, p.x] |= bitP;
                        conn[q.y, q.x] |= bitQ;
                    }

                    // For directed edges, place an arrow one step before target (if possible)
                    if (!reverseExists)
                    {
                        if (pts.Count >= 2)
                        {
                            var beforeTarget = pts[pts.Count - 2];
                            var targetPoint = pts[pts.Count - 1];
                            // choose arrow char based on direction from beforeTarget -> targetPoint
                            char arr;
                            int dx = targetPoint.x - beforeTarget.x;
                            int dy = targetPoint.y - beforeTarget.y;
                            if (Math.Abs(dx) >= Math.Abs(dy))
                                arr = dx >= 0 ? '>' : '<';
                            else
                                arr = dy >= 0 ? 'v' : '^';

                            // store arrow overlay (do not overwrite existing arrow)
                            if (beforeTarget.x >= 0 && beforeTarget.x < width && beforeTarget.y >= 0 && beforeTarget.y < height)
                            {
                                if (arrowOverlay[beforeTarget.y, beforeTarget.x] == '\0')
                                    arrowOverlay[beforeTarget.y, beforeTarget.x] = arr;
                            }
                        }
                    }
                }
            }

            // Convert connection masks to characters (box-drawing)
            char MaskToChar(int mask)
            {
                // bits: N=1, E=2, S=4, W=8
                return mask switch
                {
                    0 => ' ',
                    1 => '│',
                    2 => '─',
                    3 => '└',     // N+E
                    4 => '│',
                    5 => '│',     // N+S
                    6 => '┌',     // E+S
                    7 => '├',     // N+E+S
                    8 => '─',
                    9 => '┘',     // N+W
                    10 => '─',    // E+W
                    11 => '┴',    // N+E+W
                    12 => '┐',    // S+W
                    13 => '┤',    // N+S+W
                    14 => '┬',    // E+S+W
                    15 => '┼',    // all
                    _ => ' ',
                };
            }

            // Build grid base from conn masks, then overlay arrows (arrows take precedence)
            var grid = new char[height, width];
            for (int yy = 0; yy < height; yy++)
            {
                for (int xx = 0; xx < width; xx++)
                {
                    grid[yy, xx] = MaskToChar(conn[yy, xx]);
                    if (arrowOverlay[yy, xx] != '\0')
                        grid[yy, xx] = arrowOverlay[yy, xx];
                }
            }

            // Draw nodes and labels (nodes take precedence over lines)
            foreach (var kv in positions)
            {
                var node = kv.Key;
                int x = kv.Value.x;
                int y = kv.Value.y;
                // Mark node
                if (x >= 0 && x < width && y >= 0 && y < height)
                    grid[y, x] = 'O';

                // label
                string label = node?.ToString() ?? "null";
                if (label.Length > labelMaxLength)
                    label = label.Substring(0, labelMaxLength) + "~";

                // New: prefer placing labels outside the circle along the radial direction from center
                int startX = x;
                int startY = y;
                bool placed = false;

                // Try radial placements at increasing distances
                double angle = Math.Atan2(y - cy, x - cx);
                double cos = Math.Cos(angle);
                double sin = Math.Sin(angle);
                int baseOffset = 2 + (label.Length + 1) / 2; // base distance from node
                int maxDist = Math.Max(3, Math.Min(Math.Max(width, height) / 6, 10));

                for (int dist = baseOffset; dist <= baseOffset + maxDist && !placed; dist++)
                {
                    int sx = Clamp(x + (int)Math.Round(cos * dist), 0, width - 1);
                    int sy = Clamp(y + (int)Math.Round(sin * dist), 0, height - 1);

                    if (TryPlaceLabel(sx, sy, label))
                    {
                        placed = true;
                        break;
                    }

                    // also try slight lateral nudges along perpendicular direction to avoid arrows/other labels
                    if (!placed)
                    {
                        int px = Clamp(sx - (int)Math.Round(sin * 1), 0, width - 1);
                        int py = Clamp(sy + (int)Math.Round(cos * 1), 0, height - 1);
                        if (TryPlaceLabel(px, py, label))
                        {
                            placed = true;
                            break;
                        }

                        px = Clamp(sx + (int)Math.Round(sin * 1), 0, width - 1);
                        py = Clamp(sy - (int)Math.Round(cos * 1), 0, height - 1);
                        if (TryPlaceLabel(px, py, label))
                        {
                            placed = true;
                            break;
                        }
                    }
                }

                // Fallback: previous approach (closer placements: right, left, below, above)
                if (!placed)
                {
                    int fallbackStartX = x + 2; // moved closer to the node (was +6)
                    int fallbackStartY = y;
                    if (fallbackStartX + label.Length <= width - 1)
                    {
                        placed = TryPlaceLabel(fallbackStartX, fallbackStartY, label);
                    }
                    else if (x - 2 - label.Length + 1 >= 0)
                    {
                        // place to left, hugging closer
                        placed = TryPlaceLabel(x - 2 - label.Length + 1, fallbackStartY, label);
                    }
                    else
                    {
                        // try below
                        if (y + 1 < height)
                            placed = TryPlaceLabel(Math.Max(0, x - label.Length / 2), y + 1, label);
                        else if (y - 1 >= 0)
                            placed = TryPlaceLabel(Math.Max(0, x - label.Length / 2), y - 1, label);
                    }
                }

                bool TryPlaceLabel(int sx, int sy, string lab)
                {
                    if (sx < 0 || sx + lab.Length > width || sy < 0 || sy >= height) return false;
                    for (int k = 0; k < lab.Length; k++)
                    {
                        // avoid overwriting node marker or arrows or other labels; allow overwriting line-drawing characters
                        char existing = grid[sy, sx + k];
                        if (existing == 'O') return false; // don't overwrite node
                        if (existing == '>' || existing == '<' || existing == 'v' || existing == '^') return false; // don't overwrite arrows
                        // allow overwriting box-drawing chars and spaces
                    }
                    for (int k = 0; k < lab.Length; k++)
                        grid[sy, sx + k] = lab[k];
                    return true;
                }
            }

            // Print top legend
            Console.WriteLine($"Graph visualization ({width}x{height}) - nodes: {nodes.Count}");
            // Render grid
            var sb = new StringBuilder();
            for (int yy = 0; yy < height; yy++)
            {
                sb.Clear();
                for (int xx = 0; xx < width; xx++)
                    sb.Append(grid[yy, xx]);
                Console.WriteLine(sb.ToString().TrimEnd()); // trim trailing spaces for compactness
            }

            // Local clamp helper
            static int Clamp(int v, int lo, int hi) => v < lo ? lo : (v > hi ? hi : v);
        }
    }
}
