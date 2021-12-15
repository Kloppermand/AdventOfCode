using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2021.Day9
{
    public static class Day9
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            int[,] grid = new int[input[0].Length, input.Length];
            for (int j = 0; j < input.Length; j++)
            {
                for (int i = 0; i < input[0].Length; i++)
                {
                    grid[i, j] = int.Parse(input[j][i].ToString());
                }
            }

            int danger = 0;
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (IsLowPoint(grid, i, j))
                        danger += grid[i, j] + 1;
                }
            }

            IO.WriteOutput(day, "a", danger.ToString());
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            Cell[,] grid = new Cell[input[0].Length, input.Length];
            for (int j = 0; j < input.Length; j++)
            {
                for (int i = 0; i < input[0].Length; i++)
                {
                    grid[i, j] = new Cell(int.Parse(input[j][i].ToString()), i,j);
                }
            }

            List<Cell> lowPoints = new();
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (IsLowPoint(grid, i, j))
                    {
                        grid[i, j].IsLowPoint = true;
                        lowPoints.Add(grid[i, j]);
                    }
                }
            }

            foreach (var point in lowPoints)
            {
                SetGroupSize(grid, point.X, point.Y);
            }

            int res = 1;
            foreach (var point in lowPoints.OrderByDescending(x => x.GroupSize).Take(3))
            {
                res *= point.GroupSize;
            }
            
            IO.WriteOutput(day, "b", res.ToString());
        }

        private static bool IsLowPoint(Cell[,] grid, int x, int y)
        {
            if (x > 0 && grid[x - 1, y].Value <= grid[x, y].Value)
                return false;
            if (x < grid.GetLength(0) - 1 && grid[x + 1, y].Value <= grid[x, y].Value)
                return false;
            if (y > 0 && grid[x, y - 1].Value <= grid[x, y].Value)
                return false;
            if (y < grid.GetLength(1) - 1 && grid[x, y + 1].Value <= grid[x, y].Value)
                return false;
            return true;
        }

        private static bool IsLowPoint(int[,] grid, int x, int y)
        {
            if (x > 0 && grid[x - 1, y] <= grid[x, y])
                return false;
            if (x < grid.GetLength(0) - 1 && grid[x + 1, y] <= grid[x, y])
                return false;
            if (y > 0 && grid[x, y - 1] <= grid[x, y])
                return false;
            if (y < grid.GetLength(1) - 1 && grid[x, y + 1] <= grid[x, y])
                return false;
            return true;
        }

        private static void SetGroupSize(Cell[,] grid, int x, int y)
        {
            List<Cell> unproccesed = new();
            grid[x, y].Visited = true;
            unproccesed.Add(grid[x, y]);
            int size = 0;
            while(unproccesed.Count>0)
            {
                unproccesed.AddRange(GetUnvisitedNeighbours(grid,unproccesed.First().X, unproccesed.First().Y));
                unproccesed.Remove(unproccesed.First());
                size++;
            }
            grid[x, y].GroupSize = size;
        }

        private static List<Cell> GetUnvisitedNeighbours(Cell[,] grid, int x, int y)
        {
            List<Cell> retList = new();
            if (x > 0 && !grid[x - 1, y].Visited && grid[x - 1, y].Value < 9)
            {
                retList.Add(grid[x - 1, y]);
                grid[x - 1, y].Visited = true;
            }
            if (x < grid.GetLength(0) - 1 && !grid[x + 1, y].Visited && grid[x + 1, y].Value < 9)
            {
                retList.Add(grid[x + 1, y]);
                grid[x + 1, y].Visited = true;
            }
            if (y > 0 && !grid[x, y - 1].Visited && grid[x, y - 1].Value < 9)
            {
                retList.Add(grid[x, y - 1]);
                grid[x, y - 1].Visited = true;
            }
            if (y < grid.GetLength(1) - 1 && !grid[x, y + 1].Visited && grid[x, y + 1].Value < 9)
            {
                retList.Add(grid[x, y + 1]);
                grid[x, y + 1].Visited = true;
            }
            return retList;
        }
    }
}
