using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    public class Day2
    {
        public static List<string> Passwords = new List<string>();
        public static List<string> Rules = new List<string>();
        public static List<char[]> Letters = new List<char[]>();
        public static int ValidPasswordCountP1 = 0;
        public static int ValidPasswordCountP2 = 0;
        public static Tuple<int, int> Execute(string path)
        {
            string[] rulesAndPasswords = File.ReadAllLines(path);
            string[] splitRulesAndPasswords;
            string[] rules;

            foreach(string ruleAndPassword in rulesAndPasswords)
            {
                splitRulesAndPasswords = ruleAndPassword.Split(":");
                Passwords.Add(splitRulesAndPasswords[1]);

                rules = splitRulesAndPasswords[0].Split(' ');
                Rules.Add(rules[0]);
                Letters.Add(rules[1].ToCharArray());                
            }

            var i = 0;
            foreach (string password in Passwords)
            {
                int countOfSelectedLetter = CountLetters(password, Letters[i]);
                char[] brokenPassword = password.ToCharArray();
                var upperLowerNumbers = Rules[i].Split("-");
                var selectedLetter = Letters[i].FirstOrDefault();
                var lowerIndex = int.Parse(upperLowerNumbers[0]);
                var upperIndex = int.Parse(upperLowerNumbers[1]);
                var lowerLetter = password[lowerIndex];
                var upperLetter = password[upperIndex];

                //Part 1
                if (countOfSelectedLetter >= int.Parse(upperLowerNumbers[0]) && countOfSelectedLetter <= int.Parse(upperLowerNumbers[1]))
                {
                    ValidPasswordCountP1++;
                }

                //Part2
                if (lowerLetter == selectedLetter || upperLetter == selectedLetter)
                {
                    if(lowerLetter != upperLetter)
                    {
                        ValidPasswordCountP2++;
                    }
                }
                i++;
            }

            return new Tuple<int, int>(ValidPasswordCountP1, ValidPasswordCountP2);
            
        }

        private static int CountLetters(string password, char[] letter)
        {
            return password.Count(w => w == letter[0]);
        }
    }
}
