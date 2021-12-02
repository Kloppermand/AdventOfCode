using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace AdventOfCode2021.Day2
{
    public static class Day2
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var commands = Utilities.IO.ReadInputFileStringArray(day, "a");
            Submarine sub = new();
            Command command = new();
            foreach (string com in commands)
            {
                command.ParseCommand(com);
                sub.RunCommandA(command);
            }
            Utilities.IO.WriteOutput(day, "a", sub.CalculateResult().ToString());
        }
        public static void CalculateB()
        {
            var commands = Utilities.IO.ReadInputFileStringArray(day, "a");
            Submarine sub = new();
            Command command = new();
            foreach (string com in commands)
            {
                command.ParseCommand(com);
                sub.RunCommandB(command);
            }
            Utilities.IO.WriteOutput(day, "b", sub.CalculateResult().ToString());
        }
    }
}
