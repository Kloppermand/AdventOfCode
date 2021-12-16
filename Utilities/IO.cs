using System;
using System.IO;
using System.Linq;

namespace Utilities
{
    public static class IO
    {
        private enum IOType
        {
            input,
            output
        }
        public static int[] ReadInputFileIntArray(string day, string puzzle)
        {
            string path = GetPath(day, puzzle, IOType.input);
            int[] retArr = File.ReadAllText(path).Split("\r\n").Select(x => int.Parse(x)).ToArray();
            return retArr;
        }

        public static int[,] ReadInputFileInt2DArray(string day, string puzzle)
        {
            string path = GetPath(day, puzzle, IOType.input);
            string[] input = File.ReadAllText(path).Split("\r\n").ToArray();
            int[,] grid = new int[input[0].Length, input.Length];
            for (int j = 0; j < input.Length; j++)
            {
                for (int i = 0; i < input[0].Length; i++)
                {
                    grid[i, j] = int.Parse(input[i][j].ToString());
                }
            }
            return grid;
        }


        public static long[] ReadInputFileLongArray(string day, string puzzle)
        {
            string path = GetPath(day, puzzle, IOType.input);
            long[] retArr = File.ReadAllText(path).Split("\r\n").Select(x => long.Parse(x)).ToArray();
            return retArr;
        }
        
        public static int[] ReadInputFileIntArraySingleLine(string day, string puzzle)
        {
            string path = GetPath(day, puzzle, IOType.input);
            int[] retArr = File.ReadAllText(path).Split(",").Select(x => int.Parse(x)).ToArray();
            return retArr;
        }

        public static string ReadInputFileString(string day, string puzzle)
        {
            string path = GetPath(day, puzzle, IOType.input);
            string data = File.ReadAllText(path);
            return data;
        }
        public static string[] ReadInputFileStringArray(string day, string puzzle)
        {
            string path = GetPath(day, puzzle, IOType.input);
            string[] retArr = File.ReadAllText(path).Split("\r\n").ToArray();
            return retArr;
        }
        
        public static string[] ReadInputFileStringArrayBlankLine(string day, string puzzle)
        {
            string path = GetPath(day, puzzle, IOType.input);
            string[] retArr = File.ReadAllText(path).Split("\r\n\r\n").Select(x => x.Replace("\r\n"," ")).ToArray();
            return retArr;
        }
        public static void WriteOutput(string day, string puzzle, string value)
        {
            string path = GetPath(day, puzzle, IOType.output);
            File.WriteAllText(path, value);
        }

        private static string GetPath(string day, string puzzle, IOType io)
        {
            return Path.Combine(Environment.CurrentDirectory, $"../../../{day}/{day}_{io}_{puzzle}.txt");
        }

        public static void Print2DArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + ",");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
