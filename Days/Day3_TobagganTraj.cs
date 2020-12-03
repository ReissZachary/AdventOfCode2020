﻿using AdventOfCode.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    public class Day3_TobagganTraj
    {
        public static char[,] SLOPES = new char[31, 323];
        public static int TOBOGGANXCOORD;
        public static int TOBOGGANYCOORD;

        public static Tuple<int, long> Execute(string path)
        {
            string[] lines = File.ReadAllLines(path);

            int part1Result = Part1EncounteredTrees(lines);            
            long part2Result = Part2ProductOfAllTreesOnDiffSlopes();

            return new Tuple<int, long>(part1Result, part2Result);
        }

        private static int Part1EncounteredTrees(string[] lines)
        {
            int currentXLocation = 0;
            int currentYLocation = 0;

            foreach (string line in lines)
            {
                foreach(char c in line)
                {
                   SLOPES[currentXLocation, currentYLocation] = c;
                    currentXLocation++;
                }
                currentYLocation++;
                currentXLocation = 0;
            }
            return TraverseMountain(new Location(3, 1));
        }

        public static long Part2ProductOfAllTreesOnDiffSlopes()
        {
            long product = 1;
            Location[] Locations = new Location[5] { new Location(1, 1), new Location(3, 1), new Location(5, 1), new Location(7, 1), new Location(1, 2) };

            foreach (Location p in Locations)
            {
                product *= TraverseMountain(p);
            }

            return product;
        }

        public static int TraverseMountain(Location p)
        {
            TOBOGGANXCOORD = 0;
            TOBOGGANYCOORD = 0;
            int treeCount = 0;
            while (TOBOGGANYCOORD < (323 - p.Y))
            {
                TOBOGGANXCOORD += p.X;
                TOBOGGANYCOORD += p.Y;
                if (TOBOGGANXCOORD > 30)
                    TOBOGGANXCOORD -= 31;

                if (SLOPES[TOBOGGANXCOORD, TOBOGGANYCOORD] == '#')
                    treeCount++;
            }
            return treeCount;
        }

    }    
}
