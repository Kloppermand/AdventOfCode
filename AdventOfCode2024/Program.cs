using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace AdventOfCode2024
{
    class Program
    {
        static void Main(string[] args)
        {
            string namespaceName = typeof(Program).Namespace;
            Console.WriteLine($"===== Running {namespaceName} =====\n");

            RunAll();

            Console.WriteLine($"===== Done running {namespaceName} =====");
            Console.ReadLine();
        }

        static void RunAll()
        {
            Stopwatch sw = new Stopwatch();
            string namespaceName = typeof(Program).Namespace;
            var classes = System.Reflection.Assembly.GetExecutingAssembly().GetTypes().Where(x => x.Namespace.StartsWith(namespaceName) && Regex.IsMatch(x.Name, @"Day(\d{1}|\d{2})"));

            foreach (var day in classes)
            {
                var parts = day.GetMethods().Where(x => Regex.IsMatch(x.Name, @"Calculate(A|B)"));
                foreach (var part in parts)
                {
                    sw.Restart();
                    part.Invoke(null, null);
                    sw.Stop();
                    Console.WriteLine($"{namespaceName} {day.Name} {part.Name} ran in approximately {sw.ElapsedMilliseconds / 1000, 5} s");
                }
                Console.WriteLine();
            }
        }
    }
}
