using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day2
{
    public static class Day2
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var commands = GeneralMethods.ReadInputFileStringArray(day, "a");
            Submarine sub = new();
            Command command = new();
            foreach (string com in commands)
            {
                command.ParseCommand(com);
                sub.RunCommandA(command);
            }
            GeneralMethods.WriteOutput(day, "a", sub.CalculateResult().ToString());
        }
        public static void CalculateB()
        {
            var commands = GeneralMethods.ReadInputFileStringArray(day, "a");
            Submarine sub = new();
            Command command = new();
            foreach (string com in commands)
            {
                command.ParseCommand(com);
                sub.RunCommandB(command);
            }
            GeneralMethods.WriteOutput(day, "b", sub.CalculateResult().ToString());
        }
    }
}
