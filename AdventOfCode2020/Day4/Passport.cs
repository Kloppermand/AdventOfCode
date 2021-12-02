using System.Collections.Generic;
using System.Globalization;
namespace AdventOfCode2020.Day4
{
    public class Passport
    {
        public string byr { get; set; }
        public string iyr { get; set; }
        public string eyr { get; set; }
        public string hgt { get; set; }
        public string hcl { get; set; }
        public string ecl { get; set; }
        public string pid { get; set; }
        public string cid { get; set; }

        public void ParsePasport(string raw)
        {
            string[] rawList = raw.Split(' ');

            foreach (var item in rawList)
            {
                string[] tempItem = item.Split(':');
                string key = tempItem[0];
                string value = tempItem[1];
                switch (key)
                {
                    case "byr":
                        byr = value;
                        break;
                    case "iyr":
                        iyr = value;
                        break;
                    case "eyr":
                        eyr = value;
                        break;
                    case "hgt":
                        hgt = value;
                        break;
                    case "hcl":
                        hcl = value;
                        break;
                    case "ecl":
                        ecl = value;
                        break;
                    case "pid":
                        pid = value;
                        break;
                    case "cid":
                        cid = value;
                        break;
                    default:
                        break;
                }
            }
        }

        public bool ValidateA()
        {
            return byr is not null && iyr is not null && eyr is not null && hgt is not null && hcl is not null && ecl is not null && pid is not null;
        }

        public bool ValidateB()
        {
            int.TryParse(byr, out int _byr);
            if (byr is null || _byr < 1920 || _byr > 2002) return false;

            int.TryParse(iyr, out int _iyr);
            if (iyr is null || _iyr < 2010 || _iyr > 2020) return false;

            int.TryParse(eyr, out int _eyr);
            if (eyr is null || _eyr < 2020 || _eyr > 2030) return false;

            int.TryParse(hgt?[..^2],out int _hgt);
            if (hgt is null || (hgt[^2..].Equals("in") && (_hgt < 59 || _hgt > 76))) return false;
            if (hgt is null || (hgt[^2..].Equals("cm") && (_hgt < 150 || _hgt > 193))) return false;
            if (!(hgt.Contains("in") || hgt.Contains("cm"))) return false;

            if (hcl is null || hcl[0]!='#' || hcl.Length != 7 || !int.TryParse(hcl[1..], System.Globalization.NumberStyles.HexNumber,null, out var fap)) return false;

            List<string> ecls = new List<string> { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
            if (ecl is null || !ecls.Contains(ecl)) return false;

            if (pid is null || pid.Length != 9 || !int.TryParse(pid, out fap)) return false;

            return byr is not null && iyr is not null && eyr is not null && hgt is not null && hcl is not null && ecl is not null && pid is not null;
        }
    }
}
