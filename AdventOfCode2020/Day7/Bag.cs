using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day7
{
    class Bag
    {
        public string Color { get; set; }
        public int Amount { get; set; }
        public List<Bag> Contains { get; set; }
        public Bag()
        {
            Contains = new();
        }

        public void ParseBag(string raw)
        {
            string[] splitRaw = raw.Split(" contain ");
            Color = splitRaw[0][..^5];
            if (splitRaw[1].Equals("no other bags."))
                return;
            string[] containList = splitRaw[1].Replace(".","").Replace(" bags","").Replace(" bag","").Split(", ");
            foreach (var contain in containList)
            {
                Contains.Add(new Bag { Amount = int.Parse(contain.Split(' ')[0]), Color = contain[2..] });
            }
        }

    }
}
