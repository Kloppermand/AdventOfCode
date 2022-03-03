using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2021.Day12
{
    public static class Day12
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            var allCaves = new List<string>();
            var caveNetwork = new List<Cave>();
            foreach (var pair in input)
            {
                var tmp = pair.Split("-");
                allCaves.Add(tmp[0]);
                allCaves.Add(tmp[1]);
            }
            foreach (var name in allCaves.Distinct())
            {
                caveNetwork.Add(new Cave(name));
            }
            foreach (var pair in input)
            {
                var tmp = pair.Split('-');
                caveNetwork.Where(x => x.Name.Equals(tmp[0])).First().Connected.Add(
                    caveNetwork.Where(y => y.Name.Equals(tmp[1])).First()
                    );
                caveNetwork.Where(x => x.Name.Equals(tmp[1])).First().Connected.Add(
                    caveNetwork.Where(y => y.Name.Equals(tmp[0])).First()
                    );
            }

            caveNetwork.Where(x => x.Name.Equals("end")).First().UpdateWaysToEnd();

            string result = "NOT SOLVED YET";
            IO.WriteOutput(day, "a", result);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArray(day, "a");



            string result = "NOT SOLVED YET";
            IO.WriteOutput(day, "b", result);
        }
    }
}
