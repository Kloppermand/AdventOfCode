using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2020.Day8
{
    public static class Day8
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            Instruction[] instructions = new Instruction[input.Length];
            for (int j = 0; j < input.Length; j++)
            {
                instructions[j] = new Instruction(input[j]);
            }
            int i = 0;
            int accumulator = 0;
            while (i < instructions.Length)
            {
                switch (instructions[i].Operation)
                {
                    case "acc":
                        accumulator += instructions[i].Argument;
                        i++;
                        break;
                    case "jmp":
                        i += instructions[i].Argument;
                        break;
                    default:
                        i++;
                        break;
                }
                if (instructions[i].BeenRun)
                {
                    break;
                }
                instructions[i].BeenRun = true;
            }


            IO.WriteOutput(day, "a", accumulator.ToString());
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            Instruction[] instructions = new Instruction[input.Length];
            for (int j = 0; j < instructions.Length; j++)
            {
            for (int k = 0; k < input.Length; k++)
            {
                instructions[k] = new Instruction(input[k]);
            }
                
                if (instructions[j].Operation.Equals("acc"))
                    continue;
                else if (instructions[j].Operation.Equals("jmp"))
                    instructions[j].Operation = "nop";
                else if (instructions[j].Operation.Equals("nop"))
                    instructions[j].Operation = "jmp";

                int i = 0;
                int accumulator = 0;
                bool loopDetected = false;
                while (i < instructions.Length)
                {
                    switch (instructions[i].Operation)
                    {
                        case "acc":
                            accumulator += instructions[i].Argument;
                            i++;
                            break;
                        case "jmp":
                            i += instructions[i].Argument;
                            break;
                        default:
                            i++;
                            break;
                    }
                    if (i >= instructions.Length)
                        break;
                    if (instructions[i].BeenRun)
                    {
                        loopDetected = true;
                        break;
                    }
                    instructions[i].BeenRun = true;
                }
                if (!loopDetected)
                {
                    IO.WriteOutput(day, "b", accumulator.ToString());
                    break;
                }
            }

        }
    }
}
