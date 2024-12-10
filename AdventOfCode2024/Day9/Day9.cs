using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Utilities;

namespace AdventOfCode2024.Day9
{
    public static class Day9
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileString(day, "a");
            long result = 0;
            List<char> lst = FillFileSystem(input);

            while (lst.Contains('.'))
            {
                lst[lst.IndexOf('.')] = lst.Last();
                lst.RemoveAt(lst.Count - 1);

                while (lst.Last() == '.')
                    lst.RemoveAt(lst.Count - 1);
            }

            for (int i = 0; i < lst.Count; i++)
            {
                result += (lst[i] - 0x30) * i;
            }
            IO.WriteOutput(day, "a", result);
        }


        public static void CalculateB()
        {
            var input = "23331331214141314020";// IO.ReadInputFileString(day, "a") + "0";
            int result = 0;
            List<(int id, int size)> files = new();
            List<IntRange> free = new();
            int ind = 0;

            for (int i = 0;i < input.Length;i+=2) 
            {
                var tmpFile = (i / 2, input[i] - 0x30);
                var tmpRange = IntRange.GetFromLength(ind + tmpFile.Item2, input[i + 1] - 0x30);
                files.Add(tmpFile);
                free.Add(tmpRange);
                ind += tmpFile.Item2 + tmpRange.Length;
            }

           
            IO.WriteOutput(day, "b", result);
        }

        private static string MakeString(List<(int id, int file, int space)> fileSystem)
        {
            string compressed = "";
            foreach (var file in fileSystem)
            {
                compressed += new string((char)(file.id + 0x30), file.file) + new string('.', file.space);
            }

            return compressed;
        }

        private static List<char> FillFileSystem(string input)
        {
            List<char> lst = new();
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < int.Parse(input[i].ToString()); j++)
                    lst.Add(i % 2 == 0 ? (char)(i / 2 + 0x30) : '.');
            }

            return lst;
        }
    }
}
