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
        static void Main(string[] args)
        {
            string filePath = @"D:\Jonas\Coding\Challanges\Advent of Code\2020\Day 07 - Handy Haversacks\Day 07 - Input.txt";

            List<string[]> allBags = File.ReadAllLines(filePath).ToList().Select(x => x.Split(" ", 3)).ToList();
            allBags = allBags.Select(x => x = new string[] { string.Join(" ", new string[] { x[0], x[1] }), x[2] }).ToList();

            Console.WriteLine("Day 07");
            Console.WriteLine("========");

            Console.Write("\nPart 1: ");
            determinePossibleBags(allBags);

            Console.Write("Part 2: ");
            determineSumOfBags(allBags);
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

        private static void determineSumOfBags(List<string[]> allBags)
        {
            Dictionary<string, Dictionary<string, int>> bags = new Dictionary<string, Dictionary<string, int>>();

            allBags = allBags.Select(x => x = new string[] { x[0], x[1].Replace("contain", string.Empty).Replace("bags", string.Empty).Replace("bag", string.Empty).Replace(" .", string.Empty).Substring(2) }).ToList();
            foreach (string[] bag in allBags)
            {
                Dictionary<string, int> subBags = new Dictionary<string, int>();
                string[] relatedBags = bag[1].Split(" , ");
                foreach (string relatedBag in relatedBags)
                {
                    if (relatedBag != "no other")
                    {
                        string[] identifiers = relatedBag.Split(" ", 2);
                        subBags.Add(identifiers[1], Convert.ToInt32(identifiers[0]));
                    }
                    else
                    {
                        subBags.Add("no other", 0);
                    }
                }
                bags.Add(bag[0], subBags);
            }
            Console.WriteLine(CalculateResult(bags, "shiny gold"));
        }

        private static int CalculateResult(Dictionary<string, Dictionary<string, int>> bags, string currentlySearched)
        {
            int sumSubBags = 0;
            Dictionary<string, int> subBags = bags[currentlySearched];
            foreach (KeyValuePair<string, int> kvp in subBags)
            {
                if (kvp.Value != 0)
                {
                    sumSubBags += kvp.Value + kvp.Value * CalculateResult(bags, kvp.Key);
                }
                else
                {
                    return 0;
                }
            }
            return sumSubBags;
        }
    }
}
