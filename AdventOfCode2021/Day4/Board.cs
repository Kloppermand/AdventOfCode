using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day4
{
    class Board
    {
        public List<List<BoardNumber>> numbers { get; set; }
        public bool HasWon { get; set; }
        public Board(string board)
        {
            HasWon = false;
            numbers = new();
            foreach (var row in board.Split('\n'))
            {
                List<BoardNumber> tmpRow = new();
                foreach (var num in row.Trim().Replace("  ", " ").Split(' '))
                {
                    tmpRow.Add(new BoardNumber(num));
                }
                numbers.Add(tmpRow);
            }
        }

        public void DrawNumber(string num)
        {
            foreach (var row in numbers)
            {
                foreach (var number in row)
                {
                    if (number.Value.Equals(num))
                        number.Drawn = true;
                }
            }
        }

        public bool CheckBoard()
        {
            foreach (var row in numbers)
            {
                if (row.All(x => x.Drawn))
                {
                    HasWon = true;
                    return HasWon;
                }
            }

            for (int col = 0; col < numbers.Count; col++)
            {
                bool canWin = true;
                for (int row = 0; row < numbers[col].Count; row++)
                {
                    if (!numbers[row][col].Drawn)
                    {
                        canWin = false;
                        break;
                    }
                }
                if (canWin)
                {
                    HasWon = true;
                    return HasWon;
                }
            }

            return false;
        }

        public int GetUndrawnSum()
        {
            int sum = 0;
            foreach (var row in numbers)
            {
                foreach (var value in row)
                {
                    sum += !value.Drawn ? int.Parse(value.Value) : 0;
                }
            }
            return sum;
        }
    }

}
