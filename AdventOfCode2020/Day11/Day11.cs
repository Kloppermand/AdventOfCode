using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2020.Day11
{
    public static class Day11
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var grid = IO.ReadInputFileStringArray(day, "a");
            int h = grid.Length;
            int w = grid[0].Length;
            string[] oldGrid = new string[w];
            grid.CopyTo(oldGrid, 0);
            for (int j = 0; j < h; j++)
            {
                for (int i = 0; i < w; i++)
                {
                    if(grid[j][i] != '.')
                    {
                        if (GetNeighbours(oldGrid, i, j) == 0) ;//REMOVE ;
                            //grid[j]
                    }
                }
            }


            string result = "NOT SOLVED YET";
            IO.WriteOutput(day, "a", result);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArray(day, "a");



            string result = "NOT SOLVED YET";
            IO.WriteOutput(day, "b", result);
        }

        private static int GetNeighbours(string[] grid, int x, int y)
        {
            int neighbours = 0;
            for (int j = y - 1; j < y + 2; j++)
            {
                for (int i = x - 1; i < x + 2; i++)
                {
                    if (i > 0 && i < grid[0].Length && j > 0 && j < grid.Length)
                    {
                        if(grid[j][i] == '#')
                        {
                            neighbours++;
                        }
                    }    
                }
            }
            return neighbours;
        }
    }
}
