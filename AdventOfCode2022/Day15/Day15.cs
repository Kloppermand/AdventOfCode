using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2022.Day15
{
    public static class Day15
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            int y = 2000000;

            HashSet<int> notBeaconX = new();

            foreach (var row in input)
            {
                var tmp = row.Split(' ');
                var currentSensor = new Sensor(
                     new(tmp[2][2..^1], tmp[3][2..^1]),
                     new(tmp[8][2..^1], tmp[9][2..])
                );

                var distFromLine = currentSensor.Distance - Math.Abs(y - currentSensor.Location.Y);
                for (int x = currentSensor.Location.X - distFromLine; x <= currentSensor.Location.X + distFromLine; x++)
                {
                    if (!(currentSensor.ClosestBeacon.Y == y && currentSensor.ClosestBeacon.X == x))
                        notBeaconX.Add(x);
                }
            }

            IO.WriteOutput(day, "a", notBeaconX.Count());
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            int bound = 4000000;

            List<Sensor> sensors = new();
            HashSet<(int, int)> possibleBeacon = new();

            foreach (var row in input)
            {
                var tmp = row.Split(' ');
                var currentSensor = new Sensor(
                     new(tmp[2][2..^1], tmp[3][2..^1]),
                     new(tmp[8][2..^1], tmp[9][2..])
                );
                sensors.Add(currentSensor);
                Console.WriteLine("Running sensor " + currentSensor.Location.ToString());

                for (int i = -currentSensor.Distance-1; i <= currentSensor.Distance+1; i++)
                {
                    int x = currentSensor.Location.X + i;
                    int y = currentSensor.Location.Y + Math.Abs(i) - currentSensor.Distance - 1;
                    int otherY = currentSensor.Location.Y - (y - currentSensor.Location.Y);
                    if (x >= 0 && x <= bound && y >= 0 && y <= bound)
                    {
                        possibleBeacon.Add((x, y));
                    }
                    if (x >= 0 && x <= bound && otherY >= 0 && otherY <= bound)
                    {
                        possibleBeacon.Add((x, otherY));
                    }
                     
                }
            }

            foreach (var sensor in sensors)
            {
                Console.WriteLine("Removing points from range of sensor " + sensor.Location.ToString());
                List<(int, int)> toRemove = new();
                foreach (var candidate in possibleBeacon)
                {
                    if (sensor.Location.CityBlockDistance(new Point(candidate)) <= sensor.Distance)
                        toRemove.Add(candidate);
                }
                foreach (var point in toRemove)
                {
                    possibleBeacon.Remove(point);
                }
            }

            var (xSingle, ySingle) = possibleBeacon.First();

            IO.WriteOutput(day, "b", (long)xSingle * (long)bound + (long)ySingle);
        }
    }
}
