using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventCode2018.Puzzles.Day1;
using AdventCode2018.Puzzles.Day2;
using AdventCode2018.Helpers;
using AdventCode2018.Puzzles.Day3;

namespace AdventCode2018
{
    class Program
    {
        static void Main(string[] args)
        {
           var parsedPolymer = ParseString(@"Inputs\Day5input.txt");
           Polymerizer.React(parsedPolymer);
        }

        private void RunMethodGroups()
        {
            Console.WriteLine("Which puzzle to solve:");
           Console.WriteLine("1- Day 1");
           Console.WriteLine("2- Day 2");
           Console.WriteLine("3- Day 3");
           Console.WriteLine("4- Day 4");
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
                   case 3:
                   var claimsInputList = ParseStrings(@"Inputs\Day3input.txt");
                   var claims = ParseFactory.ParseClaims(claimsInputList);
                   Tailor.FindOverlaps(claims);
                   break;
                   case 4:
                   var parsedShifts = ParseStrings(@"Inputs\Day4input.txt");
                   var sortedShifts = ParseFactory.ParseShifts(parsedShifts);
                   GuardPicker.FindWeakestGuard(sortedShifts);
                   break;
                   case 5:
                   var parsedPolymer = ParseString(@"Inputs\Day5input.txt");
                   Polymerizer.React(parsedPolymer);
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

        public static string ParseString(string path)
        {
            var inputFile = File.ReadAllText(path);
            return inputFile.ToString();
        }
    }
}
