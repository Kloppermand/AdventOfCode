using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day4
{
    class BoardNumber
    {
        public string Value { get; set; }
        public bool Drawn { get; set; }

        public BoardNumber(string value)
        {
            Value = value;
            Drawn = false;
        }
    }
}
