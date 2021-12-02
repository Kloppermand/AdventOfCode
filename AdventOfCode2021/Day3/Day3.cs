using System.Reflection;

namespace AdventOfCode2021.Day3
{
    public static class Day3
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var commands = GeneralMethods.ReadInputFileStringArray(day, "a");



            string result = "";
            GeneralMethods.WriteOutput(day, "a", result);
        }
        public static void CalculateB()
        {
            var commands = GeneralMethods.ReadInputFileStringArray(day, "a");



            string result = "";
            GeneralMethods.WriteOutput(day, "b", result);
        }
    }
}
