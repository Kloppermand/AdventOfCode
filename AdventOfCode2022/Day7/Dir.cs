using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day7
{
    public class Dir
    {
        public string Name { get; set; }
        public List<string> Files { get; set; }
        public List<Dir> Dirs { get; set; }
        public long Size { get; set; }
        public Dir Parent { get; set; }

        public Dir(string name, Dir parent)
        {
            Name = name;
            Files = new();
            Dirs = new();
            Parent = parent;
        }

        public long GetFileSizes()
        {
            long fileSizes = Files.Sum(x => int.Parse(x.Split(' ')[0]));
            long dirSizes = Dirs.Sum(x => x.GetFileSizes());
            Size = fileSizes + dirSizes;
            return Size;
        }

        public Dir GoToRoot()
        {
            if (Parent is null)
                return this;
            return Parent.GoToRoot();
        }

        public long GetSmallDirSizes()
        {
            long total = 0;
            foreach (var dir in Dirs)
            {
                total += dir.GetSmallDirSizes();
            }

            if(Size <= 100000)
            {
                total += Size;
            }

            return total;
        }

        public List<Dir> GetFlatDirList()
        {
            List<Dir> dirs = new();
            dirs.AddRange(Dirs);
            foreach (var dir in Dirs)
            {
                dirs.AddRange(dir.GetFlatDirList());
            }
            return dirs;
        }
    }
}
