using System.Reflection;
using Utilities;

namespace AdventOfCode2020.Day4
{
    public static class Day4
    {
        private static string day = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public static void CalculateA()
        {
            var passports = IO.ReadInputFileStringArrayBlankLine(day, "a");
            int count = 0;
            foreach (var pass in passports)
            {
            Passport passport = new();
                passport.ParsePasport(pass);
                if (passport.ValidateA())
                    count++;
            }
            
            IO.WriteOutput(day, "a", count.ToString());
        }
        public static void CalculateB()
        {
            var passports = IO.ReadInputFileStringArrayBlankLine(day, "a");
            int count = 0;
            foreach (var pass in passports)
            {
                Passport passport = new();
                passport.ParsePasport(pass);
                if (passport.ValidateB())
                    count++;
            }

            IO.WriteOutput(day, "b", count.ToString());
        }
    }
}
