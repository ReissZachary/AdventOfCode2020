using AdventOfCode.Days;
using System;
using System.IO;
using System.Linq;
using static System.Console;

namespace AdventOfCode
{
    public class Program
    {
        const string D1_FILE_PATH = "../../../DayInputs/day1input.txt";
        const string D2_FILE_PATH = "../../../DayInputs/day2input.txt";
        const string D3_FILE_PATH = "../../../DayInputs/day3input.txt";
        const string D4_FILE_PATH = "../../../DayInputs/day4input.txt";
        const string D5_FILE_PATH = "../../../DayInputs/day5input.txt";
        const string D6_FILE_PATH = "../../../DayInputs/day6input.txt";
        static void Main(string[] args)
        {
            ////Day 1
            Tuple<int, int> result = Day1.Execute(D1_FILE_PATH);
            Console.WriteLine($"Day 1 results are: {result}\n");

            ////Day2
            Tuple<int, int> d2Result = Day2.Execute(D2_FILE_PATH);
            Console.WriteLine($"Day 2 results are {d2Result}\n");

            ////Day 3
            Tuple<int, long> d3Result = Day3.Execute(D3_FILE_PATH);
            Console.WriteLine($"Day 3 results are: {d3Result}\n");

            ////Day4
            Tuple<int, int> d4Result = Day4.Execute(D4_FILE_PATH);
            Console.WriteLine($"Day 4 results are: {d4Result}\n");

            ////Day5
            Tuple<int, int> d5Results = Day5.Execute(D5_FILE_PATH);
            Console.WriteLine($"Day 5 results are: {d5Results}\n");

            //Day6
            Tuple<int, int> d6Results = Day6.Execute(D6_FILE_PATH);
            Console.WriteLine($"Day 6 results are: {d6Results}\n");



        }
    }
}
