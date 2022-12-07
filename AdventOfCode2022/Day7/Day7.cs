using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2022.Day7
{
    public static class Day7
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringArray(day, "a");

            Dir dirStructure = CreateFileStructure(input);

            long result = dirStructure.GetSmallDirSizes(100000);

            IO.WriteOutput(day, "a", result);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArray(day, "a");

            Dir dirStructure = CreateFileStructure(input);

            var flatList = dirStructure.GetFlatDirList();
            long missingSize = dirStructure.Size - 40000000;

            var result = flatList.Where(x => x.Size > missingSize).Min(x => x.Size);

            IO.WriteOutput(day, "b", result);
        }

        public static Dir CreateFileStructure(string[] input)
        {
            var currentDir = new Dir();
            foreach (var line in input)
            {
                if (line.Equals("$ ls"))
                {
                    continue;
                }
                else if (line.StartsWith("$ cd"))
                {
                    string target = line.Split(' ')[^1];
                    currentDir = currentDir.ChangeDirectory(target);
                }
                else if (line.StartsWith("dir"))
                {
                    string dirName = line.Split(' ')[^1];
                    currentDir.AddDirectory(dirName);
                }
                else
                {
                    currentDir.AddFile(line);
                }
            }
            currentDir = currentDir.GoToRoot();
            return currentDir;
        }
    }
}
