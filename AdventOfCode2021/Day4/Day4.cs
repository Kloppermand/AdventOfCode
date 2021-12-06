using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2021.Day4
{
    public static class Day4
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileString(day, "a").Split("\r\n\r\n");
            string[] draws = input[0].Split(',');
            List<Board> boards = new();
            foreach (var board in input[1..])
            {
                boards.Add(new Board(board));
            }

            foreach (var draw in draws)
            {
                foreach (var board in boards)
                {
                    board.DrawNumber(draw);
                    if(board.CheckBoard())
                    {
                        IO.WriteOutput(day, "a", (board.GetUndrawnSum() * int.Parse(draw)).ToString());
                        return;
                    }
                }
            }

        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileString(day, "a").Split("\r\n\r\n");
            string[] draws = input[0].Split(',');
            List<Board> boards = new();
            int wonBoards = 0;
            foreach (var board in input[1..])
            {
                boards.Add(new Board(board));
            }
            
            foreach (var draw in draws)
            {
                foreach (var board in boards)
                {
                    if (!board.HasWon)
                    {
                        board.DrawNumber(draw);
                        if (board.CheckBoard())
                        {
                            wonBoards++;
                            if(wonBoards >= boards.Count)
                            {
                                IO.WriteOutput(day, "b", (board.GetUndrawnSum() * int.Parse(draw)).ToString());
                                return;
                            }
                        }
                    }
                }
            }
        }

    }
}
