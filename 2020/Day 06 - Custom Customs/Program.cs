using System;
using System.IO;

namespace Day_06___Custom_Customs
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"D:\Jonas\Coding\Challanges\Advent of Code\2020\Day 06 - Custom Customs\Day 06 - Input.txt";
            string lines = File.ReadAllText(filePath);
            lines = lines.Replace("\r\n", " ");
            string[] groups = lines.Split("  ");
            int sumDifferentAnswers = 0, sumSameAnswers = 0;
            string possibleAnswers = "abcdefghijklmnopqrstuvwxyz";


            foreach (string s in groups)
            {
                CountDifferentAnswers(s, possibleAnswers, ref sumDifferentAnswers);
                CountSameAnswers(s, possibleAnswers, ref sumSameAnswers);
            }

            Console.WriteLine("Day 06");
            Console.WriteLine("=======");

            Console.Write("Part 1: ");
            Console.WriteLine(sumDifferentAnswers);
            Console.WriteLine(sumSameAnswers);
        }

        private static void CountSameAnswers(string s, string possibleAnswers, ref int sumSameAnswers)
        {
            string[] entries = s.Split(" ");
            for (int i = 0; i < entries.Length; i++)
            {
                for (int j = 0; j < possibleAnswers.Length; j++)
                {
                    if (!entries[i].Contains(possibleAnswers[j]))
                    {
                        possibleAnswers = possibleAnswers.Replace(possibleAnswers[j], '-');
                    } 
                }
            }
            possibleAnswers = possibleAnswers.Replace("-", "");
            sumSameAnswers += possibleAnswers.Length;
        }

        static void CountDifferentAnswers(string s, string possibleAnswers, ref int sum)
        {
            int counter = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (possibleAnswers.Contains(s[i]))
                {
                    counter++;
                    possibleAnswers = possibleAnswers.Replace(s[i], '-');
                }
            }
            sum += counter;
            counter = 0;
        }

      
    }
}
