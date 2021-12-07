using System.Reflection;
using Utilities;
using System.Linq;
using System;
using System.Collections.Generic;

namespace Templates
{
    public static class DayMainTemplate
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringArray(day, "a");



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
