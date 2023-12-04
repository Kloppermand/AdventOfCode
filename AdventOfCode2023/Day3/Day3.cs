using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2023.Day3
{
    public static class Day3
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            int result = 0;
            string symbols = "0123456789.";

            for (int row = 0; row < input.Length; row++)
            {
                for (int col = 0; col < input[row].Length; col++)
                {
                    string num = "";
                    bool symbolAdjecent = false;
                    while (input[row][col] >= '0' && input[row][col] <= '9' && col < input[row].Length)
                    {
                        num += input[row][col];
                        if (row > 0 && col > 0)
                            if (!symbols.Contains(input[row - 1][col - 1])) symbolAdjecent = true;

                        if (row > 0)
                            if (!symbols.Contains(input[row - 1][col])) symbolAdjecent = true;

                        if (row > 0 && col < input[row].Length - 1)
                            if (!symbols.Contains(input[row - 1][col + 1])) symbolAdjecent = true;

                        if (col > 0)
                            if (!symbols.Contains(input[row][col - 1])) symbolAdjecent = true;

                        if (col < input[row].Length - 1)
                            if (!symbols.Contains(input[row][col + 1])) symbolAdjecent = true;

                        if (row < input.Length - 1 && col > 0)
                            if (!symbols.Contains(input[row + 1][col - 1])) symbolAdjecent = true;

                        if (row < input.Length - 1)
                            if (!symbols.Contains(input[row + 1][col])) symbolAdjecent = true;

                        if (row < input.Length - 1 && col < input[row].Length - 1)
                            if (!symbols.Contains(input[row + 1][col + 1])) symbolAdjecent = true;

                        col++;
                        if (col == input[row].Length) break;
                    }
                    if (symbolAdjecent)
                        result += int.Parse(num);
                }
            }

            IO.WriteOutput(day, "a", result);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            int result = 0;

            for (int row = 0; row < input.Length; row++)
            {
                for (int col = 0; col < input[row].Length; col++)
                {
                    List<int> nums = new List<int>();
                    string num = "";
                    int tmpCol = col;

                    if (input[row][col] != '*')
                        continue;

                    // LEFT
                    if (col > 0)
                        while (tmpCol > 0 && input[row][tmpCol - 1] >= '0' && input[row][tmpCol - 1] <= '9')
                        {
                            num = input[row][tmpCol - 1] + num;
                            tmpCol--;
                        }


                    tmpCol = col; 
                    if (num != "")
                    {
                        nums.Add(int.Parse(num));
                        num = "";
                    }

                    // RIGHT
                    if (col < input[row].Length - 1)
                        while (tmpCol < input[row].Length-1 && input[row][tmpCol + 1] >= '0' && input[row][tmpCol + 1] <= '9')
                        {
                            num += input[row][tmpCol + 1];
                            tmpCol++;
                        }

                    tmpCol = col;
                    if (num != "")
                    {
                        nums.Add(int.Parse(num));
                        num = "";
                    }

                    // UP
                    if (row > 0)
                    {
                        // STRAIGHT UP
                        if (input[row - 1][col] >= '0' && input[row - 1][col] <= '9')
                        {
                            num += input[row - 1][col];
                            if (col > 0)
                                while (input[row - 1][tmpCol - 1] >= '0' && input[row - 1][tmpCol - 1] <= '9')
                                {
                                    num = input[row - 1][tmpCol - 1] + num;
                                    tmpCol--;
                                }
                            tmpCol = col;

                            if (col < input[row - 1].Length - 1)
                                while (input[row - 1][tmpCol + 1] >= '0' && input[row - 1][tmpCol + 1] <= '9')
                                {
                                    num += input[row - 1][tmpCol + 1];
                                    tmpCol++;
                                }
                            tmpCol = col;

                            if (num != "")
                            {
                                nums.Add(int.Parse(num));
                                num = "";
                            }
                        }
                        else
                        {
                            // UP LEFT
                            if (col > 0)
                            {
                                while (tmpCol > 0 && input[row - 1][tmpCol - 1] >= '0' && input[row - 1][tmpCol - 1] <= '9')
                                {
                                    num = input[row - 1][tmpCol - 1] + num;
                                    tmpCol--;
                                }
                                tmpCol = col;

                                if (num != "")
                                {
                                    nums.Add(int.Parse(num));
                                    num = "";
                                }
                            }

                            // UP RIGHT
                            if (col < input[row - 1].Length - 1)
                            {
                                while (input[row - 1][tmpCol + 1] >= '0' && input[row - 1][tmpCol + 1] <= '9')
                                {
                                    num += input[row - 1][tmpCol + 1];
                                    tmpCol++;
                                }

                                tmpCol = col;
                                if (num != "")
                                {
                                    nums.Add(int.Parse(num));
                                    num = "";
                                }
                            }
                        }
                    }

                    // DOWN
                    if (row < input.Length - 1)
                    {
                        // STRAIGHT DOWN
                        if (input[row + 1][col] >= '0' && input[row + 1][col] <= '9')
                        {
                            num += input[row + 1][col];
                            if (col > 0)
                                while (input[row + 1][tmpCol - 1] >= '0' && input[row + 1][tmpCol - 1] <= '9')
                                {
                                    num = input[row + 1][tmpCol - 1] + num;
                                    tmpCol--;
                                }
                            tmpCol = col;

                            if (col < input[row + 1].Length - 1)
                                while (input[row + 1][tmpCol + 1] >= '0' && input[row + 1][tmpCol + 1] <= '9')
                                {
                                    num += input[row + 1][tmpCol + 1];
                                    tmpCol++;
                                }
                            tmpCol = col;

                            if (num != "")
                            {
                                nums.Add(int.Parse(num));
                                num = "";
                            }
                        }
                        else
                        {
                            // DOWN LEFT
                            if (col > 0)
                            {
                                while (input[row + 1][tmpCol - 1] >= '0' && input[row + 1][tmpCol - 1] <= '9')
                                {
                                    num = input[row + 1][tmpCol - 1] + num;
                                    tmpCol--;
                                }
                                tmpCol = col;

                                if (num != "")
                                {
                                    nums.Add(int.Parse(num));
                                    num = "";
                                }
                            }

                            // DOWN RIGHT
                            if (col < input[row + 1].Length - 1)
                            {
                                while (input[row + 1][tmpCol + 1] >= '0' && input[row + 1][tmpCol + 1] <= '9')
                                {
                                    num += input[row + 1][tmpCol + 1];
                                    tmpCol++;
                                }

                                if (num != "")
                                {
                                    nums.Add(int.Parse(num));
                                    num = "";
                                }
                            }
                        }
                    }

                    if (nums.Count == 2)
                        result += nums[0] * nums[1];

                }
            }

            IO.WriteOutput(day, "b", result);
        }
    }
}
