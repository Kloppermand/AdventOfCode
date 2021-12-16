using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2021.Day11
{
    public static class Day11
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var grid = IO.ReadInputFileInt2DArray(day, "a");
            int explosions = 0;
            int nSteps = 100;

            for (int step = 0; step < nSteps; step++)
            {
                explosions = DoStep(grid);
            }

            IO.WriteOutput(day, "a", explosions.ToString());
        }
        public static void CalculateB()
        {
            var grid = IO.ReadInputFileInt2DArray(day, "a");
            int steps = 0;
            
            while(Get2DMax(grid)>0)
            {
                DoStep(grid);
                steps++;
            }


            IO.WriteOutput(day, "b", steps.ToString());
        }

        private static void Explode(int[,] grid, int i, int j)
        {
            int maxI = grid.GetLength(0) - 1;
            int maxJ = grid.GetLength(1) - 1;
            if (i > 0)
            {
                if (j > 0) grid[i - 1, j - 1]++;
                grid[i - 1, j]++;
                if (j < maxJ) grid[i - 1, j + 1]++;
            }
            if (j > 0) grid[i, j - 1]++;
            if (j < maxJ) grid[i, j + 1]++;
            if (i < maxI)
            {
                if (j > 0) grid[i + 1, j - 1]++;
                grid[i + 1, j]++;
                if (j < maxJ) grid[i + 1, j + 1]++;
            }
        }

        private static int DoStep(int[,] grid)
        {
            int explosions = 0;
            //Add one
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    grid[i, j]++;
                }
            }
            //Explosions
            while (Get2DMax(grid) > 9)
            {
                for (int i = 0; i < grid.GetLength(0); i++)
                {
                    for (int j = 0; j < grid.GetLength(1); j++)
                    {
                        if (grid[i, j] > 9)
                        {
                            Explode(grid, i, j);
                            grid[i, j] = -100;
                            explosions++;
                        }
                    }
                }
            }
            //Set exploded to zero
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j] < 0)
                    {
                        grid[i, j] = 0;
                    }
                }
            }
            //Console.WriteLine(step+1 + ":" + explosions);
            //IO.Print2DArray(grid);
            return explosions;
        }
        private static int Get2DMax(int[,] array)
        {
            int max = 0;
            foreach (var number in array)
            {
                if (number > max) max = number;
            }
            return max;
        }
    }
}
