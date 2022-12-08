using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2022.Day8
{
    public static class Day8
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileInt2DArray(day, "a");
            List<(int, int)> visible = new();

            for (int x = 0; x <= input.GetUpperBound(0); x++)
            {
                // Down to up
                int currentTree = -1;
                for (int y = 0; y <= input.GetUpperBound(1); y++)
                {
                    if (input[x, y] > currentTree)
                    {
                        visible.Add((x, y));
                        currentTree = input[x, y];
                    }
                }

                // Up to down
                currentTree = -1;
                for (int y = input.GetUpperBound(1); y >= 0; y--)
                {
                    if (input[x, y] > currentTree)
                    {
                        visible.Add((x, y));
                        currentTree = input[x, y];
                    }
                }
            }

            for (int y = 0; y <= input.GetUpperBound(1); y++)
            {
                // Left to right
                int currentTree = -1;
                for (int x = 0; x <= input.GetUpperBound(0); x++)
                {
                    if (input[x, y] > currentTree)
                    {
                        visible.Add((x, y));
                        currentTree = input[x, y];
                    }
                }

                // Right to Left
                currentTree = -1;
                for (int x = input.GetUpperBound(0); x >= 0; x--)
                {
                    if (input[x, y] > currentTree)
                    {
                        visible.Add((x, y));
                        currentTree = input[x, y];
                    }
                }
            }

            IO.WriteOutput(day, "a", visible.Distinct().Count());
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileInt2DArray(day, "a");
            Dictionary<(int, int), int> scores = new();
            for (int x = 1; x <= input.GetUpperBound(0) - 1; x++)
            {
                for (int y = 1; y <= input.GetUpperBound(1) - 1; y++)
                {
                    int score = 1;
                    // Right
                    int i = x + 1;
                    int tmpScore = 0;
                    while (i <= input.GetUpperBound(0) )
                    {
                        tmpScore++;
                        if (input[i, y] >= input[x, y])
                            break;
                        i++;
                    }
                    score *= tmpScore;

                    // Left
                    i = x - 1;
                     tmpScore = 0;
                    while (i >= 0)
                    {
                        tmpScore++;
                        if (input[i, y] >= input[x, y])
                            break;
                        i--;
                    }
                    score *= tmpScore;

                    // Up
                    i = y + 1;
                     tmpScore = 0;
                    while (i <= input.GetUpperBound(1))
                    {
                        tmpScore++;
                        if (input[x, i] >= input[x, y])
                            break;
                        i++;
                    }
                    score *= tmpScore;

                    // Down
                    i = y - 1;
                     tmpScore = 0;
                    while (i >= 0)
                    {
                        tmpScore++;
                        if (input[x, i] >= input[x, y])
                            break;
                        i--;
                    }
                    score *= tmpScore;

                    scores.Add((x, y), score);
                }
            }

            var result = scores.Where(x => x.Value == scores.Max(y => y.Value)).First().Value;
            IO.WriteOutput(day, "b", result);
        }
    }
}
