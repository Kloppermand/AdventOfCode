using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utilities;

namespace AdventOfCode2018.Day4
{
    public static class Day4
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            var guards = GetGuards(input);

            var mostSleepingGaurd = guards.OrderByDescending(x => x.timesAsleep.Sum()).First();
            var mostSleptMinute = mostSleepingGaurd.timesAsleep.ToList().IndexOf(mostSleepingGaurd.timesAsleep.Max());

            IO.WriteOutput(day, "a", mostSleptMinute*mostSleepingGaurd.id);
        }
        public static void CalculateB()
        {
            var input = IO.ReadInputFileStringArray(day, "a");
            var guards = GetGuards(input);

            var mostSleepingGaurd = guards.OrderByDescending(x => x.timesAsleep.Max()).First();
            var mostSleptMinute = mostSleepingGaurd.timesAsleep.ToList().IndexOf(mostSleepingGaurd.timesAsleep.Max());

            IO.WriteOutput(day, "b", mostSleptMinute * mostSleepingGaurd.id);
        }

        private static List<Guard> GetGuards(string[] input)
        {
            List<LogEvent> logEvents = new();
            foreach (var logEvent in input)
            {
                logEvents.Add(new LogEvent(logEvent));
            }
            logEvents = logEvents.OrderBy(x => x.time).ToList();

            List<Guard> guards = new();
            Guard currentGuard = new();
            foreach (var logEvent in logEvents)
            {
                if (logEvent.theEvent.Contains("Guard"))
                {
                    int id = int.Parse(logEvent.theEvent.Split(" ")[1].Replace("#", ""));
                    if (!guards.Exists(x => x.id == id)) guards.Add(new Guard { id = id });

                    currentGuard = guards.Find(x => x.id == id);
                }
                else
                {
                    if (logEvent.theEvent.Equals("falls asleep"))
                        currentGuard.lastFellAsleep = logEvent.time;
                    if (logEvent.theEvent.Equals("wakes up"))
                    {
                        for (int i = currentGuard.lastFellAsleep.Minute; i < logEvent.time.Minute; i++)
                        {
                            currentGuard.timesAsleep[i]++;
                        }
                    }
                }
            }

            return guards;
        }
    }
}
