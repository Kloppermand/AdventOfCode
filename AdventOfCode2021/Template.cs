using System.Reflection;

namespace AdventOfCode2021
{
    public static class Template
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
