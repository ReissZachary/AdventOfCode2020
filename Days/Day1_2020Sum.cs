using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    public class Day1_2020Sum
    {
        const int TARGET_NUMBER = 2020;
        public static Tuple<int, int> Execute(string path)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();

            string[] numbers = File.ReadAllLines(path);
            int part1Value = 0;

            for(int i = 0; i < numbers.Length; i++)
            {
                dict.Add(int.Parse(numbers[i]), int.Parse(numbers[i]));
            }

            for(int i = 0; i < numbers.Length; i++)
            {
                var comp = TARGET_NUMBER - int.Parse(numbers[i]);

                if(dict.TryGetValue(comp, out int value))
                {
                    part1Value = int.Parse(numbers[i]) * value;
                }
            }

            return new Tuple<int, int>(part1Value, 0);
        }
    }
}
