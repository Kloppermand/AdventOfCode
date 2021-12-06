using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day5
{
    class Line
    {
        public Point Start { get; set; }
        public Point End { get; set; }
        public List<Point> Contains { get; set; }
        public bool IsStraight { get; set; }
        public double a { get; set; }
        public int b { get; set; }

        public Line(string points)
        {
            var tempPoints = points.Split(" -> ");
            Setup(new Point(tempPoints[0]), new Point(tempPoints[1]));
        }
        public Line(Point start, Point end)
        {
            Setup(start, end);
        }

        public bool ContainsPoint(Point other)
        {
            foreach (var point in Contains)
            {
                if (other.X == point.X && other.Y == point.Y)
                    return true;
            }
            return false;
        }

        private void Setup(Point start, Point end)
        {
            Contains = new();
            Start = start;
            End = end;
            IsStraight = Start.X == End.X || Start.Y == End.Y;
            if (End.X != Start.X)
            {
                a = (End.Y - Start.Y) / ((double)(End.X - Start.X));
                b = (int)(Start.Y - (a * (double)Start.X));
                var p1 = Start.X < End.X ? Start : End;
                var p2 = Start.X < End.X ? End : Start;
                int currentX = p1.X;
                while (currentX <= p2.X)
                {
                    double currentY = a * currentX + b;
                    if (currentY == Math.Floor(currentY))
                        Contains.Add(new Point(currentX, (int)currentY));

                    currentX++;
                }
            }
            else
            {
                var p1 = Start.Y < End.Y ? Start : End;
                var p2 = Start.Y < End.Y ? End : Start;
                for (int i = p1.Y; i <= p2.Y; i++)
                {
                    Contains.Add(new Point(p1.X, i));
                }
            }
        }
    }
}
