using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    public class Day6
    {
        public static Tuple<int, int> Execute(string d6_FILE_PATH)
        {
            var input = File.ReadAllText(d6_FILE_PATH).Split("\r\n\r");            

            int part1Result = Part1(input);
            int part2Result = Part2(input);

            return new Tuple<int, int>(part1Result, part2Result);
        }

        private static int Part2(string[] input)
        {
            int count = 0;

            var sum = input.Select(x => x.Distinct());

            foreach (var group in input)
            {
                var numOfGroups = group.Split("\r\n").Length;

                var groupNoNewLine = group.Where(x => (x != '\n'));
                var groupNoNewLine2 = groupNoNewLine.Where(x => (x != '\r')).ToList();

                var result = groupNoNewLine2.GroupBy(x => x).Where(x => x.Count() == numOfGroups).Select(x => x.Key);

                count += result.Count();
            }

            return count;
        }

        private static int Part1(string[] input)
        {
            int count = 0;

            var sum = input.Select(x => x.Distinct());

            foreach(var group in sum)
            {
                var groupNoNewLine = group.Where(x => (x != '\n'));                
                var groupNoNewLine2 = groupNoNewLine.Where(x => (x != '\r'));

                count += groupNoNewLine2.Count();
            }

            return count;
        }
    }
}
