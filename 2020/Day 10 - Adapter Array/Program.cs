using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_10___Adapter_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"D:\Jonas\Coding\Challanges\Advent of Code\2020\Day 10 - Adapter Array\Day 10 - Input.txt";
            List<int> numbers = File.ReadAllLines(filePath).ToList().Select(x => Convert.ToInt32(x)).ToList();
            numbers.Add(0);
            numbers.Sort();

            CountReferences(numbers);

            CalculatePoissibilities(numbers);
        }

        private static void CountReferences(List<int> numbers)
        {
            int builtInJoltage = numbers[numbers.Count - 1] + 3;

            int sumOneJoltDifferences = 0, sumThreeJoltDifferences = 1;

            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i] - numbers[i - 1] == 1)
                {
                    sumOneJoltDifferences++;
                }
                else if (numbers[i] - numbers[i - 1] == 3)
                {
                    sumThreeJoltDifferences++;
                }
            }

            Console.WriteLine("Part 1:");
            Console.WriteLine("Number of 1-jolt differences: " + sumOneJoltDifferences);
            Console.WriteLine("Number of 3-jolt differences: " + sumThreeJoltDifferences);
            Console.WriteLine("Multiplied: " + (sumOneJoltDifferences * sumThreeJoltDifferences));
        }

        static void CalculatePoissibilities(List<int> numbers)
        {
            decimal distinctWays = 0;
            int counter;
            decimal[] previousPaths = new decimal[3];

            for (int i = 0; i < numbers.Count; i++)
            {
                counter = 0;
                distinctWays = 0;

                for (int j = 1; j <= 3; j++)
                {
                    if (numbers.Contains(numbers[i] - j))
                    {
                        counter++;
                    }
                }

                for (int j = 0; j < counter; j++)
                {
                    distinctWays += previousPaths[j];
                }

                if (distinctWays==0)
                {
                    distinctWays++;
                }

                previousPaths[2] = previousPaths[1];
                previousPaths[1] = previousPaths[0];
                previousPaths[0] = distinctWays;
            }

            Console.WriteLine("\nPart 2:");
            Console.WriteLine("Total distinct ways: " + distinctWays);
        }
    }
}
