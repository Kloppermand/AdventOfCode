using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2018.Day7
{
    internal class Worker
    {
        public char? CurrentTask { get; private set; }
        public int TimeRemaining { get; private set; }
        public bool IsIdle => CurrentTask == null;
        public void AssignTask(char task, int baseDuration)
        {
            CurrentTask = task;
            TimeRemaining = baseDuration + (task - 'A' + 1);
        }
        public char? WorkOneSecond()
        {
            if (CurrentTask != null)
            {
                TimeRemaining--;
                if (TimeRemaining <= 0)
                {
                    var completedTask = CurrentTask;
                    CurrentTask = null;
                    TimeRemaining = 0;
                    return completedTask;
                }
            }
            return null;
        }

        public override string ToString()
        {
            if (CurrentTask != null)
                return $"Working on {CurrentTask} ({TimeRemaining}s remaining)";
            else
                return "Idle";
        }
    }
}
