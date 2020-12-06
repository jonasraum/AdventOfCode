using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_06___Custom_Customs
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"D:\Jonas\Coding\Challanges\Advent of Code\2020\Day 06 - Custom Customs\Day 06 - Input.txt";

            List<string> groups = File.ReadAllText(filePath).Replace("\r\n", " ").Split("  ").ToList();

            string poSt = "abcdefghijklmnopqrstuvwxyz";
            List<char> possibleStatements = new List<char>();
            possibleStatements.AddRange(poSt);

            int sumSomeoneAnswered = 0, sumEveryOneAnswered = 0;

            foreach (string group in groups)
            {
                string someoneAnswered = new String(group.Replace(" ", string.Empty).Distinct().ToArray());
                sumSomeoneAnswered += someoneAnswered.Length;

                List<char> check = possibleStatements;
                check = check.Where(x => group.Count(c => c == x) > group.Count(t => t == ' ')).ToList();
                sumEveryOneAnswered += check.Count;
            }

            Console.WriteLine("Day 06");
            Console.WriteLine("=======");

            Console.Write("Part 1: ");
            Console.WriteLine(sumSomeoneAnswered);
            Console.Write("Part 2: ");
            Console.WriteLine(sumEveryOneAnswered);
        }
    }
}
