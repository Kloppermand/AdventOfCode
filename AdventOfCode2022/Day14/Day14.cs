using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2022.Day14
{
    public static class Day14
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringArray(day, "a");

            var board = CreateBoard(input,false, out int xOffset);
            board = SimulateSand(board, xOffset);

            //IO.PrintArray(board);

            IO.WriteOutput(day, "a", CountSand(board));
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArray(day, "a");

            var board = CreateBoard(input, true, out int xOffset);
            board = SimulateSand(board, xOffset);

            //IO.PrintArray(board);

            IO.WriteOutput(day, "b", CountSand(board));
        }

        private static (int, int, int, int) GetCaveBounds(string[] input)
        {

            List<int> Xs = new();
            List<int> Ys = new();

            foreach (var path in input)
            {
                foreach (var point in path.Split(" -> "))
                {
                    var tmp = point.Split(',');
                    Xs.Add(int.Parse(tmp[0]));
                    Ys.Add(int.Parse(tmp[1]));
                }
            }

            return (Xs.Min(), Xs.Max(), Ys.Min(), Ys.Max());
        }

        private static bool CompareBoards(string[] board1, string[] board2)
        {
            for (int i = 0; i < board1.Count(); i++)
            {
                if (!board1[i].Equals(board2[i]))
                    return false;
            }
            return true;
        }

        private static string[] CreateBoard(string[] input, bool createFloor, out int xOffset)
        {
            var (xMin, xMax, yMin, yMax) = GetCaveBounds(input);
            if(createFloor)
            {
                yMax += 2;
                xMin -= 200;
                xMax += 200;
                input = input.Append($"{xMin},{yMax} -> {xMax},{yMax}").ToArray();
            }
            xOffset = xMin;

            string[] board = new string[yMax + 1];
            for (int y = 0; y < yMax + 1; y++)
            {
                board[y] = new('.', xMax - xMin + 1);
            }

            foreach (var row in input)
            {
                var paths = row.Split(" -> ").Select(x => x.Split(',')).ToList();
                for (int i = 0; i < paths.Count - 1; i++)
                {
                    var p1X = int.Parse(paths[i][0]);
                    var p1Y = int.Parse(paths[i][1]);
                    var p2X = int.Parse(paths[i + 1][0]);
                    var p2Y = int.Parse(paths[i + 1][1]);

                    if (p1X != p2X)
                    {
                        for (int j = Math.Min(p1X, p2X); j <= Math.Max(p1X, p2X); j++)
                        {
                            board[p1Y] = board[p1Y].Remove(j - xMin, 1).Insert(j - xMin, "#");
                        }
                    }

                    if (p1Y != p2Y)
                    {
                        for (int j = Math.Min(p1Y, p2Y); j <= Math.Max(p1Y, p2Y); j++)
                        {
                            board[j] = board[j].Remove(p1X - xMin, 1).Insert(p1X - xMin, "#");
                        }
                    }
                }
            }

            return board;
        }

        private static int CountSand(string[] board)
        {
            int sand = 0;
            foreach (var row in board)
            {
                sand += row.Count(x => x == 'o');
            }
            return sand;
        }

        private static string[] SimulateSand(string[] board, int xOffset)
        {

            var oldBoard = new string[board.Length];

            do
            {
                board.CopyTo(oldBoard, 0);

                var sandX = 500 - xOffset;
                var sandY = 0;
                int oldSandY;
                do
                {
                    oldSandY = sandY;
                    if (board[sandY + 1][sandX] == '.')
                    {
                        sandY++;
                    }
                    else if (sandX > 0 && board[sandY + 1][sandX - 1] == '.')
                    {
                        sandY++;
                        sandX--;
                    }
                    else if (sandX < board[sandY + 1].Length - 1 && board[sandY + 1][sandX + 1] == '.')
                    {
                        sandY++;
                        sandX++;
                    }
                } while (sandY > oldSandY && sandY < board.Count()-1);

                if (sandY < board.Count() && sandX > 0 && sandX < board[sandY].Length - 1)
                    board[sandY] = board[sandY].Remove(sandX, 1).Insert(sandX, "o");

            } while (!CompareBoards(board, oldBoard));

            return board;
        }
    }
}
