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
        public Dictionary<string, Dir> Dirs { get; set; }
        private long _size;
        public long Size {
            get
            {
                if (_size == 0)
                    RecalculateSize();
                return _size;
            }
        }
        public Dir Parent { get; set; }

        public Dir()
        {
            Setup("/", null);
        }
        public Dir(string name, Dir parent)
        {
            Setup(name, parent);
        }
        private void Setup(string name, Dir parent)
        {
            Name = name;
            Files = new();
            Dirs = new();
            Parent = parent;
        }

        public long RecalculateSize()
        {
            long fileSizes = Files.Sum(x => int.Parse(x.Split(' ')[0]));
            long dirSizes = Dirs.Sum(x => x.Value.RecalculateSize());
            _size = fileSizes + dirSizes;
            return _size;
        }

        public Dir GoToRoot()
        {
            if (Parent is null)
                return this;
            return Parent.GoToRoot();
        }

        public Dir ChangeDirectory(string target)
        {
            if (target.Equals("/"))
                return GoToRoot();

            if (target.Equals(".."))
                return Parent;
            
            return Dirs[target];
        }

        public void AddDirectory(string dirName)
        {
            Dirs.TryAdd(dirName, new Dir(dirName, this));
        }

        public void AddFile(string file)
        {
            if (!Files.Contains(file))
                Files.Add(file);
        }

        public long GetSmallDirSizes(long maxDirSize)
        {
            long total = 0;
            foreach (var dir in Dirs)
            {
                total += dir.Value.GetSmallDirSizes(maxDirSize);
            }

            if(Size <= maxDirSize)
            {
                total += Size;
            }

            return total;
        }

        public List<Dir> GetFlatDirList()
        {
            List<Dir> dirs = new();
            dirs.AddRange(Dirs.Values);
            foreach (var dir in Dirs)
            {
                dirs.AddRange(dir.Value.GetFlatDirList());
            }
            return dirs;
        }
    }
}
