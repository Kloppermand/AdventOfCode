using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day14
{
    class Polymer
    {
        public string Value { get; set; }
        public string[] Rules { get; set; }
        public Polymer(string[] raw)
        {
            Value = raw[0];
            Rules = raw[2..];
        }

        public void StepMultiple(int steps)
        {
            for (int i = 0; i < steps; i++)
            {
                Step();
            }
        }
        public void Step()
        {
            List<InsertAt> inserts = new();
            foreach (var rule in Rules)
            {
                foreach(var match in AllIndexOf(Value, rule[..2]))
                {
                    inserts.Add(new InsertAt { index = match, chr = rule[^1] });
                }
            }

            inserts = inserts.OrderByDescending(i => i.index).ToList();

            foreach (var insert in inserts)
            {
                Value = Value.Insert(insert.index+1, insert.chr.ToString());
            }
        }

        private List<int> AllIndexOf(string value, string pattern)
        {
            List<int> retList = new();
            for (int i = 0; i < value.Length-1; i++)
            {
                if (value.Substring(i, 2).Equals(pattern))
                    retList.Add(i);
            }
            return retList;
        }
        private class InsertAt
        {
            public int index { get; set; }
            public char chr { get; set; }
        }
    }
}
