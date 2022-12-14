using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2022.Day13
{
    public static class Day13
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringArrayBlankLineKeepInternalLineBreaks(day, "a");
            var index = 1;
            int result = 0;

            foreach (var pair in input)
            {
                var tmp = pair.Split('\n');
                var packet1 = new PacketValue(tmp[0]);
                var packet2 = new PacketValue(tmp[1]);

                var isBefore = packet1.Compare(packet2);
                if (isBefore < 1)
                    result += index;
                index++;
            }

            IO.WriteOutput(day, "a", result);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArrayBlankLineKeepInternalLineBreaks(day, "a");
            string divider1 = "[[2]]";
            string divider2 = "[[6]]";

            List<PacketValue> allPackets = new();

            foreach (var pair in input)
            {
                var tmp = pair.Split('\n');
                allPackets.Add(new(tmp[0]));
                allPackets.Add(new(tmp[1]));
            }

            allPackets.Add(new("[[6]]"));
            allPackets.Add(new("[[2]]"));

            allPackets.Sort(Compare);

            var divider1Index = allPackets.IndexOf(allPackets.Find(x => x.stringValue.Equals(divider1))) + 1;
            var divider2Index = allPackets.IndexOf(allPackets.Find(x => x.stringValue.Equals(divider2))) + 1;

            int result = divider1Index * divider2Index;
            IO.WriteOutput(day, "b", result);
        }

        private static int Compare(PacketValue val1, PacketValue val2)
        {
            return val1.CompareTo(val2);
        }
    }
}
