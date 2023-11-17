using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2021.Day16
{
    public static class Day16
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileString(day, "a");
            var binary = NumberBases.HexToBin(input);

            var packet = new Packet(binary);

            IO.WriteOutput(day, "a", packet.SumVersionNumbers());
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileString(day, "a");

            var binary = NumberBases.HexToBin(input);

            var packet = new Packet(binary);

            IO.WriteOutput(day, "b", packet.GetPacketValue());
        }
    }
}
