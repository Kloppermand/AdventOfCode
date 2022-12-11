using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day11
{
    class Monkey
    {
        public int Id { get; set; }
        public List<long> Items { get; set; }
        public string Operation { get; set; }
        public int DivisibilityTest { get; set; }
        public int TrueTarget { get; set; }
        public int FalseTarget { get; set; }
        public int InspectedItems { get; set; }

        public Monkey(string monkey)
        {
            var tmp = monkey.Split('\n');
            Id = int.Parse(tmp[0].Replace("Monkey ", "").Replace(":", ""));
            Items = new();
            foreach (var item in tmp[1].Replace("  Starting items: ", "").Split(", "))
            {
                Items.Add(int.Parse(item));
            }
            Operation = tmp[2].Replace("  Operation: new = ", "");
            DivisibilityTest = int.Parse(tmp[3].Replace("  Test: divisible by ", ""));
            TrueTarget = int.Parse(tmp[4].Replace("    If true: throw to monkey ", ""));
            FalseTarget = int.Parse(tmp[5].Replace("    If false: throw to monkey ", ""));
            InspectedItems = 0;
        }

        public (int, long) GetItemTarget(long item)
        {
            var worry = CalcWorry(item) / 3;
            int target = worry % DivisibilityTest == 0 ? TrueTarget : FalseTarget;
            InspectedItems++;
            return (target, worry);
        }

        public (int, long) GetItemTargetVeryWorried(long item, int mod)
        {
            var worry = CalcWorry(item) ;
            int target = worry % DivisibilityTest == 0 ? TrueTarget : FalseTarget;
            InspectedItems++;
            return (target, worry%mod);
        }

        private long CalcWorry(long old)
        {
            var expr = Operation.Replace("old", old.ToString()).Split(' ');
            var val1 = long.Parse(expr[0]);
            var op = expr[1];
            var val2 = long.Parse(expr[2]);

            return op.Equals("+") ? val1 + val2 : val1 * val2;
        }
    }
}
