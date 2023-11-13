using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2019.Day2
{
    public static class Day2
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileIntArraySingleLine(day, "a");
            input[1] = 12;
            input[2] = 2;
            //input = "1,9,10,3,2,3,11,0,99,30,40,50".Split(',').Select(x => int.Parse(x)).ToArray();
            RunIntcode(input);

            IO.WriteOutput(day, "a", input[0]);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileIntArraySingleLine(day, "a");

            int noun = 0;
            int verb = 0;
            int result = 0;

            bool found = false;
            var attempt = new int[input.Length];

            for (noun = 0; noun < 100 && !found; noun++)
            {
                for (verb = 0; verb < 100 && !found; verb++)
                {
                    input.CopyTo(attempt, 0);

                    attempt[1] = noun;
                    attempt[2] = verb;

                    if (RunIntcode(attempt)[0] == 19690720)
                    {
                        result = 100 * noun + verb;
                        found = true;
                    }
                }
            }

            IO.WriteOutput(day, "b", result);
        }

        private static int[] RunIntcode(int[] input)
        {
            int pointer = 0;

            while (pointer < input.Length)
            {
                if (input[pointer] == 1)
                    input[input[pointer + 3]] = input[input[pointer + 1]] + input[input[pointer + 2]];

                if (input[pointer] == 2)
                    input[input[pointer + 3]] = input[input[pointer + 1]] * input[input[pointer + 2]];

                if (input[pointer] == 99)
                    break;

                pointer += 4;
            }

            return input;
        }
    }
}
