using System;
using System.IO;

namespace Day_3___Toboggan_Trajectory
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"D:\Jonas\Coding\Challanges\Advent of Code\2020\Day 03 - Toboggan Trajectory\Day 03 - Input.txt";
            
            string[] forrest = File.ReadAllLines(filePath);

            Console.WriteLine("Day 03");
            Console.WriteLine("=======");

            Console.WriteLine("\nPart 1:\n");

            CheckTrees(forrest, 1, 3);

            Console.WriteLine();

            Console.WriteLine("\nPart 2:\n");

            uint totalTrees = 1;

            totalTrees *= Convert.ToUInt32(CheckTrees(forrest, 1, 1));
            totalTrees *= Convert.ToUInt32(CheckTrees(forrest, 1, 3));
            totalTrees *= Convert.ToUInt32(CheckTrees(forrest, 1, 5));
            totalTrees *= Convert.ToUInt32(CheckTrees(forrest, 1, 7));
            totalTrees *= Convert.ToUInt32(CheckTrees(forrest, 2, 1));

            Console.WriteLine("\nTrees multiplied: " + totalTrees);

            static int CheckTrees(string[] forrest, int x, int y)
            {
                int trees = 0;
                for (int i = 0; i < forrest.Length; i += x)
                {
                    if ((forrest[i])[(i/x * y) % forrest[i].Length] == '#')
                    {
                        trees++;
                    }
                }
                Console.Write($"{x} right, {y} down: ");
                Console.WriteLine(trees + " trees");
                return trees;
            }
        }
    }
}
