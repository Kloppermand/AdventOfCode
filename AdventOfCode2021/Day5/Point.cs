using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day5
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(string coordinates)
        {
            var temp = coordinates.Split(',');
            X = int.Parse(temp[0]);
            Y = int.Parse(temp[1]);
        }
        
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
