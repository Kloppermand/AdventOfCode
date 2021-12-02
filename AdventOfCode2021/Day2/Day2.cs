using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day2
{
    public static class Day2
    {
        private const string day = "Day2";

        public static void CalculateA()
        {
            var commands = GeneralMethods.ReadInputFileStringArray(day, "a");
            Submarine sub = new();
            foreach (string command in commands)
            {
                sub.RunCommandA(command);
            }
            GeneralMethods.WriteOutput(day, "a", sub.CalculateResult().ToString());
        }
        public static void CalculateB()
        {
            var commands = GeneralMethods.ReadInputFileStringArray(day, "a");
            Submarine sub = new();
            foreach (string command in commands)
            {
                sub.RunCommandB(command);
            }
            GeneralMethods.WriteOutput(day, "b", sub.CalculateResult().ToString());
        }
    }
}
