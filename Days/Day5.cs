using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    public class Day5
    {        
        public static Tuple<int, int> Execute(string filePath)
        {
            string[] boardingPasses = File.ReadAllLines(filePath);

            var seatIds = boardingPasses.Select(x => GetRow(x) * 8 + GetColumn(x));

            var seats = boardingPasses.Select(x => (Row: GetRow(x), Column: GetColumn(x)));

            int part1Result = Part1(seatIds);
            int part2Result = Part2(seats);

            return new Tuple<int, int>(part1Result, part2Result);
        }

        private static int Part2(IEnumerable<(int Row, int Column)> seats)
        {
            var columnsAvailable = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 };

            var mySeatRow = seats.GroupBy(x => x.Row).Where(row => row.Count() == 7).SelectMany(x => x);
            var columnsTaken = mySeatRow.Select(x => x.Column);
            var column = columnsAvailable.First(x => columnsTaken.Contains(x)) + 1;
            var row = mySeatRow.First().Row;

            return row * 8 + column;
        }

        private static int Part1(IEnumerable<int> seatIds) => seatIds.Max();

        public static int GetRow(string input)
        {
            //Get range beginning to three from the end -- should be all F or B
            var frontBackRange = input[..^3].Replace("F", "0").Replace("B", "1");
            return Convert.ToInt32(frontBackRange, 2);
        }

        public static int GetColumn(string input)
        {
            //Get range 3 from the end to end -- should be all L or R
            var leftRightRange = input[^3..].Replace("L", "0").Replace("R", "1");
            return Convert.ToInt32(leftRightRange, 2);
        }
    }
}
