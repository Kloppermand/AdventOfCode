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

            Dir currentDir = CreateFileStructure(input);

            long totalSize =  currentDir.GetFileSizes();
            long result = currentDir.GetSmallDirSizes();

            IO.WriteOutput(day, "a", result);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArray(day, "a");

            Dir currentDir = CreateFileStructure(input);
            long totalSize = currentDir.GetFileSizes();

            var flatList = currentDir.GetFlatDirList();
            long missingSize = currentDir.Size - 40000000;

            var result = flatList.Where(x => x.Size > missingSize).Min(x => x.Size);

            IO.WriteOutput(day, "b", result);
        }

        public static Dir CreateFileStructure(string[] input)
        {
            var currentDir = new Dir("/", null);
            foreach (var line in input)
            {
                if (line.StartsWith("$"))
                {
                    if (line.StartsWith("$ cd"))
                    {
                        string target = line.Split(' ')[^1];
                        if (target.Equals("/"))
                        {
                            currentDir = currentDir.GoToRoot();
                        }
                        else if (target.Equals(".."))
                        {
                            currentDir = currentDir.Parent;
                        }
                        else
                        {
                            currentDir = currentDir.Dirs.Find(x => x.Name == target);
                        }
                    }
                }
                else
                {
                    if (line.StartsWith("dir"))
                    {
                        string dirName = line.Split(' ')[^1];
                        if (!currentDir.Dirs.Select(x => x.Name).Contains(dirName))
                            currentDir.Dirs.Add(new Dir(dirName, currentDir));
                    }
                    else
                    {
                        if (!currentDir.Files.Contains(line))
                            currentDir.Files.Add(line);
                    }
                }
            }

            currentDir = currentDir.GoToRoot();
            return currentDir;
        }
    }
}
