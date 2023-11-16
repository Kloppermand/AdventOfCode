using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class Letters
    {
        public static string Interpret4x6Letters(string[] letters, char foreground = '#', char background = '.')
        {
            string result = "";

            for(int i = 0; i < letters[0].Length; i+=5) 
            {
                var tmp = "";
                foreach (var row in letters)
                {
                    tmp += row.Substring(i,4).Replace(foreground,'#').Replace(background,'.');
                }

                result += _letters4x6[tmp];
            }

            return result;
        }

        public static string Interpret4x6Letters(string letters, char foreground = '#', char background = '.')
        {
            return Interpret4x6Letters(letters.Trim().Split('\n'), foreground, background);
        }

        private static Dictionary<string, string> _letters4x6 = new Dictionary<string, string>()
        {
          { ".##."+
            "#..#"+
            "#..#"+
            "####"+
            "#..#"+
            "#..#", "A" },

          { "###."+
            "#..#"+
            "###."+
            "#..#"+
            "#..#"+
            "###.", "B" },

          { ".##." +
            "#..#" +
            "#..." +
            "#..." +
            "#..#" +
            ".##.", "C" },

          { "####"+
            "#..."+
            "###."+
            "#..."+
            "#..."+
            "####", "E" },

          { "####"+
            "#..."+
            "###."+
            "#..."+
            "#..."+
            "#...", "F" },

          { ".##."+
            "#..#"+
            "#..."+
            "#.##"+
            "#..#"+
            ".###", "G" },

          { "#..#"+
            "#..#"+
            "####"+
            "#..#"+
            "#..#"+
            "#..#", "H" },

          { "..##" +
            "...#" +
            "...#" +
            "...#" +
            "#..#" +
            ".##.", "J" },

          { "#..#"+
            "#.#."+
            "##.."+
            "#.#."+
            "#.#."+
            "#..#", "K" },

          { "#..."+
            "#..."+
            "#..."+
            "#..."+
            "#..."+
            "####", "L" },

          { "###."+
            "#..#"+
            "#..#"+
            "###."+
            "#..."+
            "#...", "P" },

          { "###."+
            "#..#"+
            "#..#"+
            "###."+
            "#.#."+
            "#..#", "R" },

          { "#..#"+
            "#..#"+
            "#..#"+
            "#..#"+
            "#..#"+
            ".##.", "U" },

          { "####"+
            "...#"+
            "..#."+
            ".#.."+
            "#..."+
            "####", "Z" },
        };
    }
}
