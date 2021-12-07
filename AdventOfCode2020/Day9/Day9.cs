using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2020.Day9
{
    public static class Day9
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileLongArray(day, "a");
            

            IO.WriteOutput(day, "a", GetInvalidNumber(25,input).ToString());
        }

        public static void CalculateB()
        {
            var input = IO.ReadInputFileLongArray(day, "a");
            long n = GetInvalidNumber(25, input);
            for (int i = 0; i < input.Length; i++)
            {
                long sum = 0;
                int j = i;
                while(sum < n)
                {
                    sum += input[j];
                    if(sum == n)
                    {
                        long a = input[i..j].Min();
                        long b = input[i..j].Max();
                        IO.WriteOutput(day, "b", (a+b).ToString());
                        return;
                    }
                    j++;
                }
            }
        }

        private static bool IsValid(long n, long[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                for (int j = i+1; j < list.Length; j++)
                {
                    if (list[i] + list[j] == n)
                        return true;
                }
            }
            return false;
        }

        private static long GetInvalidNumber(int scope, long[] input)
        {
            int i;
            for (i = scope; i < input.Length; i++)
            {
                if (!IsValid(input[i], input[(i - scope)..(i)]))
                    break;
            }
            return input[i];
        }
    }
}
