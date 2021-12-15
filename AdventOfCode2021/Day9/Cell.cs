using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day9
{
    class Cell
    {
        public int Value { get; set; }
        public bool Visited { get; set; }
        public bool IsLowPoint { get; set; }
        public int GroupSize { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Cell(int value, int x, int y)
        {
            Value = value;
            Visited = false;
            IsLowPoint = false;
            X = x;
            Y = y;
        }
    }

}
