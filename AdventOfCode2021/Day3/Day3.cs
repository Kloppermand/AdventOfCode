using System;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2021.Day3
{
    public static class Day3
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var diagRows = IO.ReadInputFileStringArray(day, "a");

            int[] sum = GetMostCommon(diagRows);

            int gamma = BinaryToDecimal(sum);
            int epsilon = (int)Math.Pow(2, sum.Length) - 1 - gamma;

            IO.WriteOutput(day, "a", (gamma*epsilon).ToString());
        }
        public static void CalculateB()
        {
            var diagRows = IO.ReadInputFileStringArray(day, "a");
            int n = diagRows[0].Length;
            var otherDiagRows = new string[diagRows.Length];
            diagRows.CopyTo(otherDiagRows,0);
            for (int i = 0; i < n; i++)
            {
                if (diagRows.Length == 1)
                    break;

                int[] common = GetMostCommon(diagRows);
                diagRows = diagRows.Where(x => int.Parse(x.Substring(i,1)) == common[i]).ToArray();
            }
            for (int i = 0; i < n; i++)
            {
                if (otherDiagRows.Length == 1)
                    break;
                int[] common = GetMostCommon(otherDiagRows);
                otherDiagRows = otherDiagRows.Where(x => int.Parse(x.Substring(i,1)) != common[i]).ToArray();
            }

            int oxygen = BinaryToDecimal(diagRows[0]);
            int CO2Scrub = BinaryToDecimal(otherDiagRows[0]);

            IO.WriteOutput(day, "b", (oxygen * CO2Scrub).ToString());
        }

        private static int BinaryToDecimal(string bin)
        {
            int[] convBin = new int[bin.Length];
            for (int i = 0; i < bin.Length; i++)
            {
                convBin[i] = int.Parse(bin.Substring(i,1));
            }
            return BinaryToDecimal(convBin);
        }
        private static int BinaryToDecimal(int[] bin)
        {
            int dec = 0;
            for (int i = 0; i < bin.Length; i++)
            {
                dec += (int) Math.Pow(2, bin.Length - i - 1) * bin[i];
            }
            return dec;
        }

        private static int[] GetMostCommon(string[] diagRows)
        {
            int[] sum = new int[diagRows[0].Length];
            foreach (var row in diagRows)
            {
                for (int i = 0; i < row.Length; i++)
                {
                    if (row[i] == '1')
                        sum[i]++;
                }
            }

            for (int i = 0; i < sum.Length; i++)
            {
                sum[i] = sum[i] < diagRows.Length / 2.0 ? 0 : 1;
            }
            return sum;
        }
    }
}
