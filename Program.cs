using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventCode2018.Puzzles.Day1;
using AdventCode2018.Puzzles.Day2;

namespace AdventCode2018
{
    class Program
    {
        static void Main(string[] args)
        {
           Console.WriteLine("Which puzzle to solve:");
           Console.WriteLine("1- Day 1");
           Console.WriteLine("2- Day 2");
           var a = Console.ReadLine();
           List<int> frequencies;
           List<string> idList;
           if(int.TryParse(a, out int selection))
           {
               switch(selection)
               {
                   case 1:
                   frequencies = ParseInputs(@"Inputs\Day1input.txt");
                   CalibrationManager.PrintSums(frequencies);
                   CalibrationManager.CalibrateEveryTwice(frequencies);
                   break;
                   case 2:
                   idList = ParseStrings(@"Inputs\Day2input.txt");
                   Scanner.ShowCheckSum(idList);
                   Scanner.FindAdjescentBox(idList);
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

        public static List<string> ParseStrings(string path)
        {
            var inputFile = File.ReadAllLines(path).ToList<string>();
            return inputFile;
        }
    }
}
