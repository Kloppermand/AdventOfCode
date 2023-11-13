using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace AdventOfCode2019.Day3
{
    internal class Wire
    {
        public string Definition { get; set; }
        public List<string> DefinitionList { get; set; }
        public List<Point> Visits { get; set; } = new List<Point>();
        public Wire(string definition) 
        {
            Definition = definition;
            DefinitionList = Definition.Split(',').ToList();

            var location = new Point();

            foreach (string action in DefinitionList) 
            {
                var direction = action[0];
                var value = int.Parse(action[1..]);

                for (int i = 0;i < value; i++)
                {
                    switch (direction)
                    {
                        case 'U':
                            location += new Point(0, 1);
                            break;
                        case 'D':
                            location += new Point(0, -1);
                            break;
                        case 'R':
                            location += new Point(1, 0);
                            break;
                        case 'L':
                            location += new Point(-1, 0);
                            break;
                        default:
                            break;
                    }

                    Visits.Add(location);   
                }
            }
        }

        public int StepsToPoint(Point p)
        {
            return Visits.FindIndex(point => point == p)+1;
        }
    }
}
