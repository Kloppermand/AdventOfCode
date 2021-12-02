using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day2
{
    class Password
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public char character { get; set; }
        public string password { get; set; }

        public void ParsePassword(string raw)
        {
            var splitList = raw.Split(' ').ToArray();
            var minMax = splitList[0].Split('-');
            Min = int.Parse(minMax[0]);
            Max = int.Parse(minMax[1]);

            character = char.Parse(splitList[1].Substring(0, 1));

            password = splitList[2];
        }

        public bool ValidateA()
        {
            int count = password.Count(x => x == character);
            return count <= Max && count >= Min;
        }

        public bool ValidateB()
        {
            bool exists = password[Min - 1] == character || password[Max - 1] == character;
            bool both = password[Min - 1] == character && password[Max - 1] == character;
            return exists && !both;
        }
    }
}
