using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_13___Shuttle_Search
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"D:\Jonas\Coding\Challanges\Advent of Code\2020\Day 13 - Shuttle Search\Day 13 - Input.txt";
            int arriveTime = Convert.ToInt32(File.ReadLines(filePath).First());
            string[] shuttles = File.ReadLines(filePath).Skip(1).First().Replace("x,", string.Empty).Split(",");
            List<int> shuttleIDs = shuttles.Select(x => Convert.ToInt32(x)).ToList();
            int minWaitTime = shuttleIDs.Max();
            int nextShuttle = 0;

            foreach (int shuttleID in shuttleIDs)
            {
                int currentWaitTime = shuttleID - arriveTime % shuttleID;
                if (currentWaitTime < minWaitTime)
                {
                    minWaitTime = currentWaitTime;
                    nextShuttle = shuttleID;
                }
            }

            Console.WriteLine("Part 1:");
            Console.WriteLine(minWaitTime * nextShuttle);

            //Solution for Part 2 is working for every test case, but is too slow for the actual imput.
            //Updated solution with the Chinese Remainder Theorem coming soon!

            List<string> allShuttleIDs = File.ReadLines(filePath).Skip(1).First().Split(",").ToList();

            decimal i = 0;
            int j = 0;
            bool sequenceFound = true;
            while (true)
            {
                while(j < allShuttleIDs.Count && sequenceFound)
                { 
                    if (allShuttleIDs[j] != "x" && (Convert.ToInt32(allShuttleIDs[j]) - i % Convert.ToInt32(allShuttleIDs[j])) % Convert.ToInt32(allShuttleIDs[j]) != j)
                    {
                        sequenceFound = false;
                    }
                    j++;
                }

                if (sequenceFound)
                {
                    Console.WriteLine("\nPart 2:");
                    Console.WriteLine(i);
                    break;
                }
                else
                {
                    i++;
                    j = 0;
                    sequenceFound = true;
                }
            }
        }
    }
}
