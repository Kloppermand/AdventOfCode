using System;
using System.IO;
using System.Linq;
using System.Net;

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
            string[] tempArr = File.ReadAllText(path).Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            if (tempArr[^1] == "") tempArr = tempArr[..^1];
            int[] retArr = tempArr.Select(x => int.Parse(x)).ToArray();
            return retArr;
        }

        public static int[,] ReadInputFileInt2DArray(string day, string puzzle)
        {
            string path = GetPath(day, puzzle, IOType.input);
            string[] input = File.ReadAllText(path).Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None).ToArray();
            if (input[^1] == "") input = input[..^1];
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
            string[] tempArr = File.ReadAllText(path).Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            if (tempArr[^1] == "") tempArr = tempArr[..^1];
            long[] retArr = tempArr.Select(x => long.Parse(x)).ToArray();
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
            string[] retArr = File.ReadAllText(path).Split(new string[] {"\r\n", "\n"}, StringSplitOptions.None).ToArray();
            if (retArr[^1] == "") retArr = retArr[..^1];
            return retArr;
        }

        public static string[] ReadInputFileStringArrayBlankLine(string day, string puzzle)
        {
            string path = GetPath(day, puzzle, IOType.input);
            string[] retArr = File.ReadAllText(path).Split(new string[] { "\r\n\r\n", "\n\n" }, StringSplitOptions.None).Select(x => x.Replace("\r\n", " ").Replace("\n", " ")).ToArray();
            if (retArr[^1] == "") retArr = retArr[..^1];
            return retArr;
        }
        public static void WriteOutput(string day, string puzzle, string value)
        {
            string path = GetPath(day, puzzle, IOType.output);
            File.WriteAllText(path, value);
        }

        public static void WriteOutput(string day, string puzzle, int value)
        {
            WriteOutput(day, puzzle, value.ToString());
        }

        private static string GetPath(string day, string puzzle, IOType io)
        {
            var year = System.Reflection.Assembly.GetEntryAssembly().GetName().Name[^4..];

            var path = Path.Combine(Environment.CurrentDirectory, $"../../../{day}/{day}_{io}_{puzzle}.txt");
            if (!File.Exists(path) && io == IOType.input)
            {
                HttpWebRequest rq = (HttpWebRequest)WebRequest.Create($"https://adventofcode.com/{year}/day/{day.Substring(3)}/input");
                rq.CookieContainer = new CookieContainer();
                Cookie cookie = new Cookie("session", File.ReadAllText("../../../../Utilities/sessionId.txt"))
                {
                    Domain = ".adventofcode.com",
                    Path = "/",
                    Expired = false,
                    HttpOnly = true
                };
                rq.CookieContainer.Add(cookie);
                HttpWebResponse resp = (HttpWebResponse)rq.GetResponse();
                using FileStream fs = new(path, FileMode.CreateNew);
                resp.GetResponseStream().CopyTo(fs);
            }
            return path;
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
