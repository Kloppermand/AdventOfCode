using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2025.Day7
{
    public static class Day7
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileChar2DArray(day, "a");
            int result = 0;
            for (int i = 1; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    if (input[i, j] != '.')
                        continue;

                    if (input[i - 1, j] == 'S' || input[i - 1, j] == '|')
                        input[i, j] = '|';

                    if (j > 0 && input[i - 1, j - 1] == '|' && input[i, j - 1] == '^')
                    {
                        input[i, j] = '|';
                        result++;
                        continue;
                    }

                    if (j < input.GetLength(1) - 1 && input[i - 1, j + 1] == '|' && input[i, j + 1] == '^')
                    {
                        input[i, j] = '|';

                        continue;
                    }
                }
            }

            IO.WriteOutput(day, "a", result);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileChar2DArray(day, "a");

            var grid = new long[input.GetLength(0), input.GetLength(1)];

            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    if (input[i, j] == 'S')
                        grid[i, j] = -2;
                    else if (input[i, j] == '^')
                        grid[i, j] = -1;
                    else
                        grid[i, j] = 0;
                }
            }

            for (int i = 1; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j] < 0)
                        continue;

                    if (grid[i - 1, j] == -2)
                        grid[i, j] = 1;

                    if (grid[i - 1, j] > 0)
                        grid[i, j] = grid[i - 1, j];

                    if (j > 0 && grid[i - 1, j - 1] >0 && grid[i, j - 1] == -1)
                    {
                        grid[i, j] = grid[i, j] + grid[i-1, j-1] ;
                    }

                    if (j < grid.GetLength(1) - 1 && grid[i - 1, j + 1] > 0 && grid[i, j + 1] == -1)
                    {
                        grid[i, j] = grid[i, j] + grid[i - 1, j + 1];
                    }
                }
            }

            //IO.Print2DArray(grid, ",",3);

            var result = grid.Cast<long>()
                       .Skip(grid.GetLength(0) * (grid.GetLength(1)-1))
                       .Sum()-1;
            IO.WriteOutput(day, "b", result);
        }
    }
}
