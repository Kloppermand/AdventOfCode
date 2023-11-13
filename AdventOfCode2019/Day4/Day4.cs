using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2019.Day4
{
    public static class Day4
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var raw = IO.ReadInputFileString(day, "a");
            var input = raw.Split("-");

            int tot = 0;

            for (int i = int.Parse(input[0]); i <= int.Parse(input[1]); i++)
            {
                bool same = false;
                bool increase = true;

                string n = i.ToString();
                char last = n[0];

                for (int j = 1; j < 6; j++) 
                {
                    if (n[j] < last)
                    {
                        increase = false;
                        break;
                    }

                    if (n[j] == last) 
                    {
                        same = true;
                    }

                    last = n[j];
                }

                if(same && increase) 
                    tot++;
            }

            IO.WriteOutput(day, "a", tot);
        }
        public static void CalculateB()
        {
            var raw = IO.ReadInputFileString(day, "a");
            var input = raw.Split("-");
            int lower = int.Parse(input[0]);
            int upper = int.Parse(input[1]);
            int tot = 0;

            for (int i = lower; i <= upper; i++)
            {
                bool same = false;
                bool increase = true;

                string n = i.ToString();
                char last = n[0];

                for (int j = 1; j < 6; j++)
                {
                    if (n[j] < last)
                    {
                        increase = false;
                        break;
                    }

                    if (n[j] == last)
                    {
                        if (n.Count(c => n[j] == c) < 3)
                        {
                            same = true;
                        }
                    }

                    last = n[j];
                }

                if (same && increase)
                    tot++;
            }

            IO.WriteOutput(day, "b", tot);
        }
    }
}
