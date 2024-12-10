using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class IntRange
    {
        public int start { get; set; }
        public int end { get; set; }
        public int Length { get => end - start + 1 ;}

        public IntRange(int start, int end)
        {
            this.start = start;
            this.end = end;
        }

        public static IntRange GetFromLength(int start, int Length)
        {
            return new IntRange(start, start + Length);
        }

        public override string ToString()
        {
            return $"{start} - {end}";
        }
    }
}
