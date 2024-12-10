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
            var input = "436232512020";// IO.ReadInputFileString(day, "a") + "0";
            long result = 0;
            List<(int id, int file, int space)> fileSystem = new();
            List<(int id, int file, int space)> fileSystemRev = new();

            for (int i = 0; i < input.Length; i += 2)
            {
                fileSystem.Add((i / 2, input[i] - 0x30, input[i + 1] - 0x30));
                fileSystemRev.Add((i / 2, input[i] - 0x30, input[i + 1] - 0x30));
            }

            fileSystemRev.Reverse();
            Console.WriteLine(MakeString(fileSystem));
            foreach (var file_ori in fileSystemRev)
            {
                try
                {
                    var file = fileSystem.First(x => x.id == file_ori.id);
                    var space = fileSystem.First(x => x.space >= file.file);
                    var spaceIndex = fileSystem.FindIndex(x => x.id == space.id);
                    if (spaceIndex >= fileSystem.FindIndex(x => x.id == file.id))
                        continue;

                    var prevFileIndex = fileSystem.FindIndex(x => x.id == file.id) - 1;
                    var tmp = fileSystem[prevFileIndex];
                    fileSystem[spaceIndex] = (space.id, space.file, 0);
                    fileSystem[prevFileIndex] = (tmp.id, tmp.file, tmp.space + file.file + file.space);
                    fileSystem.Insert(spaceIndex + 1, (file.id, file.file, space.space - file.file));
                    fileSystem.RemoveAt(fileSystem.FindLastIndex(x => x.id == file.id));

                    Console.WriteLine(MakeString(fileSystem));
                }
                catch { }
            }

            List<int> lst = new();

            foreach (var file in fileSystem)
            {
                for (int i = 0; i < file.file; i++)
                    lst.Add(file.id);

                for (int i = 0; i < file.space; i++)
                    lst.Add(0);
            }

            for (int i = 0; i < lst.Count; i++)
            {
                result += i * lst[i];
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
