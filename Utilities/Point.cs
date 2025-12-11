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
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;
        public int Z { get; set; } = 0;
        public int IntValue { get; set; }
        public string StringValue { get; set; }
        public char CharValue { get; set; }

        public Point()
        {
        }
        public Point((int x, int y) point)
        {
            (X, Y) = point;
        }
        public Point((int x, int y, int z) point)
        {
            (X, Y, Z) = point;
        }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public Point(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public Point(string x, string y)
        {
            X = int.Parse(x);
            Y = int.Parse(y);
        }
        public Point(string x, string y, string z)
        {
            X = int.Parse(x);
            Y = int.Parse(y);
            Z = int.Parse(z);
        }
        public Point(string point)
        {
            var tmp = point.Replace("(", "").Replace(")", "").Split(',');
            X = int.Parse(tmp[0]);
            Y = int.Parse(tmp[1]);
            if(tmp.Length > 2)
                Z = int.Parse(tmp[2]);
        }

        public double Distance(Point other)
        {
            long xDiff = (X - other.X);
            long yDiff = (Y - other.Y);
            long zDiff = (Z - other.Z);
            return Math.Sqrt(xDiff * xDiff + yDiff * yDiff + zDiff * zDiff);
        }

        public double Distance2d(Point other)
        {
            long xDiff = (X - other.X);
            long yDiff = (Y - other.Y);
            return Math.Sqrt(xDiff * xDiff + yDiff * yDiff);
        }

        public double DistanceSquared(Point other)
        {
            long xDiff = (X - other.X);
            long yDiff = (Y - other.Y);
            long zDiff = (Z - other.Z);
            return xDiff * xDiff + yDiff * yDiff + zDiff * zDiff;
        }

        public double Distance2dSquared(Point other)
        {
            long xDiff = (X - other.X);
            long yDiff = (Y - other.Y);
            return xDiff * xDiff + yDiff * yDiff;
        }

        public int CityBlockDistance(Point other)
        {
            return Math.Abs(X - other.X) + Math.Abs(Y - other.Y) + Math.Abs(Z - other.Z);
        }

        public bool IsInRectangle(Point lowerLeftCorner, Point upperRightCorner)
        {
            return (X >= lowerLeftCorner.X && X <= upperRightCorner.X) && (Y >= lowerLeftCorner.Y && Y <= upperRightCorner.Y);
        }

        public bool IsInBox(Point lowestCorner, Point higestCorner)
        {
            return (X >= lowestCorner.X && X <= higestCorner.X) 
                && (Y >= lowestCorner.Y && Y <= higestCorner.Y)
                && (Z >= lowestCorner.Z && Z <= higestCorner.Z);
        }

        public override string ToString()
        {
            if(Z>0)
                return $"({X},{Y},{Z})";
            return $"({X},{Y})";
        }

        public string ToString(bool includeZ)
        {
            if (includeZ)
                return $"({X},{Y},{Z})";
            else
                return ToString();
        }


        public static Point operator +(Point a, Point b)
        {
            return new Point(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static Point operator -(Point a, Point b)
        {
            return new Point(a.X - b.X, a.Y - b.Y, b.Z - b.Z);
        }

        public static Point operator *(Point a, int b)
        {
            return new Point(a.X * b, a.Y * b, a.Z * b);
        }

        public static Point operator *(int a, Point b)
        {
            return b * a;
        }
        public static bool operator ==(Point a, Point b)
        {
            return a.X == b.X && a.Y == b.Y && a.Z == b.Z;
        }

        public static bool operator !=(Point a, Point b) => !(a == b);
        public bool Equals(Point other) => this == other;
        public override int GetHashCode() => (X, Y, Z).GetHashCode();
    }
}
