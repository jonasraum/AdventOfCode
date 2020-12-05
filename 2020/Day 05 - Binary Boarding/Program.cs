using System;
using System.IO;

namespace Day_05___Binary_Boarding
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"D:\Jonas\Coding\Challanges\Advent of Code\2020\Day 05 - Binary Boarding\Day 05 - Input.txt";
            string[] seats = File.ReadAllLines(filePath);
            int maxSeatID = 0;


            Console.WriteLine("Day 05");
            Console.WriteLine("=======");

            Console.WriteLine("\nPart 1:\n");

            foreach (string seat in seats)
            {
                string row = seat.Substring(0, seat.Length - 3);
                string column = seat.Substring(seat.Length - 3);

                row = row.Replace('B', '1');
                row = row.Replace('F', '0');
                column = column.Replace('R', '1');
                column = column.Replace('L', '0');

                int rowNumber = Convert.ToInt32(row, 2);
                int columnNumber = Convert.ToInt32(column, 2);
                int seatID = rowNumber * 8 + columnNumber;

                Console.WriteLine($"{seat}: row {rowNumber}, column {columnNumber}, seat ID {seatID}");

                if (seatID > maxSeatID)
                {
                    maxSeatID = seatID;
                }
            }

            Console.WriteLine("\nHighest Seat ID: " + maxSeatID);
        }
    }
}
