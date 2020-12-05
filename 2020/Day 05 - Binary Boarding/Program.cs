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
            int[] seatIDs = new int[seats.Length];
            int maxSeatID = 0;
            int currentSeat = 0;

            Console.WriteLine("Day 05");
            Console.WriteLine("=======");

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

                seatIDs[currentSeat] = seatID;
                currentSeat++;
            }

            Array.Sort(seatIDs);
            int mySeatID = 0;

            for (int i = 1; i < seatIDs.Length - 1; i++)
            {
                if (seatIDs[i] == seatIDs[i-1] + 2)
                {
                    mySeatID = seatIDs[i] - 1;
                }
            }

            Console.WriteLine("\nPart 1:");
            Console.WriteLine("Highest seat ID: " + maxSeatID);

            Console.WriteLine("\nPart 2:");
            Console.WriteLine("My seat ID: " + mySeatID);
        }
    }
}
