using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class UtilMath
    {
        public static int Clamp(int value, int min, int max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        public static double Clamp(double value, double min, double max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        public static long GCD(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public static long LCM(long a, long b)
        {
            return (a / GCD(a, b)) * b;
        }

        public static int Factorial(int n)
        {
            if (n < 0)
                throw new ArgumentException("Negative numbers do not have a factorial.");
            if (n == 0 || n == 1)
                return 1;
            int result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        public static double Factorial(double n)
        {
            if (n < 0)
                throw new ArgumentException("Negative numbers do not have a factorial.");
            if (n == 0 || n == 1)
                return 1;
            double result = 1;
            for (double i = 2; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        public static int BinomialCoefficient(int n, int k)
        {
            if (k < 0 || k > n)
                throw new ArgumentException("k must be between 0 and n.");
            return Factorial(n) / (Factorial(k) * Factorial(n - k));
        }

        public static double BinomialCoefficient(double n, double k)
        {
            if (k < 0 || k > n)
                throw new ArgumentException("k must be between 0 and n.");
            return Factorial(n) / (Factorial(k) * Factorial(n - k));
        }

        public static int Mod(int a, int b)
        {
            return (a % b + b) % b;
        }


        public static long Mod(long a, long b)
        {
            return (a % b + b) % b;
        }

        public static double Mod(double a, double b)
        {
            return (a % b + b) % b;
        }


    }
}
