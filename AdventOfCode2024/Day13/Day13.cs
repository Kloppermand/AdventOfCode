using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Utilities;


namespace AdventOfCode2024.Day13
{
    public static class Day13
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringArrayBlankLineKeepInternalLineBreaks(day, "a");
            int result = 0;
            foreach (var line in input)
            {
                MatchCollection matches = Regex.Matches(line, @"Button A: X\+(\d+), Y\+(\d+)\nButton B: X\+(\d+), Y\+(\d+)\nPrize: X=(\d+), Y=(\d+)");
                double x1 = double.Parse(matches.First().Groups[1].Value);
                double y1 = double.Parse(matches.First().Groups[2].Value);
                double x2 = double.Parse(matches.First().Groups[3].Value);
                double y2 = double.Parse(matches.First().Groups[4].Value);
                double[] values = { x1, y1, x2, y2 };
                var A = Matrix<double>.Build.Dense(2, 2, values);
                var prize = Matrix<double>.Build.Dense(2, 1, new double[] { double.Parse(matches.First().Groups[5].Value), double.Parse(matches.First().Groups[6].Value) });
                var moves = A.Inverse().Multiply(prize);

                double a = moves.At(0, 0).Round(10);
                double b = moves.At(1, 0).Round(10);


                if (a >= 0 && a == a.Round(0) && a <= 100 &&
                    b >= 0 && b == b.Round(0) && b <= 100)
                    result += (int)(a * 3 + b);
            }

            IO.WriteOutput(day, "a", result);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArrayBlankLineKeepInternalLineBreaks(day, "a");
            long result = 0;
            foreach (var line in input)
            {
                MatchCollection matches = Regex.Matches(line, @"Button A: X\+(\d+), Y\+(\d+)\nButton B: X\+(\d+), Y\+(\d+)\nPrize: X=(\d+), Y=(\d+)");
                double x1 = double.Parse(matches.First().Groups[1].Value);
                double y1 = double.Parse(matches.First().Groups[2].Value);
                double x2 = double.Parse(matches.First().Groups[3].Value);
                double y2 = double.Parse(matches.First().Groups[4].Value);
                double[] values = { x1, y1, x2, y2 };
                var A = Matrix<double>.Build.Dense(2, 2, values);
                var prize = Matrix<double>.Build.Dense(2, 1, new double[] { double.Parse(matches.First().Groups[5].Value) + 10000000000000, double.Parse(matches.First().Groups[6].Value) + 10000000000000 });
                var moves = A.Inverse().Multiply(prize);

                double a = moves.At(0, 0).Round(3);
                double b = moves.At(1, 0).Round(3);


                if (a >= 0 && a == a.Round(0) &&
                    b >= 0 && b == b.Round(0))
                    result += (long)(a * 3 + b);
            }

            IO.WriteOutput(day, "b", result);
        }
    }
}
