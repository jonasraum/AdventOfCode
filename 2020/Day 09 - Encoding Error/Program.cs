using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_09___Encoding_Error
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"D:\Jonas\Coding\Challanges\Advent of Code\2020\Day 09 - Encoding Error\Day 09 - Input.txt";
            List<decimal> numbers = File.ReadAllLines(filePath).ToList().Select(x => Convert.ToDecimal(x)).ToList();
            bool numberFound = true;
            int currentIndex = 24;

            while (numberFound)
            {
                currentIndex++;
                numberFound = SearchSummands(currentIndex, numbers);
            }

            Console.WriteLine("Part 1:");
            Console.WriteLine("First number without the property: " + numbers[currentIndex]);

            decimal searchedNumber = numbers[currentIndex];
            bool rangeFound = false;
            int lPointer = 0;
            int rPointer = 1;

            while (!rangeFound)
            {
                rangeFound = CheckRange(numbers, ref lPointer, ref rPointer, searchedNumber);
            }

            List<decimal> range = numbers.GetRange(lPointer, rPointer - lPointer + 1);
            range.Sort();

            Console.WriteLine("\nPart 2:");
            Console.WriteLine("Start of range: " + range[0]);
            Console.WriteLine("End of range: " + range[range.Count-1]);
            Console.WriteLine("Sum: " + (range[0] + range[range.Count - 1]));
        }

        private static bool CheckRange(List<decimal> numbers, ref int lPointer, ref int rPointer, decimal searchedNumber)
        {
            decimal sum = numbers[lPointer] + numbers[rPointer];
            
            while (rPointer < numbers.Count)
            {
                if (sum == searchedNumber)
                {
                    return true;
                }
                else if(sum <= searchedNumber)
                {
                    rPointer++;
                    sum += numbers[rPointer];
                }
                else
                {
                    lPointer++;
                    rPointer = lPointer + 1;
                    return false;
                }
            }
            return false;
        }

        static bool SearchSummands(int currentIndex, List<decimal> numbers)
        {
            List<decimal> previousNumbers = numbers.GetRange(currentIndex - 25, 25);
            previousNumbers.Sort();
            int lPointer = 0;
            int rPointer = 24;
            while (lPointer < rPointer)
            {
                if (previousNumbers[lPointer] + previousNumbers[rPointer] == numbers[currentIndex])
                {
                    return true;
                }
                else if (previousNumbers[lPointer] + previousNumbers[rPointer] < numbers[currentIndex])
                {
                    lPointer++;
                }
                else
                {
                    rPointer--;
                }
            }
            return false;
        }
    }
}
