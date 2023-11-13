using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class Point : IEquatable<Point>
    {
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int IntValue { get; set; }
        public string StringValue { get; set; }

        public Point()
        {
            X = 0;
            Y = 0;
        }
        public Point((int x, int y) point)
        {
            (X, Y) = point;
        }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public Point(string x, string y)
        {
            X = int.Parse(x);
            Y = int.Parse(y);
        }
        public Point(string point)
        {
            var tmp = point.Replace("(", "").Replace(")", "").Split(',');
            X = int.Parse(tmp[0]);
            Y = int.Parse(tmp[1]);
        }

        public double Distance(Point other)
        {
            int xDiff = (X - other.X);
            int yDiff = (Y - other.Y);
            return Math.Sqrt(xDiff * xDiff + yDiff * yDiff);
        }

        public int CityBlockDistance(Point other)
        {
            return Math.Abs(X - other.X) + Math.Abs(Y - other.Y);
        }

        public override string ToString()
        {
            return $"({X},{Y})";
        }

        public static Point operator +(Point a, Point b)
        {
            return new Point(a.X + b.X, a.Y + b.Y);
        }
        public static bool operator ==(Point a, Point b)
        {
            return a.X == b.X && a.Y == b.Y;
        }

        public static bool operator !=(Point a, Point b) => !(a == b);
        public bool Equals(Point other) => this == other;
        public override int GetHashCode() => (X, Y).GetHashCode();
    }
}
