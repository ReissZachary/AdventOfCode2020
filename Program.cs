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
        static void Main(string[] args)
        {
            //Day 1
            Tuple<int, int> result = Day1_2020Sum.Execute(D1_FILE_PATH);
            Console.WriteLine($"Day 1 results are: {result}\n");

            //Day2
            Tuple<int, int> d2Result = Day2_PasswordPhilosophy.Execute(D2_FILE_PATH);
            Console.WriteLine($"Day 2 results are {d2Result}");
        }
    }
}
