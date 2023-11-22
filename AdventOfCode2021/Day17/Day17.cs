using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2021.Day17
{
    public static class Day17
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileString(day, "a");

            var s1 = input.Split(": ");
            var s2 = s1[1].Split(", ");
            var y = s2[1].Substring(2).Split("..").Select(i => int.Parse(i));

            // Assuming x will settle inside the area, with some x, it can be ignored for height.
            // Assuming negative min value in y:
            //   Longest last step must be 1 more than start velocity in y direction
            int startY = y.Min() * -1 - 1;
            var result = (startY*(startY+1))/2;
            
            IO.WriteOutput(day, "a", result);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileString(day, "a");

            var s1 = input.Split(": ");
            var s2 = s1[1].Split(", ");
            var xs = s2[0].Substring(2).Split("..").Select(i => int.Parse(i)).ToList();
            var ys = s2[1].Substring(2).Split("..").Select(i => int.Parse(i)).ToList();

            var lowerLeftCorner = new Point(xs.Min(), ys.Min());
            var upperRightCorner = new Point(xs.Max(), ys.Max());

            List<int> viableXs = new List<int>();
            List<int> viableYs = new List<int>();

            for (int i = 0; i <= xs[1]; i++)
            {
                int n = 0;
                var x = 0;
                while (n < upperRightCorner.X && x < upperRightCorner.X)
                {
                    x += i - n;
                    if (x >= lowerLeftCorner.X && x <= upperRightCorner.X)
                    {
                        viableXs.Add(i);
                        break;
                    }
                    n++;
                }
            }

            for (int j = -Math.Abs(lowerLeftCorner.Y); j <= Math.Abs(lowerLeftCorner.Y); j++)
            {
                int n = 0;
                var y = 0;
                while (y > lowerLeftCorner.Y)
                {
                    y += j - n;
                    if (y >= lowerLeftCorner.Y && y <= upperRightCorner.Y)
                    {
                        viableYs.Add(j);
                        break;
                    }
                    n++;
                }
            }

            List<Point> hitsTarget = new List<Point>();

            foreach(var i in viableXs)
            {
                foreach (var j in viableYs)
                {
                    Point pos = new Point();
                    int n = 0;
                    while(pos.X <= upperRightCorner.X && pos.Y >= lowerLeftCorner.Y)
                    {
                        pos += new Point(Math.Max(i - n,0), j - n);
                        if(pos.IsInRectangle(lowerLeftCorner, upperRightCorner))
                        {
                            hitsTarget.Add(new Point(i,j));
                            break;
                        }
                        n++;
                    }
                }
            }

            IO.WriteOutput(day, "b", hitsTarget.Count());
        }
    }
}
