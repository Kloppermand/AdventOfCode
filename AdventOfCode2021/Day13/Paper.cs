using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day13
{
    class Paper
    {
        public List<int[]> Points { get; set; }
        public List<string> Folds { get; set; }

        public Paper(string raw)
        {
            Points = new();
            var t1 = raw.Split("\n\n").ToList();
            Folds = t1.Last().Split("\n").ToList();
            foreach (string point in t1.First().Split("\n"))
            {
                var t2 = point.Split(',');
                Points.Add(new int[2]{ int.Parse(t2.First()),int.Parse(t2.Last())});
            }
        }

        public void RemoveDuplicates()
        {
            List<int> removeIndex = new();
            for (int i = 0; i < Points.Count; i++)
            {
                for (int j = i+1; j < Points.Count; j++)
                {
                    if (Points[i][0] == Points[j][0] && Points[i][1] == Points[j][1])
                        removeIndex.Add(j);
                }
            }
            removeIndex.Sort();
            removeIndex.Reverse();
            foreach (var index in removeIndex.Distinct())
            {
                Points.RemoveAt(index);
            }
        }
        public void Fold(string fold)
        {
            var t1 = fold.Split('=').ToArray();
            int axis = t1.First().Last() == 'x' ? 0 : 1;
            int foldAt = int.Parse(t1.Last());

            for (int i = 0; i < Points.Count; i++)
            {
                if(Points[i][axis] > foldAt)
                {
                    Points[i][axis] -= 2 * (Points[i][axis] - foldAt);
                }
            }
        }

        public string ToString()
        {
            char[][] grid = new char[Points.Max(p => p[1]+1)][];
            for (int i = 0; i < grid.Length; i++)
            {
                grid[i] = new string('.', Points.Max(p => p[0]+1)).ToCharArray();
            }
            foreach (var p in Points)
            {
                grid[p[1]][p[0]] = '#';
            }
            string[] retString = new string[grid.Length];
            for (int i = 0; i < grid.Length; i++)
            {
                retString[i] = new string(grid[i]);
            }
            return string.Join("\r\n", retString);
        }
    }
}
