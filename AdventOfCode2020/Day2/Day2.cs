using System.Reflection;
using Utilities;

namespace AdventOfCode2020.Day2
{
    public static class Day2
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var passwords = IO.ReadInputFileStringArray(day, "a");
            int count = 0;
            Password pass = new();
            foreach (var password in passwords)
            {
                pass.ParsePassword(password);
                if (pass.ValidateA())
                    count++;
            }

            IO.WriteOutput(day, "a", count.ToString());
        }
        public static void CalculateB()
        {
            var passwords = IO.ReadInputFileStringArray(day, "a");
            int count = 0;
            Password pass = new();
            foreach (var password in passwords)
            {
                pass.ParsePassword(password);
                if (pass.ValidateB())
                    count++;
            }

            IO.WriteOutput(day, "b", count.ToString());
        }
    }
}
