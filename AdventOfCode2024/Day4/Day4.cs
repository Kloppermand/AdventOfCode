using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2024.Day4
{
    public static class Day4
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            int result = 0;

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    if (j > 2 && i > 2 &&
                        input[i][j] == 'X' && input[i - 1][j - 1] == 'M' && input[i - 2][j - 2] == 'A' && input[i - 3][j - 3] == 'S') result++;

                    if (j > 2 &&
                        input[i][j] == 'X' && input[i][j - 1] == 'M' && input[i][j - 2] == 'A' && input[i][j - 3] == 'S') result++;

                    if (j > 2 && i < input[i].Length - 3 &&
                        input[i][j] == 'X' && input[i + 1][j - 1] == 'M' && input[i + 2][j - 2] == 'A' && input[i + 3][j - 3] == 'S') result++;


                    if (i > 2 &&
                        input[i][j] == 'X' && input[i - 1][j] == 'M' && input[i - 2][j] == 'A' && input[i - 3][j] == 'S') result++;

                    if (i < input[i].Length - 3 &&
                        input[i][j] == 'X' && input[i + 1][j] == 'M' && input[i + 2][j] == 'A' && input[i + 3][j] == 'S') result++;


                    if (j < input[i].Length - 3 && i > 2 &&
                        input[i][j] == 'X' && input[i - 1][j + 1] == 'M' && input[i - 2][j + 2] == 'A' && input[i - 3][j + 3] == 'S') result++;

                    if (j < input[i].Length - 3 &&
                        input[i][j] == 'X' && input[i][j + 1] == 'M' && input[i][j + 2] == 'A' && input[i][j + 3] == 'S') result++;

                    if (j < input[i].Length - 3 && i < input[i].Length - 3 &&
                        input[i][j] == 'X' && input[i + 1][j + 1] == 'M' && input[i + 2][j + 2] == 'A' && input[i + 3][j + 3] == 'S') result++;
                }
            }

            IO.WriteOutput(day, "a", result);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            int result = 0;

            for (int i = 1; i < input.Length - 1; i++)
            {
                for (int j = 1; j < input[i].Length - 1; j++)
                {
                    if (input[i][j] == 'A')
                    {
                        if (input[i - 1][j - 1] == 'M' && input[i + 1][j + 1] == 'S' &&
                            input[i + 1][j - 1] == 'M' && input[i - 1][j + 1] == 'S')
                            result++;

                        if (input[i - 1][j - 1] == 'M' && input[i + 1][j + 1] == 'S' &&
                            input[i - 1][j + 1] == 'M' && input[i + 1][j - 1] == 'S')
                            result++;

                        if (input[i - 1][j - 1] == 'S' && input[i + 1][j + 1] == 'M' &&
                            input[i + 1][j - 1] == 'S' && input[i - 1][j + 1] == 'M')
                            result++;

                        if (input[i - 1][j - 1] == 'S' && input[i + 1][j + 1] == 'M' &&
                            input[i - 1][j + 1] == 'S' && input[i + 1][j - 1] == 'M')
                            result++;
                    }
                }
            }

            IO.WriteOutput(day, "b", result);
        }
    }
}
