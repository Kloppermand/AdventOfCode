using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class Line
    {
        public Point P1 { get; set; }
        public Point P2 { get; set; }

        public Line() 
        {
            P1 = new Point();
            P2 = new Point();
        }

        public Line(Point p1, Point p2)
        {
            P1 = p1;
            P2 = p2;
        }

        public bool Crosses(Line other)
        {
            int minX1 = Math.Min(this.P1.X, this.P2.X);
            int maxX1 = Math.Max(this.P1.X, this.P2.X);
            int minY1 = Math.Min(this.P1.Y, this.P2.Y);
            int maxY1 = Math.Max(this.P1.Y, this.P2.Y);

            int minX2 = Math.Min(other.P1.X, other.P2.X);
            int maxX2 = Math.Max(other.P1.X, other.P2.X);
            int minY2 = Math.Min(other.P1.Y, other.P2.Y);
            int maxY2 = Math.Max(other.P1.Y, other.P2.Y);

            bool xOverlap = maxX1 >= minX2 && minX1 <= maxX2;
            bool yOverlap = maxY1 >= minY2 && minY1 <= maxY2;

            return xOverlap && yOverlap;
        }
    }
}
