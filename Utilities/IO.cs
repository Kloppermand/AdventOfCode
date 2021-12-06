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
    }
}
