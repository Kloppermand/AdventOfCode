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

        public void RunCommandA(string command)
        {
            string[] splitCommand = command.Split(' ');
            string direction = splitCommand[0];
            int distance = int.Parse(splitCommand[1]);

            switch (direction)
            {
                case "forward":
                    Horizontal += distance;
                    break;
                case "up":
                    Depth -= distance;
                    break;
                case "down":
                    Depth += distance;
                    break;
                default:
                    break;
            }
        }
        
        public void RunCommandB(string command)
        {
            string[] splitCommand = command.Split(' ');
            string direction = splitCommand[0];
            int distance = int.Parse(splitCommand[1]);

            switch (direction)
            {
                case "forward":
                    Horizontal += distance;
                    Depth += Aim * distance;
                    break;
                case "up":
                    Aim -= distance;
                    break;
                case "down":
                    Aim += distance;
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
