using System;
using System.IO;

namespace Day_1___Report_Repair
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"D:\Jonas\Coding\Challanges\Advent of Code\2020\Day 01 - Report Repair\Day 01 - Input.txt";
            string[] inputString = File.ReadAllLines(filePath);
            int[] input = new int[inputString.Length];
            bool isNumber = false;

            for (int i = 0; i < inputString.Length; i++)
            {
                isNumber = int.TryParse(inputString[i], out int number);
                if (isNumber)
                {
                    input[i] = number;
                }
            }

            Console.WriteLine("Day 01");
            Console.WriteLine("=======");

            //Part 1

            Console.WriteLine("\nPart 1:\n");

            int firstNumber;
            int secondNumber;

            for (int i = 0; i < input.Length; i++)
            {
                firstNumber = input[i];
                for (int j = i + 1; j < input.Length; j++)
                {
                    if (firstNumber + input[j] == 2020)
                    {
                        secondNumber = input[j];
                        Console.WriteLine("Number 1: " + firstNumber);
                        Console.WriteLine("Number 2: " + secondNumber);
                        Console.WriteLine("Result: " + firstNumber * secondNumber);
                    }
                }
            }

            //Part 2

            Console.WriteLine("\nPart 2:\n");

            Array.Sort(input);

            int l, r;
            for (int i = 0; i < input.Length - 2; i++)
            {
                l = i + 1;
                r = input.Length - 1;

                while (l < r)
                {
                    if (input[i] + input[l] + input[r] == 2020)
                    {
                        Console.WriteLine("Number 1: " + input[i]);
                        Console.WriteLine("Number 2: " + input[l]);
                        Console.WriteLine("Number 3: " + input[r]);
                        Console.WriteLine("Result: " + input[i] * input[l] * input[r]);
                        break;
                    }
                    else if(input[i] + input[l] + input[r] < 2020)
                    {
                        l++;
                    }
                    else
                    {
                        r--;
                    }
                }
            }
        }
    }
}
