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
        public List<(Bag, int)> Contains { get; set; }
        public bool CanContainShinyGold { get; set; }
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
                Contains.Add((new Bag { Color = contain[2..] }, int.Parse(contain.Split(' ')[0])));
            }
        }

        public void AddContained(List<Bag> bags)
        {
            Contains = bags.Where(x => x.Color == Color).ToList().First().Contains;
            foreach (var container in Contains)
            {
                (Bag bag, int amount) = container;
                bag.AddContained(bags);
                if (bag.CanContainShinyGold || Contains.Count(x => x.Item1.Color.Equals("shiny gold")) > 0)
                    CanContainShinyGold = true;
            }
        }

        public int GetTotalAmount()
        {
            int totalAmount = Contains.Count == 0 ? 1 : 0;
            foreach (var container in Contains)
            {
                totalAmount += container.Item1.GetTotalAmount() * container.Item2;
            }
            return totalAmount;
        }
    }
}
