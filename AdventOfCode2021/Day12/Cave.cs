using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day12
{
    class Cave
    {
        public string Name { get; set; }
        public List<Cave> Connected { get; set; }
        public bool Big { get; set; }
        public bool Visited { get; set; }
        public int WaysToEnd { get; set; }

        public Cave(string name)
        {
            Name = name;
            Connected = new();
            Big = Name == Name.ToUpper();
            Visited = Name.Equals("start");
            WaysToEnd = Name.Equals("end") ? 1 : 0;
        }

        public void UpdateWaysToEnd()
        {
            if (Visited) return;
            if (!Name.Equals("end")) WaysToEnd = Connected.Sum(x => x.WaysToEnd);
            if (!Big) Visited = true;
            foreach (var cave in Connected)
            {
                cave.UpdateWaysToEnd();
            }
        }
    }
}
