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
            var parsedInput = ParseStringPure(@"Inputs\Day7.txt");
            var orderer = new StepOrderer();
            orderer.PartOne(parsedInput);
            orderer.PartTwo(parsedInput);
        }

        private void RunMethodGroups()
        {
            var frequencies = ParseInputs(@"Inputs\Day1.txt");
            CalibrationManager.PrintSums(frequencies);
            CalibrationManager.CalibrateEveryTwice(frequencies);

            var idList = ParseStrings(@"Inputs\Day2.txt");
            Scanner.ShowCheckSum(idList);
            Scanner.FindAdjescentBox(idList);

            var claimsInputList = ParseStrings(@"Inputs\Day3.txt");
            var claims = ParseFactory.ParseClaims(claimsInputList);
            Tailor.FindOverlaps(claims);

            var parsedShifts = ParseStrings(@"Inputs\Day4.txt");
            var sortedShifts = ParseFactory.ParseShifts(parsedShifts);
            GuardPicker.FindWeakestGuard(sortedShifts);

            var parsedPolymer = ParseString(@"Inputs\Day5.txt");
            var myPolyzer = new Polymerizer();
            myPolyzer.React(parsedPolymer);

            var coords = ParseStrings(@"Inputs\Day6.txt");
            var parsedCoords = ParseFactory.ParseCoordinates(coords);
            var cabber = new Taxicabber();
            cabber.FindTheLargestArea(parsedCoords);
            cabber.FindTheSafeRegion(parsedCoords);
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

        public static string ParseStringPure(string path)
        {
            return File.ReadAllText(path);
        }

        public static string ParseString(string path)
        {
            var inputFile = File.ReadAllText(path);
            return inputFile.ToString();
        }
    }
}
