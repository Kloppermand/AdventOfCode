using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2018.Day6
{
    public static class Day6
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            List<Point> points = new();
            foreach (var point in input)
            {
                points.Add(new Point(point));
            }

            var minX = points.Min(p => p.X);
            var maxX = points.Max(p => p.X);
            var minY = points.Min(p => p.Y);
            var maxY = points.Max(p => p.Y);
            Point p;
            for(int i  = minX; i <= maxX; i++)
            {
                for (int j = minY; j <= maxY; j++)
                {
                    Point here = new Point(i, j);
                    var dists = new Dictionary<Point, int>();
                    foreach (var point in  points)
                    {
                        dists.Add(point, point.CityBlockDistance(here));
                    }

                    var closesPoint = dists.MinBy(d => d.Value);
                    if (dists.Values.Count(d => d == closesPoint.Value) == 1)
                        closesPoint.Key.IntValue++;

                    if (i == minX || i == maxX || j == minY || j == maxY)
                        closesPoint.Key.StringValue = "Edge";
                }
            }
            
            var result = points.Where(p => p.StringValue != "Edge").Max(p => p.IntValue);
            
            IO.WriteOutput(day, "a", result);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            List<Point> points = new();
            foreach (var point in input)
            {
                points.Add(new Point(point));
            }

            var minX = points.Min(p => p.X);
            var maxX = points.Max(p => p.X);
            var minY = points.Min(p => p.Y);
            var maxY = points.Max(p => p.Y);
            int safe = 0;
            int safeDist = 10000;
            for (int i = minX; i <= maxX; i++)
            {
                for (int j = minY; j <= maxY; j++)
                {
                    if (points.Sum(p => p.CityBlockDistance(new Point(i, j))) < safeDist)
                        safe++;
                }
            }

            IO.WriteOutput(day, "b", safe);
        }
    }
}
