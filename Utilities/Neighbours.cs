using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class Neighbours
    {
        public static int CountNeighbours8(int x, int y, string[] input, char targetChar)
        {
            int retValue = 0;

            // x-1
            if (x - 1 >= 0)
            {
                if (y - 1 >= 0)
                {
                    if (input[y - 1][x - 1] == targetChar)
                        retValue++;
                }

                if (input[y][x - 1] == targetChar)
                    retValue++;

                if (y + 1 < input.Length)
                    if (input[y + 1][x - 1] == targetChar)
                        retValue++;
            }
            
            // x
            if (y - 1 >= 0)
            {
                if (input[y - 1][x] == targetChar)
                    retValue++;
            }

            if (y + 1 < input.Length)
                if (input[y + 1][x] == targetChar)
                    retValue++;

            // x+1
            if (x + 1 < input[y].Length)
            {
                if (y - 1 >= 0)
                {
                    if (input[y - 1][x + 1] == targetChar)
                        retValue++;
                }

                if (input[y][x + 1] == targetChar)
                    retValue++;

                if (y + 1 < input.Length)
                    if (input[y + 1][x + 1] == targetChar)
                        retValue++;
            }

            return retValue;
        }

        public static int CountNeighbours4(int x, int y, string[] input, char targetChar)
        {
            int retValue = 0;

            // x-1
            if (x - 1 > 0)
            {
                if (input[y][x - 1] == targetChar)
                    retValue++;
            }

            // x
            if (y - 1 > 0)
            {
                if (input[y - 1][x] == targetChar)
                    retValue++;
            }

            if (y + 1 < input.Length)
                if (input[y + 1][x] == targetChar)
                    retValue++;

            // x+1
            if (x + 1 < input[y].Length)
            {
                if (input[y][x + 1] == targetChar)
                    retValue++;
            }

            return retValue;
        }
    }
}
