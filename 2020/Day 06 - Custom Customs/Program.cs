using System;
using System.IO;

namespace Day_06___Custom_Customs
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"D:\Jonas\Coding\Challanges\Advent of Code\2020\Day 06 - Custom Customs\Day 06 - Input.txt";
            string[] groups = File.ReadAllText(filePath).Replace("\r\n", " ").Split("  ");
            int sumDifferentAnswers = 0, sumSameAnswers = 0;
            string possibleStatements = "abcdefghijklmnopqrstuvwxyz";

            foreach (string group in groups)
            {
                CountDifferentAnswers(group, possibleStatements, ref sumDifferentAnswers);
                CountSameAnswers(group, possibleStatements, ref sumSameAnswers);
            }

            Console.WriteLine("Day 06");
            Console.WriteLine("=======");

            Console.Write("Part 1: ");
            Console.WriteLine(sumDifferentAnswers);
            Console.Write("Part 2: ");
            Console.WriteLine(sumSameAnswers);
        }

        /// <summary>
        /// Only counts the letters that are given by every person of the group
        /// </summary>
        /// <param name="group">the group of statements that has to be observed</param>
        /// <param name="possibleStatements">all possible statements pooled together</param>
        /// <param name="sumSameAnswers">the acummulated sum of all groups observed until now</param>
        private static void CountSameAnswers(string group, string possibleStatements, ref int sumSameAnswers)
        {
            string[] entries = group.Split(" ");
            for (int i = 0; i < entries.Length; i++) //checks every entry discrete
            {
                for (int j = 0; j < possibleStatements.Length; j++) //checks for every possible statement if it is included in the entry
                {
                    if (!entries[i].Contains(possibleStatements[j]))
                    {
                        possibleStatements = possibleStatements.Replace(possibleStatements[j].ToString(), string.Empty);
                        j--;
                    } 
                }
            }
            sumSameAnswers += possibleStatements.Length;
        }

        /// <summary>
        /// Counts the letters that are given by at least person of the group
        /// </summary>
        /// <param name="group">the group of statements that has to be observed</param>
        /// <param name="possibleStatements">all possible statements pooled together</param>
        /// <param name="sumDifferentAnswers">the acummulated sum of all groups observed until now</param>
        static void CountDifferentAnswers(string group, string possibleStatements, ref int sumDifferentAnswers)
        {
            for (int i = 0; i < group.Length; i++) //checks for every letter in the group
            {
                if (possibleStatements.Contains(group[i]))
                {
                    possibleStatements = possibleStatements.Replace(group[i].ToString(), string.Empty); 
                }
            }
            sumDifferentAnswers += 26 - possibleStatements.Length;
        }
    }
}
