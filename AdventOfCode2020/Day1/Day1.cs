using System.Reflection;
using Utilities;

namespace AdventOfCode2020.Day1
{
    public static class Day1
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var expenses = IO.ReadInputFileIntArray(day, "a");

            foreach (var entry in expenses)
            {
                foreach (var otherEntry in expenses)
                {
                    if (entry + otherEntry == 2020)
                    {
                        IO.WriteOutput(day, "a", (entry * otherEntry).ToString());
                        return;
                    }
                }
            }
        }
        public static void CalculateB()
        {
            var expenses = IO.ReadInputFileIntArray(day, "a");

            foreach (var entry in expenses)
            {
                foreach (var otherEntry in expenses)
                {
                    foreach (var ThirdEntry in expenses)
                    {
                        if (entry + otherEntry + ThirdEntry == 2020)
                        {
                            IO.WriteOutput(day, "b", (entry * otherEntry * ThirdEntry).ToString());
                            return;
                        }

                    }
                }
            }
        }
    }
}
