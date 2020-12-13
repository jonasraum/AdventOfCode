using System;
using System.IO;

namespace Day_12___Rain_Risk
{
    enum Direction
    {
        North, East, South, West
    }
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"D:\Jonas\Coding\Challanges\Advent of Code\2020\Day 12 - Rain Risk\Day 12 - Input.txt";
            string[] lines = File.ReadAllLines(filePath);

            Console.WriteLine("Part1:");
            CalculateManhattanDistance(lines, true);

            Console.WriteLine("\nPart2:");
            CalculateManhattanDistance(lines, false);
        }

        static void CalculateManhattanDistance(string[] lines, bool part1)
        {
            int east = 0;
            int north = 0;
            (int north, int east) wavepoint = (1, 10);
            Direction currentDirection = Direction.East;

            foreach (string line in lines)
            {
                int value = 0;
                string operation = line.Substring(0, 1);
                bool valid = int.TryParse(line.Substring(1), out int _value);
                if (valid)
                {
                    value = _value;
                }
                if (part1)
                {
                    ExecuteOperationPart1(operation, value, ref east, ref north, ref currentDirection);
                }
                else
                {
                    ExecuteOperationPart2(operation, value, ref east, ref north, ref wavepoint);
                }
            }

            
            Console.WriteLine("North: " + Math.Abs(north) + "; East: " + Math.Abs(east));
            Console.WriteLine("Manhatten Distance: " + (Math.Abs(north) + Math.Abs(east)));
        }

        private static void ExecuteOperationPart1(string operation, int value, ref int east, ref int north, ref Direction currentDirection)
        {
            switch (operation)
            {
                case "N":
                    north += value;
                    break;
                case "S":
                    north -= value;
                    break;
                case "E":
                    east += value;
                    break;
                case "W":
                    east -= value;
                    break;
                case "L":
                    int cDirec = (int)currentDirection;
                    cDirec = (cDirec - value / 90);
                    if (cDirec < 0)
                    {
                        cDirec += 4;
                    }
                    currentDirection = (Direction)(cDirec);
                    break;
                case "R":
                    cDirec = (int)currentDirection;
                    cDirec = (cDirec + value / 90) % 4;
                    currentDirection = (Direction)(cDirec);
                    break;
                case "F":
                    switch (currentDirection)
                    {
                        case Direction.North:
                            north += value;
                            break;
                        case Direction.East:
                            east += value;
                            break;
                        case Direction.South:
                            north -= value;
                            break;
                        case Direction.West:
                            east -= value;
                            break;
                        default:
                            break;
                    }
                    break;
            }
        }

        private static void ExecuteOperationPart2(string operation, int value, ref int east, ref int north, ref (int north, int east) wavepoint)
        {
            switch (operation)
            {
                case "N":
                    wavepoint.north += value;
                    break;
                case "S":
                    wavepoint.north -= value;
                    break;
                case "E":
                    wavepoint.east += value;
                    break;
                case "W":
                    wavepoint.east -= value;
                    break;
                case "L":
                    for (int i = 0; i < value/90; i++)
                    {
                        int buffer = wavepoint.north;
                        wavepoint.north = wavepoint.east;
                        wavepoint.east = -(buffer);
                    }
                    break;
                case "R":
                    for (int i = 0; i < value/90; i++)
                    {
                        int buffer = wavepoint.north;
                        wavepoint.north = -(wavepoint.east);
                        wavepoint.east = buffer;
                    }
                    break;
                case "F":
                    north += wavepoint.north * value;
                    east += wavepoint.east * value;
                    break;
            }
        }
    }
}
