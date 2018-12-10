using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventCode2018.Puzzles.Day1;
using AdventCode2018.Puzzles.Day2;
using AdventCode2018.Helpers;
using AdventCode2018.Puzzles.Day3;
using System.Threading.Tasks;

namespace AdventCode2018
{
    class Program
    {
        public static void Main(string[] args)
        {
           var parsedPolymer = ParseString(@"Inputs\Day5input.txt");
           var myPolyzer = new Polymerizer();
           myPolyzer.React(parsedPolymer);
        }

        private void RunMethodGroups()
        {
            var frequencies = ParseInputs(@"Inputs\Day1input.txt");
            CalibrationManager.PrintSums(frequencies);
            CalibrationManager.CalibrateEveryTwice(frequencies);

            var idList = ParseStrings(@"Inputs\Day2input.txt");
            Scanner.ShowCheckSum(idList);
            Scanner.FindAdjescentBox(idList);

            var claimsInputList = ParseStrings(@"Inputs\Day3input.txt");
            var claims = ParseFactory.ParseClaims(claimsInputList);
            Tailor.FindOverlaps(claims);

            var parsedShifts = ParseStrings(@"Inputs\Day4input.txt");
            var sortedShifts = ParseFactory.ParseShifts(parsedShifts);
            GuardPicker.FindWeakestGuard(sortedShifts);

            var parsedPolymer = ParseString(@"Inputs\Day5input.txt");
            var myPolyzer = new Polymerizer();
            myPolyzer.React(parsedPolymer);
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
