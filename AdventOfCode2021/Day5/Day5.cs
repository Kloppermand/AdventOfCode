using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2021.Day5
{
    public static class Day5
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            List<Line> lines = new();
            foreach (var line in input)
            {
                lines.Add(new Line(line));
            }

            int[,] board = CreateBoard(lines, true);

            IO.WriteOutput(day, "a",GetOverlappingCount(board).ToString());
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            List<Line> lines = new();
            foreach (var line in input)
            {
                lines.Add(new Line(line));
            }

            int[,] board = CreateBoard(lines, false);

            IO.WriteOutput(day, "b", GetOverlappingCount(board).ToString());
        }

        private static int[,] CreateBoard(List<Line>lines, bool onlyStraight)
        {
            (int maxX, int maxY) = GetMaxValues(lines);
            int[,] board = new int[maxX + 1, maxY + 1];
            foreach (var line in lines)
            {
                if (line.IsStraight || !onlyStraight)
                {
                    foreach (var point in line.Contains)
                    {
                        board[point.X, point.Y]++;
                    }
                }
            }

            return board;
        }

        private static (int, int) GetMaxValues(List<Line> lines)
        {

            int maxX1 = lines.Max(x => x.Start.X);
            int maxX2 = lines.Max(x => x.End.X);
            int maxX = maxX1 > maxX2 ? maxX1 : maxX2;

            int maxY1 = lines.Max(x => x.Start.Y);
            int maxY2 = lines.Max(x => x.End.Y);
            int maxY = maxY1 > maxY2 ? maxY1 : maxY2;

            return (maxX, maxY);
        }

        private static int GetOverlappingCount(int[,] board)
        {
            int pointsThatOverlap = 0;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] > 1)
                        pointsThatOverlap++;
                }
            }
            return pointsThatOverlap;
        }
    }
}
