using System.Reflection;
using Utilities;

namespace Templates
{
    public static class Template
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringArray(day, "a");



            string result = "";
            IO.WriteOutput(day, "a", result);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArray(day, "a");



            string result = "";
            IO.WriteOutput(day, "b", result);
        }
    }
}
