using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;


namespace AdventOfCode2020.Day5
{
    public static class Day5
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var seats = IO.ReadInputFileStringArray(day, "a");
            var ids = GetSeatIds(seats);
            
            IO.WriteOutput(day, "a", ids.Max().ToString());
        }
        public static void CalculateB()
        {
            var seats = IO.ReadInputFileStringArray(day, "a");
            var ids = GetSeatIds(seats);

            ids.Sort();
            int mySeat = 0;
            for (int i = 0; i < ids.Count-1; i++)
            {
                if (ids[i + 1] - ids[i] != 1)
                {
                    mySeat = ids[i] + 1;
                    break;
                }
            }

            IO.WriteOutput(day, "b", mySeat.ToString());
        }

        private static List<int> GetSeatIds(string[] seats)
        {
            List<int> ids = new List<int>();
            foreach (var seat in seats)
            {
                int row = 0;
                int col = 0;
                for (int i = 0; i < 7; i++)
                {
                    if (seat[i] == 'B')
                        row += (int)System.Math.Pow(2, 6 - i);
                }

                for (int i = 0; i < 3; i++)
                {
                    if (seat[i + 7] == 'R')
                        col += (int)System.Math.Pow(2, 2 - i);
                }

                ids.Add(row * 8 + col);
            }
            return ids;
        }
    }
}
