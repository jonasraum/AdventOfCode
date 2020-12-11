using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace Day_11___Seating_System
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"D:\Jonas\Coding\Challanges\Advent of Code\2020\Day 11 - Seating System\Day 11 - Input.txt";
            string[] lines = File.ReadAllLines(filePath);
            (char identifier, bool isChanged)[,] seats = new (char, bool)[lines.Length, lines[0].Length];

            //Part 1
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    seats[i, j] = (lines[i][j], false);
                }
            }

            CalculateSeats(true, seats);

            //Part 2
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    seats[i, j] = (lines[i][j], false);
                }
            }

            CalculateSeats(false, seats);
        }

        private static void CalculateSeats(bool part1, (char identifier, bool isChanged)[,] seats)
        {
            (char identifier, bool isChanged)[,] seatsReference = ((char, bool)[,])seats.Clone();

            do
            {
                seatsReference = ((char, bool)[,])seats.Clone();

                for (int i = 0; i < seats.GetLength(0); i++)
                {
                    for (int j = 0; j < seats.GetLength(1); j++)
                    {
                        CheckSpace(seats, i, j, (part1?true:false));
                    }
                }

                for (int i = 0; i < seats.GetLength(0); i++)
                {
                    for (int j = 0; j < seats.GetLength(1); j++)
                    {
                        if (seats[i, j].isChanged == true)
                        {
                            ChangeSpace(ref seats[i, j]);
                        }
                    }
                }
            } while (!(seats.Cast<(char, bool)>().SequenceEqual(seatsReference.Cast<(char, bool)>())));

            Console.WriteLine(CountOccupiedSeats(seats));
        }

        private static int CountOccupiedSeats((char identifier, bool isChanged)[,] seats)
        {
            int counter = 0;
            for (int i = 0; i < seats.GetLength(0); i++)
            {
                for (int j = 0; j < seats.GetLength(1); j++)
                {
                    if (seats[i, j].identifier == '#')
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }

        private static void ChangeSpace(ref (char identifier, bool isChanged) space)
        {
            if (space.identifier == '#')
            {
                space.identifier = 'L';
            }
            else
            {
                space.identifier = '#';
            }
            space.isChanged = false;
        }

        private static void CheckSpace((char identifier, bool isChanged)[,] seats, int i, int j, bool part1)
        {
            if (seats[i, j].identifier != '.')
            {
                if (SpaceChanges(seats, i, j, seats[i, j].identifier, (part1 ? true : false)))
                {
                    seats[i, j].isChanged = true;
                }
            }
            else
            {
                seats[i, j].isChanged = false;
            }
        }

        private static bool SpaceChanges((char identifier, bool isChanged)[,] seats, int currentRow, int currentColumn, char identifier, bool part1)
        {

            int counter = 0;
            for (int k = (currentRow == 0 ? currentRow : currentRow - 1); k < (currentRow == seats.GetLength(0) - 1 ? currentRow + 1 : currentRow + 2); k++)
            {
                for (int l = (currentColumn == 0 ? currentColumn : currentColumn - 1); l < (currentColumn == seats.GetLength(1) - 1 ? currentColumn + 1 : currentColumn + 2); l++)
                {
                    if (seats[k, l].identifier == '#')
                    {
                        counter++;
                    }
                    else if (seats[k, l].identifier == '.' && part1 == false)
                    {
                        int columnDirection = k - currentRow;
                        int rowDirection = l - currentColumn;
                        int kTemp = k;
                        int lTemp = l;

                        while ((kTemp >= 0 && kTemp < seats.GetLength(0) && lTemp >= 0 && lTemp < seats.GetLength(1)) && seats[kTemp, lTemp].identifier == '.')
                        {
                            kTemp += columnDirection;
                            lTemp += rowDirection;
                        }

                        if (!(kTemp >= 0 && kTemp < seats.GetLength(0)) || !(lTemp >= 0 && lTemp < seats.GetLength(1)))
                        {
                            kTemp -= columnDirection;
                            lTemp -= rowDirection;
                        }

                        if (seats[kTemp, lTemp].identifier == '#')
                        {
                            counter++;
                        }
                    }
                }
            }

            if ((identifier == 'L' && counter < 1) || (identifier == '#' && counter > (part1 ? 4 : 5)))
            {
                return true;
            }
            return false;
        }
    }
}
