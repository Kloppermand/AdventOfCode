using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2018.Day3
{
    public static class Day3
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;
        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            var areas = GetFabricAreas(input);
            var fabric = InitializeFabric(1000);
            PopulateFabric(fabric, areas);

            int totalOverlap = fabric.Sum(x => x.Count(y => y > 1));

            IO.WriteOutput(day, "a", totalOverlap);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            var areas = GetFabricAreas(input);
            var fabric = InitializeFabric(1000);
            PopulateFabric(fabric, areas);

            int separateArea = 0;
            foreach (var area in areas)
            {
                bool candidate = true;
                for (int x = area.StartX; x < area.EndX; x++)
                {
                    for (int y = area.StartY; y < area.EndY; y++)
                    {
                        candidate = fabric[x][y] < 2;
                        if (!candidate) break;
                    }
                    if (!candidate) break;
                }
                if (candidate)
                {
                    separateArea = area.id;
                    break;
                }
            }

            IO.WriteOutput(day, "b", separateArea);
        }

        private static List<FabricArea> GetFabricAreas(string[] input)
        {
            List<FabricArea> areas = new();
            foreach (var area in input)
            {
                areas.Add(new(area));
            }

            return areas;
        }

        private static int[][] InitializeFabric(int n)
        {
            int[][] fabric = new int[n][];
            for (int i = 0; i < fabric.Length; i++)
            {
                fabric[i] = new int[n];
            }

            return fabric;
        }

        private static void PopulateFabric(int[][] fabric, List<FabricArea> areas)
        {
            foreach (var area in areas)
            {
                for (int x = area.StartX; x < area.EndX; x++)
                {
                    for (int y = area.StartY; y < area.EndY; y++)
                    {
                        fabric[x][y]++;
                    }
                }
            }
        }
    }
}
