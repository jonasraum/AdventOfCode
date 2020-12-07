using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Day_07___Handy_Haversacks
{
    class Program
    {
        int variable = 1;
        static void Main(string[] args)
        {
            string filePath = @"D:\Jonas\Coding\Challanges\Advent of Code\2020\Day 07 - Handy Haversacks\Day 07 - Input.txt";

            List<string[]> allBags = File.ReadAllLines(filePath).ToList().Select(x => x.Split(" ", 3)).ToList();
            allBags = allBags.Select(x => x = new string[] { string.Join(" ", new string[] { x[0].Replace("bags", string.Empty), x[1] }), x[2] }).ToList();

            determinePossibleBags(allBags);
        }

        static void determinePossibleBags(List<string[]> allBags)
        {
            List<string[]> possibleBags = allBags.Where(x => x[0] == "shiny gold").ToList();
            List<string[]> nextLevelBags = possibleBags;

            for (int i = 0; i < possibleBags.Count; i++)
            {
                nextLevelBags = allBags.Where(x => x[1].Contains(possibleBags[i][0])).ToList();
                possibleBags = possibleBags.Concat(nextLevelBags).Distinct().ToList();
            }

            Console.WriteLine(possibleBags.Count - 1);
        }


    }
}
