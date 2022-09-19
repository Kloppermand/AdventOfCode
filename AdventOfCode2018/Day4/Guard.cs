using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2018.Day4
{
    class Guard
    {
        public int id { get; set; }
        public int[] timesAsleep { get; set; }
        public DateTime lastFellAsleep { get; set; }

        public Guard()
        {
            timesAsleep = new int[60];
        }
    }
}
