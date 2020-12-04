using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Day_4___Passport_Processing
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"D:\Jonas\Coding\Challanges\AdventOfCode 2020\Day 4 - Passport Processing\Day 4 - Passport Processing\Day 4 - Input.txt";


            string[] lines = File.ReadAllLines(filePath);
            string[] requestedIndex = { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };

            

            Console.WriteLine("Day 04");
            Console.WriteLine("=======");

            //Teil 1

            Console.WriteLine("\nPart 1:");

            bool[] isIncluded = new bool[7];
            int correct = 0;
            int passportNumber = 1;



            for (int i = 0; i <= lines.Length; i++)
            {
                if (i == lines.Length || lines[i] == "")
                {
                    if (Array.TrueForAll(isIncluded, element => element == true))
                    {
                        correct++;
                    }
                    passportNumber++;
                    isIncluded = new bool[7];
                }
                else
                {
                    for (int j = 0; j < requestedIndex.Length; j++)
                    {
                        if (lines[i].Contains(requestedIndex[j]))
                        {
                            isIncluded[j] = true;
                        }
                    }
                }
            }
            Console.WriteLine(correct + " valid passports");

            //Teil 2

            Console.WriteLine("\nPart 2:");

            isIncluded = new bool[7];
            correct = 0;

            Regex byr = new Regex("^[0-9]{4}$");
            Regex iyr = new Regex("^[0-9]{4}$");
            Regex eyr = new Regex("^[0-9]{4}$");
            Regex hgt = new Regex("^[0-9]+");
            Regex hcl = new Regex("^#[0-9a-f]{6}$");
            Regex ecl = new Regex("^amb$|^blu$|^brn$|^gry$|^grn$|^hzl$|^oth$");
            Regex pid = new Regex("^(0+)?[0-9]{9}$");


            for (int i = 0; i <= lines.Length; i++)
            {
                if (i == lines.Length || lines[i] == "")
                {
                    if (Array.TrueForAll(isIncluded, element => element == true))
                    {
                        correct++;
                    }
                    isIncluded = new bool[7];
                }
                else
                {
                    string[] fields = lines[i].Split(" ");
                    foreach (string field in fields)
                    {
                        string[] values = field.Split(":");

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
                }
            }
            Console.WriteLine(correct + " valid passports");
        }

        private static bool CheckValue(Regex reg, string v, bool rangeInput, int min = 0, int max = 0)
        {
            if (rangeInput)
            {
                if (reg.IsMatch(v) && Convert.ToInt32(v) >= min && Convert.ToInt32(v) <= max)
                {
                    return true;
                }
            }
            else if (reg.IsMatch(v))
            {
                return true;
            }
            return false;
        }
    }
}