using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2020.Day6
{
    public static class Day6
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var answers = IO.ReadInputFileStringArrayBlankLine(day, "a");
            int sum = 0;
            foreach (var answer in answers)
            {
                sum += answer.Replace(" ","").Distinct().Count();
            }

            IO.WriteOutput(day, "a", sum.ToString());
        }
        public static void CalculateB()
        {
            var answers = IO.ReadInputFileStringArrayBlankLine(day, "a");
            int sum = 0;
            foreach (var answer in answers)
            {
                string[] persons = answer.Split(' ');
                string baseAnswers = persons[0];
                foreach (var person in persons)
                {
                    baseAnswers = new string(baseAnswers.Intersect(person).ToArray());
                }
                sum += baseAnswers.Length;
            }

            IO.WriteOutput(day, "b", sum.ToString());
        }
    }
}
