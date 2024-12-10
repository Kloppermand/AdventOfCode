using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Utilities;

namespace AdventOfCode2024.Day8
{
    public static class Day8
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            HashSet<Point> antiNodes = new();
            int h = input.Length;
            int w = input[0].Length;
            List<Point> antennas = GetAntennas(input, h, w);

            var uniqueFreqs = antennas.Select(x => x.CharValue).Distinct();

            foreach (var freq in uniqueFreqs)
            {
                var filteredAntennas = antennas.Where(x => x.CharValue == freq);
                var pairs = filteredAntennas.SelectMany((first, index) => filteredAntennas.Skip(index + 1).Select(second => (first, second)));
                foreach (var pair in pairs)
                {
                    var difference = pair.first - pair.second;
                    antiNodes.Add(pair.first + difference);
                    antiNodes.Add(pair.second - difference);
                }
            }
            int result = antiNodes.Where(point => point.X >= 0 && point.X < w && point.Y >= 0 && point.Y < h).Count();
            IO.WriteOutput(day, "a", result);
        }

        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            HashSet<Point> antiNodes = new();
            int h = input.Length;
            int w = input[0].Length;
            List<Point> antennas = GetAntennas(input, h, w);

            var uniqueFreqs = antennas.Select(x => x.CharValue).Distinct();

            foreach (var freq in uniqueFreqs)
            {
                var filteredAntennas = antennas.Where(x => x.CharValue == freq);
                var pairs = filteredAntennas.SelectMany((first, index) => filteredAntennas.Skip(index + 1).Select(second => (first, second)));
                foreach (var pair in pairs)
                {
                    var difference = pair.first - pair.second;
                    for (int i = 0; i < w; i++)
                    {
                    antiNodes.Add(pair.first + difference * i);
                    antiNodes.Add(pair.second - difference * i);
                    }
                }
            }
            int result = antiNodes.Where(point => point.X >= 0 && point.X < w && point.Y >= 0 && point.Y < h).Count();
            IO.WriteOutput(day, "b", result);
        }

        private static List<Point> GetAntennas(string[] input, int h, int w)
        {
            List<Point> antennas = new();
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    if (input[i][j] != '.')
                        antennas.Add(new(i, j) { CharValue = input[i][j] });
                }
            }

            return antennas;
        }
    }
}
