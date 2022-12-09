using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day9
{
    class Rope
    {
        public List<Knot> Knots { get; set; }
        public List<(int, int)> Visited { get; set; }
        public Rope(int length)
        {
            Knots = new();
            for (int i = 0; i < length; i++)
            {
                Knots.Add(new Knot());
            }
            Visited = new();
        }

        public Rope UpdateRope(string direction, int moveCount)
        {
            for (int i = 0; i < moveCount; i++)
            {
                switch (direction)
                {
                    case ("R"):
                        Knots[0].X++;
                        break;
                    case ("L"):
                        Knots[0].X--;
                        break;
                    case ("U"):
                        Knots[0].Y++;
                        break;
                    case ("D"):
                        Knots[0].Y--;
                        break;
                    default:
                        break;
                }

                for (int j = 0; j < Knots.Count() - 1; j++)
                {
                    int x1 = Knots[j].X;
                    int y1 = Knots[j].Y;
                    int x2 = Knots[j+1].X;
                    int y2 = Knots[j+1].Y;
                    int xDiff = x1 - x2;
                    int yDiff = y1 - y2;

                    if (Math.Abs(xDiff) > 1 || Math.Abs(yDiff) > 1)
                    {
                        Knots[j+1].X += xDiff != 0 ? xDiff / Math.Abs(xDiff) : 0;
                        Knots[j+1].Y += yDiff != 0 ? yDiff / Math.Abs(yDiff) : 0;
                    }
                }

                Visited.Add((Knots[^1].X, Knots[^1].Y));
            }
            return this;
        }

        public int GetUniqueVisitCount()
        {
            return Visited.Distinct().Count();
        }
    }
}
