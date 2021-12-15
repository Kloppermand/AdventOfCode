using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day10
{
    class Chunk
    {
        public char StartChar { get; set; }
        public char EndChar { get; set; }
        public string RawChunk { get; set; }
        public List<Chunk> Contains { get; set; }
        public Chunk(string chunk)
        {
            StartChar = chunk[0];
            EndChar = chunk[^1];
            RawChunk = chunk;
            Contains = new();
            SplitChunks();
        }

        private void SplitChunks()
        {
            int lastStart = 0;
            int counter = 0;
            for (int i = 0; i < RawChunk.Length; i++)
            {
                if (counter == 0)
                    lastStart = i;
                
                if ("({[".Contains(RawChunk[i]))
                    counter++;
                else if (")}]".Contains(RawChunk[i]))
                    counter--;

                if (counter == 0)
                    Contains.Add(new Chunk(RawChunk[lastStart..i]));
            }
        }
    }

}
