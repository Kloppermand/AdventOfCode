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
        public static void CalculateA()
        {
            string inputPathA = Path.Combine(Environment.CurrentDirectory, $"../../../Day1/Day1_input_a.txt");
            string outputPathA = Path.Combine(Environment.CurrentDirectory, $"../../../Day1/Day1_output_a.txt");

            var numbers = File.ReadAllText(inputPathA).Split("\r\n").Select(x => int.Parse(x)).ToArray();
            
            File.WriteAllText(outputPathA, GetIncreases(numbers).ToString());
        }
        
        public static void CalculateB()
        {
            string inputPathA = Path.Combine(Environment.CurrentDirectory, $"../../../Day1/Day1_input_a.txt");
            string outputPathA = Path.Combine(Environment.CurrentDirectory, $"../../../Day1/Day1_output_b.txt");

            var numbers = File.ReadAllText(inputPathA).Split("\r\n").Select(x => int.Parse(x)).ToArray();
            var avgNumbers = SlidingAverage(numbers, 3);
            File.WriteAllText(outputPathA, GetIncreases(avgNumbers).ToString());
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
