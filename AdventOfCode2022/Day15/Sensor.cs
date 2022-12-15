using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace AdventOfCode2022.Day15
{
    class Sensor
    {
        public Point Location { get; set; }
        public Point ClosestBeacon { get; set; }
        public int Distance { get; set; }

        public Sensor(Point location, Point closestBeacon)
        {
            Location = location;
            ClosestBeacon = closestBeacon;
            Distance = Location.CityBlockDistance(ClosestBeacon);
        }
    }
}
