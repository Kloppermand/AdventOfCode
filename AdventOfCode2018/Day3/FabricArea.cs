using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2018.Day3
{
    class FabricArea
    {
        public int id { get; set; }
        public int StartX { get; set; }
        public int EndX { get; set; }
        public int StartY { get; set; }
        public int EndY { get; set; }

        public FabricArea(string definition)
        {
            // #1 @ 604,100: 17x27
            var tmp = definition.Split(" @ ");
            id = int.Parse(tmp[0].Replace("#", ""));

            tmp = tmp[1].Split(": ");

            var start = tmp[0].Split(",");
            StartX = int.Parse(start[0]);
            StartY = int.Parse(start[1]);
            
            var end = tmp[1].Split("x");
            EndX = int.Parse(end[0]) + StartX;
            EndY = int.Parse(end[1]) + StartY;
        }
    }

}
