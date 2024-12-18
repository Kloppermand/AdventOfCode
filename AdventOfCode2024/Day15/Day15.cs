using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2024.Day15
{
    public static class Day15
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringArrayBlankLineKeepInternalLineBreaks(day, "a");

            var map = new Warehouse(input[0].Split("\n"));
            var commands = input[1];

            foreach (var command in commands)
            {
                //Console.WriteLine(command);
                //map.Print();
                int py = map.Map.IndexOf(map.Map.First(x => x.Contains('@')));
                int px = map.Map[py].IndexOf('@');
                map.ExecuteMove(px, py, command);
            }

            int result = 0;
            for (int i = 0; i < map.Map.Count; i++)
            {
                for (int j = 0; j < map.Map[i].Count; j++)
                {
                    if (map.Map[i][j] == 'O')
                        result += 100 * i + j;
                }
            }
            IO.WriteOutput(day, "a", result);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArrayBlankLineKeepInternalLineBreaks(day, "a");

            var map = new LargeWarehouse(input[0].Split("\n"));
            var commands = input[1];
            foreach (var command in commands)
            {
                //Console.WriteLine(command);
                //map.Print();
                int py = map.Map.IndexOf(map.Map.First(x => x.Contains('@')));
                int px = map.Map[py].IndexOf('@');
                if(map.CanMove(px, py, command))
                    map.MakeMove(px, py, command);
            }

            int result = 0;
            for (int i = 0; i < map.Map.Count; i++)
            {
                for (int j = 0; j < map.Map[i].Count; j++)
                {
                    if (map.Map[i][j] == '[')
                        result += 100 * i + j;
                }
            }

            IO.WriteOutput(day, "b", result);
        }

        public class Warehouse
        {
            public List<List<char>> Map { get; set; } = new();
            public Warehouse(string[] input)
            {
                foreach (var item in input)
                {
                    List<char> tmp = new();
                    foreach (var item2 in item)
                    {
                        tmp.Add(item2);
                    }
                    Map.Add(tmp);
                }
            }

            public bool ExecuteMove(int px, int py, char move)
            {
                switch (move)
                {
                    case '^':
                        if (Map[py - 1][px] == '#')
                            return false;
                        else if (Map[py - 1][px] == '.')
                        {
                            Map[py - 1][px] = Map[py][px];
                            Map[py][px] = '.';
                        }
                        else
                        {
                            if (ExecuteMove(px, py - 1, move))
                                return ExecuteMove(px, py, move);
                            return false;
                        }
                        return true;
                    case 'v':
                        if (Map[py + 1][px] == '#')
                            return false;
                        else if (Map[py + 1][px] == '.')
                        {
                            Map[py + 1][px] = Map[py][px];
                            Map[py][px] = '.';
                        }
                        else
                        {
                            if (ExecuteMove(px, py + 1, move))
                                return ExecuteMove(px, py, move);
                            return false;
                        }
                        return true;
                    case '>':
                        if (Map[py][px + 1] == '#')
                            return false;
                        else if (Map[py][px + 1] == '.')
                        {
                            Map[py][px + 1] = Map[py][px];
                            Map[py][px] = '.';
                        }
                        else
                        {
                            if (ExecuteMove(px + 1, py, move))
                                return ExecuteMove(px, py, move);
                            return false;
                        }
                        return true;
                    case '<':
                        if (Map[py][px - 1] == '#')
                            return false;
                        else if (Map[py][px - 1] == '.')
                        {
                            Map[py][px - 1] = Map[py][px];
                            Map[py][px] = '.';
                        }
                        else
                        {
                            if (ExecuteMove(px - 1, py, move))
                                return ExecuteMove(px, py, move);
                            return false;
                        }
                        return true;
                    default:
                        return true;
                }
            }

            public void Print()
            {
                foreach (var item in Map)
                {
                    foreach (var chr in item)
                    {
                        Console.Write(chr);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }

        public class LargeWarehouse
        {
            public List<List<char>> Map { get; set; } = new();
            public LargeWarehouse(string[] input)
            {
                foreach (var item in input)
                {
                    List<char> tmp = new();
                    foreach (var item2 in item)
                    {
                        switch (item2)
                        {
                            case '#':
                                tmp.Add('#');
                                tmp.Add('#');
                                break;
                            case '.':
                                tmp.Add('.');
                                tmp.Add('.');
                                break;
                            case 'O':
                                tmp.Add('[');
                                tmp.Add(']');
                                break;
                            case '@':
                                tmp.Add('@');
                                tmp.Add('.');
                                break;
                            default:
                                break;
                        }
                    }
                    Map.Add(tmp);
                }
            }
            public void MakeMove(int px, int py, char move)
            {
                switch (move)
                {
                    case '^':
                        switch (Map[py - 1][px])
                        {
                            case ('.'):
                                Map[py - 1][px] = Map[py][px];
                                Map[py][px] = '.';
                                return;

                            case ']':
                                MakeMove(px, py - 1, move);
                                MakeMove(px - 1, py - 1, move);
                                MakeMove(px, py, move);
                                return;

                            case '[':
                                MakeMove(px, py - 1, move);
                                MakeMove(px + 1, py - 1, move);
                                MakeMove(px, py, move);
                                return;
                        }
                        break;

                    case 'v':
                        switch (Map[py + 1][px])
                        {
                            case ('.'):
                                Map[py + 1][px] = Map[py][px];
                                Map[py][px] = '.';
                                return;

                            case ']':
                                MakeMove(px, py + 1, move);
                                MakeMove(px - 1, py + 1, move);
                                MakeMove(px, py, move);
                                return;

                            case '[':
                                MakeMove(px, py + 1, move);
                                MakeMove(px + 1, py + 1, move);
                                MakeMove(px, py, move);
                                return;
                        }
                        break;

                    case '>':
                        switch (Map[py][px + 1])
                        {
                            case ('.'):
                                Map[py][px + 1] = Map[py][px];
                                Map[py][px] = '.';
                                return;

                            case ']':
                                MakeMove(px + 1, py, move);
                                MakeMove(px, py, move);
                                MakeMove(px-1, py, move);
                                return;

                            case '[':
                                MakeMove(px + 2, py, move);
                                MakeMove(px + 1, py, move);
                                MakeMove(px, py, move);
                                return;
                        }
                        break;

                    case '<':
                        switch (Map[py][px - 1])
                        {
                            case ('.'):
                                Map[py][px - 1] = Map[py][px];
                                Map[py][px] = '.';
                                return;

                            case '[':
                                MakeMove(px - 1, py, move);
                                MakeMove(px, py, move);
                                MakeMove(px+1, py, move);
                                return;

                            case ']':
                                MakeMove(px - 2, py, move);
                                MakeMove(px - 1, py, move);
                                MakeMove(px, py, move);
                                return;
                        }
                        break;
                }
            }

            public bool CanMove(int px, int py, char move)
            {
                int tarx = px;
                int tary = py;

                switch (move)
                {
                    case '^':
                        tary--;
                        break;
                    case 'v':
                        tary++;
                        break;
                    case '>':
                        tarx++;
                        break;
                    case '<':
                        tarx--;
                        break;
                    default:
                        break;
                }

                if (Map[tary][tarx] == '.')
                    return true;

                if (Map[tary][tarx] == '#')
                    return false;

                int p1x = tarx;
                int p1y = tary;
                int p2x = tarx;
                int p2y = tary;

                if (Map[tary][tarx] == '[')
                    p2x++;

                if (Map[tary][tarx] == ']')
                    p1x--;


                switch (move)
                {
                    case '^':
                    case 'v':
                        return CanMove(p1x, p1y, move) && CanMove(p2x, p2y, move);
                    case '>':
                        return CanMove(p2x, p2y, move);
                    case '<':
                        return CanMove(p1x, p1y, move);
                    default:
                        return false;
                }
            }

            public void Print()
            {
                foreach (var item in Map)
                {
                    foreach (var chr in item)
                    {
                        Console.Write(chr);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
    }
}
