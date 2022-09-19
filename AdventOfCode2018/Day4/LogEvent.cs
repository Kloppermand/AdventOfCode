using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2018.Day4
{
    class LogEvent
    {
        public DateTime time { get; set; }
        public string theEvent { get; set; }

        public LogEvent(string logEvent)
        {
            time = DateTime.Parse(logEvent.Substring(1, 16));
            theEvent = logEvent.Substring(19);
        }
    }
}
