using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day13
{
    class PacketValue : IComparable
    {
        public List<PacketValue> ListValue { get; set; } = new();
        public int? IntValue { get; set; }
        public string stringValue { get; set; }

        public PacketValue(string input)
        {
            stringValue = input;
            if (string.IsNullOrEmpty(input))
                return;

            if (int.TryParse(input, out int tmpInt))
            {
                IntValue = tmpInt;
                return;
            }

            int level = 0;
            string tmp = "";
            foreach (var chr in input)
            {
                if (chr == '[')
                {
                    level++;
                    if (level == 1)
                        continue;
                }

                if (chr == ']')
                {
                    level--;
                }

                if (level == 1 && chr == ',')
                {
                    ListValue.Add(new(tmp));
                    tmp = "";
                    continue;
                }

                if (level > 0)
                {
                    tmp += chr;
                }
            }

            ListValue.Add(new(tmp));
        }

        public int Compare(PacketValue other)
        {
            if (IntValue is not null && other.IntValue is not null)
            {
                if (IntValue == other.IntValue)
                    return 0;
                return IntValue < other.IntValue ? -1 : 1;
            }

            if (IntValue is not null && ListValue.Count() == 0)
                ListValue.Add(new(IntValue.ToString()));


            if (other.IntValue is not null && other.ListValue.Count() == 0)
                other.ListValue.Add(new(other.IntValue.ToString()));

            for (int i = 0; i < ListValue.Count(); i++)
            {
                if (i >= other.ListValue.Count())
                    return 1;

                var fap = ListValue[i].Compare(other.ListValue[i]);
                if (fap == 0)
                    continue;

                return fap;
            }

            if (ListValue.Count() == other.ListValue.Count())
                return 0;

            return -1;
        }

        public int CompareTo(object obj)
        {
            return Compare((PacketValue)obj);
        }
    }
}
