using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Reflection;
using Utilities;


using System;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.ComponentModel.Design;

namespace AdventOfCode2025.Day8
{
    public static class Day8
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringArray(day, "a");

            int n = input.Length > 25 ? 1000 : 10;

            var points = input.Select(p => new Point(p)).ToList();

            var pairs = points
                .SelectMany((p, i) => points
                    .Skip(i + 1)
                    .Select(q => (A: p, B: q, Distance: p.DistanceSquared(q))))
                .OrderBy(t => t.Distance)
                .Take(n).ToList();

            int nextNetwork = 1;
            foreach (var current in pairs)
            {
                var A = points.First(p => p == current.B);
                var B = points.First(p => p == current.A);

                if (A.IntValue == 0 && B.IntValue == 0)
                {
                    // New network
                    A.IntValue = nextNetwork;
                    B.IntValue = nextNetwork;
                    nextNetwork++;
                }
                else if (A.IntValue > 0 && B.IntValue == 0)
                {
                    // Add B to A's network
                    B.IntValue = A.IntValue;
                }
                else if (A.IntValue == 0 && B.IntValue > 0)
                {
                    // Add A to B's network
                    A.IntValue = B.IntValue;
                }
                else if (A.IntValue > 0 && B.IntValue > 0 && A.IntValue == B.IntValue)
                {
                    // Already in same network
                }
                else
                {
                    // Merge networks
                    int tmp = B.IntValue;
                    foreach (var point in points.Where(p => p.IntValue == tmp))
                        point.IntValue = A.IntValue;
                }
            }

            var orderedGroups = points
            .Where(p => p.IntValue > 0)
            .GroupBy(p => p.IntValue)
            .Select(g => new { NetworkId = g.Key, Size = g.Count(), Members = g.ToList() })
            .OrderByDescending(g => g.Size);

            var result = orderedGroups.ElementAt(0).Size * orderedGroups.ElementAt(1).Size * orderedGroups.ElementAt(2).Size;
            IO.WriteOutput(day, "a", result);
        }

        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            var points = input.Select(p => new Point(p)).ToList();

            var pairs = points
                .SelectMany((p, i) => points
                    .Skip(i + 1)
                    .Select(q => (A: p, B: q, Distance: p.DistanceSquared(q))))
                .OrderBy(t => t.Distance)
                .ToList();

            long result = 0;

            int nextNetwork = 1;
            foreach (var current in pairs)
            {
                var A = points.First(p => p == current.B);
                var B = points.First(p => p == current.A);

                if (A.IntValue == 0 && B.IntValue == 0)
                {
                    // New network
                    A.IntValue = nextNetwork;
                    B.IntValue = nextNetwork;
                    nextNetwork++;
                }
                else if (A.IntValue > 0 && B.IntValue == 0)
                {
                    // Add B to A's network
                    B.IntValue = A.IntValue;
                }
                else if (A.IntValue == 0 && B.IntValue > 0)
                {
                    // Add A to B's network
                    A.IntValue = B.IntValue;
                }
                else if (A.IntValue > 0 && B.IntValue > 0 && A.IntValue == B.IntValue)
                {
                    // Already in same network
                }
                else
                {
                    // Merge networks
                    int tmp = B.IntValue;
                    foreach (var point in points.Where(p => p.IntValue == tmp))
                        point.IntValue = A.IntValue;
                }

                if (points.All(p => p.IntValue == points.First().IntValue))
                {
                    result = (long)A.X * (long)B.X;
                    break;
                }
            }

            IO.WriteOutput(day, "b", result);
        }
    }
}
