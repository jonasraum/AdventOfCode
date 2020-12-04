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
            int leftPointer, rightPointer;

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

            #region Part 1

            Console.WriteLine("\nPart 1:\n");

            Array.Sort(input);

            leftPointer = 0;
            rightPointer = input.Length - 1;

            while (leftPointer < rightPointer)
            {
                if (input[leftPointer] + input[rightPointer] == 2020)
                {
                    Console.WriteLine("Number 1: " + input[leftPointer]);
                    Console.WriteLine("Number 2: " + input[rightPointer]);
                    Console.WriteLine("Result: " + input[leftPointer] * input[rightPointer]);
                    break;
                }
                else if (input[leftPointer] + input[rightPointer] < 2020)
                {
                    leftPointer++;
                }
                else
                {
                    rightPointer--;
                }
            }

            #endregion

            #region Part 2

            Console.WriteLine("\nPart 2:\n");
            
            for (int i = 0; i < input.Length - 2; i++)
            {
                leftPointer = i + 1;
                rightPointer = input.Length - 1;

                while (leftPointer < rightPointer)
                {
                    if (input[i] + input[leftPointer] + input[rightPointer] == 2020)
                    {
                        Console.WriteLine("Number 1: " + input[i]);
                        Console.WriteLine("Number 2: " + input[leftPointer]);
                        Console.WriteLine("Number 3: " + input[rightPointer]);
                        Console.WriteLine("Result: " + input[i] * input[leftPointer] * input[rightPointer]);
                        break;
                    }
                    else if(input[i] + input[leftPointer] + input[rightPointer] < 2020)
                    {
                        leftPointer++;
                    }
                    else
                    {
                        rightPointer--;
                    }
                }
            }

            #endregion
        }
    }
}
