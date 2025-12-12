using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using Utilities;
using static System.Net.Mime.MediaTypeNames;

namespace AdventOfCode2025.Day9
{
    public static class Day9
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFilePointArray(day, "a");

            var result = input
                .SelectMany((p, i) => input
                    .Skip(i + 1)
                    .Select(q => (A: p, B: q, Area: p.RectangleArea(q))))
                .Max(p => p.Area);

            IO.WriteOutput(day, "a", result);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFilePointArray(day, "a").ToList();
            var path = new List<Point>();
            long result = 0;

            // Generate all rectangles, sorted by size
            var rectangles = input
                .SelectMany((p, i) => input
                    .Skip(i + 1)
                    .Select(q => (A: p, B: q, Area: p.RectangleArea(q))))
                .OrderByDescending(p => p.Area)
                .ToList();

            // Create path for perimiter
            path.Add(input[0]);
            input.Remove(input[0]);
            bool isX = true;
            while (input.Count() > 0)
            {
                Point next;
                if (isX)
                    next = input.First(p => p.X == path.Last().X);
                else
                    next = input.First(p => p.Y == path.Last().Y);
                path.Add(next);
                input.Remove(next);
                isX = !isX;
            }

            // Find first rectangle, that is valid.
            foreach (var pair in rectangles)
            {
                // Check that no other points appear in reactangle
                if (!path.Any(p => p.IsInInnerRectangle(
                    new Point(Math.Min(pair.A.X, pair.B.X), Math.Min(pair.A.Y, pair.B.Y)),
                    new Point(Math.Max(pair.A.X, pair.B.X), Math.Max(pair.A.Y, pair.B.Y)))))
                {
                    int crossing = 0;
                    Point insidePoint = pair.A.GetRectangleCenter(pair.B);
                    var ray = new Line(insidePoint, new Point(0, insidePoint.Y));
                    bool intersectsBox = false;
                    // For each section of the path ...
                    for (int i = 0; i < path.Count(); i++)
                    {
                        var pathLine = new Line(path[i], path[(i + 1) % path.Count()]);

                        // Get how many times an internal point crosses the perimiter (Must be odd)
                        if (ray.Crosses(pathLine))
                            crossing++;

                        // Check if any sections of the path intersects with the rectangle
                        var corners = pair.A.GetInnerRectangleCorners(pair.B);
                        if (
                            pathLine.Crosses(new Line(corners[0], corners[1]))
                            || pathLine.Crosses(new Line(corners[1], corners[2]))
                            || pathLine.Crosses(new Line(corners[2], corners[3]))
                            || pathLine.Crosses(new Line(corners[3], corners[0]))
                            )
                        {
                            intersectsBox = true;
                            break;
                        }
                    }
                    if (!intersectsBox && crossing % 2 == 1)
                    {
                        result = pair.Area;
                        break;
                    }
                }
            }

            IO.WriteOutput(day, "b", result);
        }
    }
}
