using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day5
{
    internal class Map
    {
        public List<MapElement> Elements { get; set; } = new();

        public Map(string[] elements)
        {
            foreach (var element in elements.Where(e => e != ""))
            {
                var tmp = element.Split().Select(n => long.Parse(n));
                Elements.Add(new()
                {
                    DestinationRangeStart = tmp.ElementAt(0),
                    SourceRangeStart = tmp.ElementAt(1),
                    RangeLength = tmp.ElementAt(2)
                });
            }
        }

        public long Apply(long n)
        {
            foreach(var element in Elements)
            {
                if (element.SourceRangeStart <= n && element.SourceRangeStart + element.RangeLength >= n)
                    return n + element.Effect();
            }
            return n;
        }

        public List<Range> ApplyRange(Range r)
        {
            var ranges = new List<Range>();
            foreach (var element in Elements)
            {
                // element starts in range
                if(r.RangeStart <= element.SourceRangeStart && r.RangeStart+r.RangeLength >= element.SourceRangeStart)
                    ranges.Add(new Range() { 
                        RangeStart = element.SourceRangeStart, 
                        RangeLength = Math.Min(
                            r.RangeStart + r.RangeLength - element.SourceRangeStart, 
                            element.RangeLength) });

                // range starts in element
                if (r.RangeStart >= element.SourceRangeStart && r.RangeStart <= element.SourceRangeStart + element.RangeLength)
                    ranges.Add(new Range()
                    {
                        RangeStart = r.RangeStart,
                        RangeLength = Math.Min(
                            r.RangeLength,
                            element.SourceRangeStart + element.RangeLength - r.RangeStart
                            )
                    });
            }

            return ranges;
        }
    }
}
