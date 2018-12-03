using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventCode2018.Day1;

namespace AdventCode2018
{
    class Program
    {
        static void Main(string[] args)
        {
           Console.WriteLine("Which puzzle to solve:");
           Console.WriteLine("1- Day 1 Part 1");
           Console.WriteLine("2- Day 2 Part 2");
           var a = Console.ReadLine();
           List<int> frequencies;
           if(int.TryParse(a, out int selection))
           {
               switch(selection)
               {
                   case 1:
                   frequencies = ParseInputs(@"Inputs\Day1_q1.txt");
                   CalibrationManager.PrintSums(frequencies);
                   break;
                   case 2:
                   frequencies = ParseInputs(@"Inputs\Day1_q2.txt");
                   CalibrationManager.CalibrateEveryTwice(frequencies);
                   break;
                   default:
                   break;
               }
           }
        }

        public static List<int> ParseInputs(string path)
        {
            var inputFile = File.ReadAllLines(path).ToList<string>();
            return inputFile.Select(input => int.Parse(input)).ToList();
        }
    }
}
