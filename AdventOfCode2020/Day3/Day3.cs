using System.Reflection;
using Utilities;

namespace AdventOfCode2020.Day3
{
    public static class Day3
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var landscape = IO.ReadInputFileStringArray(day, "a");

            int trees = CalculateTreesInPath(landscape, 3, 1);

            IO.WriteOutput(day, "a", trees.ToString());
        }
        public static void CalculateB()
        {
            var landscape = IO.ReadInputFileStringArray(day, "a");
            long result = 1;

            result *= CalculateTreesInPath(landscape, 1, 1);
            result *= CalculateTreesInPath(landscape, 3, 1);
            result *= CalculateTreesInPath(landscape, 5, 1);
            result *= CalculateTreesInPath(landscape, 7, 1);
            result *= CalculateTreesInPath(landscape, 1, 2);

            IO.WriteOutput(day, "b", result.ToString());
        }

        private static int CalculateTreesInPath(string[] landscape, int xOffSet, int yOffSet)
        {
            int period = landscape[0].Length;
            int count = 0;
            int j = 0;
            for (int i = 0; i < landscape.Length; i += yOffSet)
            {
                if (landscape[i][j] == '#')
                    count++;

                j = (j + xOffSet) % period;
            }
            return count;
        }
    }
}
