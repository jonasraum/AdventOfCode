using System;
using System.IO;

namespace Day_2___Password_Philosophy
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"D:\Jonas\Coding\Challanges\Advent of Code\2020\Day 02 - Password Philosophy\Day 02 - Input.txt";
            int correct = 0;
            string[] passwords = File.ReadAllLines(filePath);

            Console.WriteLine("Day 02");
            Console.WriteLine("=======");

            //Part 1

            foreach (string s in passwords)
            {
                int counter = 0;
                string[] parts = s.Split(" "); //creates an array containing the different arguments
                string[] range = parts[0].Split("-"); //creates an array containing the minimum and maximum allowed occurence of the char
                char regulatedChar = (parts[1])[0];

                //checks how often the string contains the char
                for (int i = 0; i < parts[2].Length; i++)
                {
                    if ((parts[2])[i] == regulatedChar)
                    {
                        counter++;
                    }
                }

                //checks if the quantity complies to the regulations
                if (Convert.ToInt32(range[0]) <= counter && counter <= Convert.ToInt32(range[1]))
                {
                    correct++;
                }
            }

            Console.WriteLine("\nPart 1:");
            Console.WriteLine(correct);

            //Part 2

            correct = 0;

            foreach (string s in passwords)
            {
                bool a = false, b = false;
                string[] parts = s.Split(" "); //creates an array containing the different arguments
                string[] stringPositions = parts[0].Split("-"); //creates an array containing the minimum and maximum allowed occurence of the char
                char regulatedChar = (parts[1])[0];

                //checks if the char occures at the first given position
                if ((parts[2])[Convert.ToInt32(stringPositions[0]) - 1] == regulatedChar)
                {
                    a = true;
                }

                //checks if the char occures at the second given position
                if ((parts[2])[Convert.ToInt32(stringPositions[1]) - 1] == regulatedChar)
                {
                    b = true;
                }

                //checks if the char only occures on one position
                if (a != b)
                {
                    correct++;
                }
            }

            Console.WriteLine("\nPart 2:");
            Console.WriteLine(correct);

            Console.ReadLine();
        }
    }
}
