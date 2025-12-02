using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class LongRange
    {
        public long start { get; set; }
        public long end { get; set; }
        public long Length { get => end - start + 1 ;}

        public LongRange(long start, long end)
        {
            this.start = start;
            this.end = end;
        }

        public LongRange(string range)
        {
            var parts = range.Split('-');
            start = long.Parse(parts[0]);
            end = long.Parse(parts[1]);
        }

        public static LongRange GetFromLength(long start, long Length)
        {
            return new LongRange(start, start + Length);
        }

        public override string ToString()
        {
            return $"{start} - {end}, Length: {Length}";
        }
    }
}
