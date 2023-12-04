using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2023.Day4
{
    public static class Day4
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringArray(day, "a");

            //var res1 = GolfA1(input);
            var res2 = GolfA2(input);
            //var res3 = GolfA3(input);

            IO.WriteOutput(day, "a", res2);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            Dictionary<string, int> points = new Dictionary<string, int>();

            for (var i = input.Length-1; i > -1; i--)
            {
                var card = input[i].Split(":").Select(c => c.Trim());
                var nums = card.ElementAt(1).Split("|");
                var intersection = nums[0].Split().Intersect(nums[1].Split().Where(n=> n!=""));

                var point = intersection.Count();
                var count = point;
                for (var j = 1; j <= count; j++)
                {
                    point += points[$"Card {i + j + 1,3}"];
                }
                points.TryAdd(card.ElementAt(0), point);
            }

            IO.WriteOutput(day, "b", points.Values.Sum()+input.Length);
        }

        private static double GolfA1(string[] i)
        {
            return i.Sum(c => { var l = c.Split(':')[1].Trim().Replace("  ", " ").Split(" | "); var e = l[0].Split().Intersect(l[1].Split()).Count() - 1; return e < 0 ? 0 : Math.Pow(2, e); });
        }

        private static int GolfA2(string[] i)
        {
            return i.Sum(c => { var l = c.Split(':')[1].Trim().Replace("  ", " ").Split(" | "); return (int)Math.Pow(2, l[0].Split().Intersect(l[1].Split()).Count() - 1); });
        }

        private static int GolfA3(string[] i)
        {
            return i.Sum(c => (int)Math.Pow(2, c.Split(':')[1].Trim().Replace("  ", " ").Split(" | ")[0].Split().Intersect(c.Split(':')[1].Split(" | ")[1].Split()).Count() - 1));
        }
    }
}
