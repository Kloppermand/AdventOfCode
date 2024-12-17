using MathNet.Numerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml.Schema;
using Utilities;

namespace AdventOfCode2024.Day14
{
    public static class Day14
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringArray(day, "a");

            int h = 103;
            int w = 101;

            int Q1 = 0;
            int Q2 = 0;
            int Q3 = 0;
            int Q4 = 0;

            foreach (var line in input)
            {
                var groups = Regex.Matches(line, @"p=(-?\d+),(-?\d+) v=(-?\d+),(-?\d+)").First().Groups;
                long px = long.Parse(groups[1].Value);
                long py = long.Parse(groups[2].Value);
                long vx = long.Parse(groups[3].Value);
                long vy = long.Parse(groups[4].Value);

                px = (px + (vx + w) * 100) % w;
                py = (py + (vy + h) * 100) % h;

                if (px > w / 2)
                {
                    if (py > h / 2)
                        Q1++;
                    else if (py < h / 2)
                        Q2++;
                }
                else if (px < w / 2)
                {
                    if (py > h / 2)
                        Q3++;
                    else if (py < h / 2)
                        Q4++;
                }
            }

            IO.WriteOutput(day, "a", Q1 * Q2 * Q3 * Q4);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArray(day, "a");

            bool printStuff = false;
            int h = 103;
            int w = 101;
            List<double> variance = new();

            List<(int px, int py, int vx, int vy)> robots = new();

            foreach (var line in input)
            {
                var groups = Regex.Matches(line, @"p=(-?\d+),(-?\d+) v=(-?\d+),(-?\d+)").First().Groups;
                robots.Add((int.Parse(groups[1].Value), int.Parse(groups[2].Value), (int.Parse(groups[3].Value) + w) % w, (int.Parse(groups[4].Value) + h) % h));
            }

            for (int i = 0; i < 10000; i++)
            {
                if (printStuff)
                    Console.WriteLine(i + 1);
                var field = new char[w, h];
                for (int j = 0; j < w; j++)
                {
                    for (int k = 0; k < h; k++)
                        field[j, k] = ' ';
                }

                for (int j = 0; j < robots.Count; j++)
                {
                    robots[j] = (
                        (robots[j].px + robots[j].vx) % w,
                        (robots[j].py + robots[j].vy) % h,
                        robots[j].vx,
                        robots[j].vy
                        );

                    field[robots[j].px, robots[j].py] = '#';
                }

                var xs = robots.Select(x => x.px);
                var ys = robots.Select(x => x.py);
                var xAvg = xs.Average();
                var yAvg = ys.Average();
                var xVar = xs.Sum(x => Math.Abs(x - xAvg));
                var yVar = ys.Sum(y => Math.Abs(y - yAvg));

                variance.Add(xVar + yVar);


                // Interesting prints:
                // i % h == 83
                // i % w == 27
                // i + 1 == 7603

                if (printStuff && i % 101 == 27)
                {
                    for (int j = 0; j < w; j++)
                    {
                        for (int k = 0; k < h; k++)
                            Console.Write(field[j, k]);
                        Console.WriteLine();
                    }
                }
            }

            IO.WriteOutput(day, "b", variance.IndexOf(variance.Min())+1);
        }
    }
}
