﻿using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Day_4___Passport_Processing
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"D:\Jonas\Coding\Challanges\Advent of Code\2020\Day 04 - Passport Processing\Day 04 - Input.txt";

            string allLines = File.ReadAllText(filePath);
            allLines = allLines.Replace("\r\n", " ");
            string[] passports = allLines.Split("  ");
            string[] requestedIndex = { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };

            Console.WriteLine("Day 04");
            Console.WriteLine("=======");

            #region Part 1

            Console.WriteLine("\nPart 1:");

            bool[] isIncluded = new bool[7];
            int correct = 0;

            for (int i = 0; i < passports.Length; i++)
            {
                for (int j = 0; j < requestedIndex.Length; j++)
                {
                    if (passports[i].Contains(requestedIndex[j]))
                    {
                        isIncluded[j] = true;
                    }
                }
                if (Array.TrueForAll(isIncluded, element => element == true))
                {
                    correct++;
                }
                isIncluded = new bool[7];
            }

            Console.WriteLine(correct + " valid passports");

            #endregion

            #region Part 2

            Console.WriteLine("\nPart 2:");

            isIncluded = new bool[7];
            correct = 0;

            //defines the requested syntax of the passport values
            Regex byr = new Regex("^[0-9]{4}$");
            Regex iyr = new Regex("^[0-9]{4}$");
            Regex eyr = new Regex("^[0-9]{4}$");
            Regex hgt = new Regex("^[0-9]+");
            Regex hcl = new Regex("^#[0-9a-f]{6}$");
            Regex ecl = new Regex("^amb$|^blu$|^brn$|^gry$|^grn$|^hzl$|^oth$");
            Regex pid = new Regex("^(0+)?[0-9]{9}$");

            for (int i = 0; i < passports.Length; i++)
            {
                string[] fields = passports[i].Split(" ");
                foreach (string field in fields)
                {
                    string[] values = field.Split(":");

                    //looks at the identifier of the current field
                    switch (values[0])
                    {
                        case "byr":
                            isIncluded[0] = CheckValue(byr, values[1], true, 1920, 2002);
                            break;
                        case "iyr":
                            isIncluded[1] = CheckValue(iyr, values[1], true, 2010, 2020);
                            break;
                        case "eyr":
                            isIncluded[2] = CheckValue(eyr, values[1], true, 2020, 2030);
                            break;
                        case "hgt":
                            if (values[1].Substring(values[1].Length - 2) == "in")
                            {
                                isIncluded[3] = CheckValue(hgt, values[1].Substring(0, values[1].Length - 2), true, 59, 76);
                            }
                            else if (values[1].Substring(values[1].Length - 2) == "cm")
                            {
                                isIncluded[3] = CheckValue(hgt, values[1].Substring(0, values[1].Length - 2), true, 150, 193);
                            }
                            break;
                        case "hcl":
                            isIncluded[4] = CheckValue(hcl, values[1], false);
                            break;
                        case "ecl":
                            isIncluded[5] = CheckValue(ecl, values[1], false);
                            break;
                        case "pid":
                            isIncluded[6] = CheckValue(pid, values[1], false);
                            break;
                    }
                }

                if (Array.TrueForAll(isIncluded, element => element == true))
                {
                    correct++;
                }
                isIncluded = new bool[7];
            }

            Console.WriteLine(correct + " valid passports");

            #endregion
        }

        /// <summary>
        /// indicates if the value is acceptable
        /// </summary>
        /// <param name="reg">the regular expression how the value should be formatted</param>
        /// <param name="value">the value that should be verified</param>
        /// <param name="rangeInput">indicates if the function has to examine a range or if the value just has to adhere to the regex</param>
        /// <param name="min">minimum of the range</param>
        /// <param name="max">maximum of the range</param>
        /// <returns></returns>
        private static bool CheckValue(Regex reg, string value, bool rangeInput, int min = 0, int max = 0)
        {
            if (rangeInput)
            {
                if (reg.IsMatch(value) && Convert.ToInt32(value) >= min && Convert.ToInt32(value) <= max)
                {
                    return true;
                }
            }
            else if (reg.IsMatch(value))
            {
                return true;
            }
            return false;
        }
    }
}