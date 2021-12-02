using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day2
{
    enum Direction
    {
        forward,
        up,
        down
    }
    class Command
    {
        public Direction direction { get; set; }
        public int distance { get; set; }
        public void ParseCommand(string command)
        {
            string[] splitCommand = command.Split(' ');
            Enum.TryParse(splitCommand[0], out Direction tempDirection);
            direction = tempDirection;
            distance = int.Parse(splitCommand[1]);

        }
    }


}
