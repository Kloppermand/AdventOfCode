using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2022.Day5
{
    public static class Day5
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringRaw(day, "a");

            var (stacks, instructions) = InitializeStackAndInstructions(input);

            foreach (var instruction in instructions)
            {
                var instructionArray = instruction.Split(' ');
                for (int i = 0; i < int.Parse(instructionArray[1].ToString()); i++)
                {
                    var crate = stacks[int.Parse(instructionArray[3].ToString())].Pop();
                    stacks[int.Parse(instructionArray[5].ToString())].Push(crate);
                }
            }


            IO.WriteOutput(day, "a", GetTopCrates(stacks));
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringRaw(day, "a");

            var (stacks, instructions) = InitializeStackAndInstructions(input);

            foreach (var instruction in instructions)
            {
                Stack<char> tmpStack = new();
                var instructionArray = instruction.Split(' ');
                for (int i = 0; i < int.Parse(instructionArray[1].ToString()); i++)
                {
                    var crate = stacks[int.Parse(instructionArray[3].ToString())].Pop();
                    tmpStack.Push(crate);
                }
                while (tmpStack.Count > 0)
                {
                    stacks[int.Parse(instructionArray[5].ToString())].Push(tmpStack.Pop());
                }
            }

            IO.WriteOutput(day, "b", GetTopCrates(stacks));
        }

        public static string GetTopCrates(Stack<char>[] stacks)
        {
            string result = "";
            foreach (var stack in stacks)
            {
                result += stack.Count() < 1 ? "" : stack.Pop();
            }
            return result;
        }

        public static (Stack<char>[],string[]) InitializeStackAndInstructions(string input)
        {
            var splitted = input.Split("\n\n");
            var initial = splitted[0].Split("\n");
            var instructions = splitted[1].Split("\n").Where(x => x != "").ToArray();

            var index = initial[^1];
            int maxIndex = index.Select(x => x != ' ' ? int.Parse(x.ToString()) : 0).Max();
            var initialStacks = initial[..^1];

            Stack<char>[] stacks = new Stack<char>[maxIndex + 1];
            for (int i = 0; i < maxIndex + 1; i++)
            {
                stacks[i] = new Stack<char>();
            }

            foreach (var item in initialStacks.Reverse())
            {
                for (int i = 0; i < item.Length; i++)
                {
                    if (item[i] != ' ' && item[i] != '[' && item[i] != ']')
                    {
                        stacks[i / 4 + 1].Push(item[i]);
                    }
                }
            }

            return (stacks, instructions);
        }
    }
}
