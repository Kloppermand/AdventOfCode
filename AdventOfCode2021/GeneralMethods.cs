using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public static class GeneralMethods
    {
        private enum IO
        {
            input,
            output
        }
        public static int[] ReadInputFileIntArray(string day, string puzzle)
        {
            string path = GetPath(day, puzzle, IO.input);
            int[] retArr = File.ReadAllText(path).Split("\r\n").Select(x => int.Parse(x)).ToArray();
            return retArr;
        }
        public static string[] ReadInputFileStringArray(string day, string puzzle)
        {
            string path = GetPath(day, puzzle, IO.input);
            string[] retArr = File.ReadAllText(path).Split("\r\n").ToArray();
            return retArr;
        }
        public static void WriteOutput(string day, string puzzle, string value)
        {
            string path = GetPath(day, puzzle, IO.output);
            File.WriteAllText(path, value);
        }

        private static string GetPath(string day, string puzzle, IO io)
        {
            return Path.Combine(Environment.CurrentDirectory, $"../../../{day}/{day}_{io.ToString()}_{puzzle}.txt");
        }
    }
}
