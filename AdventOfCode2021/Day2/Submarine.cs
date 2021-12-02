using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day2
{
    class Submarine
    {
        public int Horizontal { get; set; }
        public int Depth { get; set; }
        public int Aim { get; set; }

        public void RunCommandA(Command command)
        {
            switch (command.direction)
            {
                case Direction.forward:
                    Horizontal += command.distance;
                    break;
                case Direction.up:
                    Depth -= command.distance;
                    break;
                case Direction.down:
                    Depth += command.distance;
                    break;
                default:
                    break;
            }
        }
        
        public void RunCommandB(Command command)
        {
            switch (command.direction)
            {
                case Direction.forward:
                    Horizontal += command.distance;
                    Depth += Aim * command.distance;
                    break;
                case Direction.up:
                    Aim -= command.distance;
                    break;
                case Direction.down:
                    Aim += command.distance;
                    break;
                default:
                    break;
            }
        }

        public int CalculateResult()
        {
            return Horizontal * Depth;
        }

    }
}
