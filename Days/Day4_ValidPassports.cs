using AdventOfCode.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    public class Day4_ValidPassports
    {
        public static Tuple<int, int> Execute(string filePath)
        {
            string[] input = File.ReadAllText(filePath).Split(Environment.NewLine);
            List<string> candidates = FindPassowrdsCandidates(input);

            return new Tuple<int, int>(SolvePartOne(candidates), SolvePartTwo(candidates));
        }

        private static int SolvePartOne(List<string> candidates)
        {
            int count = 0;
            foreach (string password in candidates)
            {
                if (DoesPasswordHaveAllFields(password))
                {
                    count++;
                }
            }

            return count;
        }

        private static int SolvePartTwo(List<string> candidates)
        {
            int count = 0;
            foreach (string password in candidates)
            {
                if (IsDataValid(password))
                {
                    count++;
                }
            }

            return count;
        }

        private static List<string> FindPassowrdsCandidates(string[] input)
        {
            List<string> passwords = new List<string>();
            string passwordData = String.Empty;
            foreach (string data in input)
            {
                if (data == String.Empty)
                {
                    passwordData.Trim();
                    passwords.Add(passwordData);
                    passwordData = String.Empty;
                    continue;
                }

                passwordData = passwordData + " " + data;
            }

            passwords.Add(passwordData);
            return passwords.Where(x => x.Split(" ").Length > 7).Select(x => x).ToList();
        }

        private static bool IsDataValid(string password)
        {
            List<string> data = new List<string>() { @"byr:(200[0-2]|19[2-9][0-9])",
                                                     @"iyr:(2020|201[0-9])",
                                                     @"eyr:(2030|202[0-9])",
                                                     @"hgt:((1[5-8][0-9]|19[0-3])cm)|hgt:(7[0-6]|59|6[0-9])in",
                                                     @"hcl:(#[0-9a-f]{6})",
                                                     @"ecl:(amb|blu|brn|gry|grn|hzl|oth)",
                                                     //TIL \b in regex
                                                     @"pid:(\d{9}\b)" };

            foreach (string regex in data)
            {
                MatchCollection matches = Regex.Matches(password, regex);
                if (matches.Count == 0)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool DoesPasswordHaveAllFields(string password)
        {
            List<string> data = new List<string>() { "byr:", "iyr:", "eyr:", "hgt:", "hcl:", "ecl:", "pid:" };
            foreach (string nData in data)
            {
                if (!password.Contains(nData))
                {
                    return false;
                }
            }

            return true;

        }
    }
}
