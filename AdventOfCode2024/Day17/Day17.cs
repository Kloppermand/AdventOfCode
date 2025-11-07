using MathNet.Numerics.Distributions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Utilities;

namespace AdventOfCode2024.Day17
{
    public static class Day17
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringArrayBlankLineKeepInternalLineBreaks(day, "a");
            var matches = Regex.Matches(input.First(), @"Register .: (\d*)");
            long regA = long.Parse(matches[0].Groups[1].Value);
            long regB = long.Parse(matches[1].Groups[1].Value);
            long regC = long.Parse(matches[2].Groups[1].Value);

            List<long> program = input.Last().Replace("Program: ", "").Split(",").Select(long.Parse).ToList();
            List<long> output = RunProgramA(ref regA, ref regB, ref regC, program);

            string result = string.Join(',', output);
            IO.WriteOutput(day, "a", result);
        }

        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArrayBlankLineKeepInternalLineBreaks(day, "test");
            var matches = Regex.Matches(input.First(), @"Register .: (\d*)");
            long regA = long.Parse(matches[0].Groups[1].Value);
            long regB = long.Parse(matches[1].Groups[1].Value);
            long regC = long.Parse(matches[2].Groups[1].Value);

            List<long> program = input.Last().Replace("Program: ", "").Split(",").Select(long.Parse).ToList();

            long lowest = 0;

            for (long i = 0; i < 1_000_000; i++)
            {
                List<long> output = RunProgramB(i, program);

                if (i == 117440)
                    regB = 0;

                if(output.SequenceEqual(program))
                {
                    lowest = i;
                    break;
                }
            }

            IO.WriteOutput(day, "b", lowest);
        }


        private static List<long> RunProgramB(long value, List<long> program)
        {
            var output = new List<long>();
            long regA = value;
            long regB = 0;
            long regC = 0;
            for (int i = 0; i < program.Count; i += 2)
            {
                switch (program[i])
                {
                    case 0: //Combo
                        regA /= (long)Math.Pow(2, Combo(program[i + 1], regA, regB, regC));
                        break;
                    case 1: //Literal
                        regB = (regB ^ program[i + 1]) % 8;
                        break;
                    case 2: //Combo
                        regB = Combo(program[i + 1], regA, regB, regC) % 8;
                        break;
                    case 3: //Literal
                        if (regA != 0)
                            i = (int)program[i + 1] - 2;
                        break;
                    case 4: //Ignore
                        regB ^= regC;
                        break;
                    case 5: //Combo
                        output.Add(Combo(program[i + 1], regA, regB, regC) % 8);
                        if (output.Last() != program.ElementAt(output.Count - 1))
                            return output;
                        break;
                    case 6: //Combo
                        regB = regA / (long)Math.Pow(2, Combo(program[i + 1], regA, regB, regC));
                        break;
                    case 7: //Combo
                        regC = regA / (long)Math.Pow(2, Combo(program[i + 1], regA, regB, regC));
                        break;

                    default:
                        break;
                }
            }

            return output;
        }

        private static List<long> RunProgramA(ref long regA, ref long regB, ref long regC, List<long> program)
        {
            var output = new List<long>();
            for (int i = 0; i < program.Count; i += 2)
            {
                switch (program[i])
                {
                    case 0: //Combo
                        regA /= (long)Math.Pow(2, Combo(program[i + 1], regA, regB, regC));
                        break;
                    case 1: //Literal
                        regB = (regB ^ program[i + 1]) % 8;
                        break;
                    case 2: //Combo
                        regB = Combo(program[i + 1], regA, regB, regC) % 8;
                        break;
                    case 3: //Literal
                        if (regA != 0)
                            i = (int)program[i + 1] - 2;
                        break;
                    case 4: //Ignore
                        regB ^= regC;
                        break;
                    case 5: //Combo
                        output.Add(Combo(program[i + 1], regA, regB, regC) % 8);
                        break;
                    case 6: //Combo
                        regB = regA / (long)Math.Pow(2, Combo(program[i + 1], regA, regB, regC));
                        break;
                    case 7: //Combo
                        regC = regA / (long)Math.Pow(2, Combo(program[i + 1], regA, regB, regC));
                        break;

                    default:
                        break;
                }
            }

            return output;
        }

        private static long Combo(long op, long regA, long regB, long regC)
        {
            switch (op)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    return op;
                case 4:
                    return regA;
                    case 5:
                    return regB;
                case 6:
                    return regC;
                case 7:
                default:
                    return op;
            }
        }
    }
}
