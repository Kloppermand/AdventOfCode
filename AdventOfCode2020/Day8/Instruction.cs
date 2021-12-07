using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day8
{
    class Instruction
    {
        public string Operation { get; set; }
        public int Argument { get; set; }
        public bool BeenRun { get; set; }
        public Instruction(string raw)
        {
            var tempSplit = raw.Split(' ');
            Operation = tempSplit[0];
            Argument = tempSplit[1][0] == '+' ? int.Parse(tempSplit[1][1..]) : -int.Parse(tempSplit[1][1..]);
            BeenRun = false;
        }
    }

}
