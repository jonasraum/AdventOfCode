using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_08___Handheld_Halting
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"D:\Jonas\Coding\Challanges\Advent of Code\2020\Day 08 - Handheld Halting\Day 08 - Input.txt";
            List<string[]> lines = File.ReadAllLines(filePath).ToList().Select(x => x.Split(" ")).ToList();

            int accumulator = 0;
            AchieveDetermination(lines, ref accumulator);
            Console.WriteLine("Part 1:");
            Console.WriteLine("Accumulator: " + accumulator);

            bool wrongIndexFound = false;
            int testIndex = 0;
            while (!wrongIndexFound)
            {
                if (lines[testIndex][0] == "nop")
                {
                    lines[testIndex][0] = "jmp";
                }
                else if (lines[testIndex][0] == "jmp")
                {
                    lines[testIndex][0] = "nop";
                }
                wrongIndexFound = AchieveDetermination(lines, ref accumulator);
                testIndex++;

                lines = File.ReadAllLines(filePath).ToList().Select(x => x.Split(" ")).ToList();
            }
            Console.WriteLine("\nPart 2");
            Console.WriteLine("Accumulator: " + accumulator);
        }

        private static bool AchieveDetermination(List<string[]> testLines, ref int accumulator)
        {
            int currentIndex = 0;
            bool[] visitedIndexes = new bool[testLines.Count];

            accumulator = 0;

            while (true)
            {
                if (visitedIndexes[currentIndex] == true)
                {
                    return false;
                }
                else
                {
                    visitedIndexes[currentIndex] = true;
                    switch (testLines[currentIndex][0])
                    {
                        case "acc":
                            if (int.TryParse(testLines[currentIndex][1], out int accNumber))
                            {
                                accumulator += accNumber;
                            }
                            break;
                        case "jmp":
                            if (int.TryParse(testLines[currentIndex][1], out int jmpNumber))
                            {
                                currentIndex += jmpNumber - 1;
                            }
                            break;
                        default:
                            break;
                    }
                    if (currentIndex == testLines.Count - 1)
                    {
                        return true;
                    }
                    currentIndex++;
                }
            }
        }
    }
}
