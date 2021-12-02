using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day1
{
    public static class Day1
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;
        public static void CalculateA()
        {
            var numbers = GeneralMethods.ReadInputFileIntArray(day, "a");
            string result = GetIncreases(numbers).ToString();
            GeneralMethods.WriteOutput(day, "a", result);
        }
        
        public static void CalculateB()
        {
            var numbers = GeneralMethods.ReadInputFileIntArray(day, "a");
            var avgNumbers = SlidingAverage(numbers, 3);
            string result = GetIncreases(avgNumbers).ToString();
            GeneralMethods.WriteOutput(day, "b", result);
        }

        private static int GetIncreases(int[] numbers)
        {
            int increases = 0;
            for (int i = 0; i < numbers.Count()-1; i++)
            {
                if (numbers[i + 1] > numbers[i])
                    increases++;
            }
            return increases;
        }

        private static int[] SlidingAverage(int[] numbers, int windowSize)
        {
            int[] retNumbers = new int[numbers.Count() - windowSize + 1];
            for (int i = 0; i < retNumbers.Count(); i++)
            {
                for (int j = 0; j < windowSize; j++)
                {
                    retNumbers[i] += numbers[i + j];
                }
            }
            return retNumbers;
        }
    }
}
