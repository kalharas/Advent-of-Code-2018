using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AdventCode2018.Puzzles.Day3;

namespace AdventCode2018.Helpers
{
    public static class ParseFactory
    {
        public static List<Claim> ParseClaims(List<string> inputs)
        {
            var claims = new List<Claim>();

            foreach(var input in inputs)
            {
                var claimInput = Regex.Replace(input, "[^0-9]", "-").Trim().Split("-");
                
                var claim = new Claim(int.Parse(claimInput[1]),int.Parse(claimInput[4]),
                    int.Parse(claimInput[5]), int.Parse(claimInput[7]),
                    int.Parse(claimInput[8]));
                    
                claims.Add(claim);
            }
            return claims;
        }

        public static List<Shift> ParseShifts(List<string> inputs)
        {
            List<Shift> shifts = new List<Shift>();
            int id = 0;
            foreach(var input in inputs)
            {
                var shiftTimeString = input.Substring(1, 16);
                var shiftDate = DateTime.Parse(shiftTimeString);
                var info = input.Substring(19);
                var shift = new Shift()
                {
                    shiftTime = shiftDate,
                    info = info,
                    shiftId = id
                };
                shifts.Add(shift);
                id++;
                //var dateRegex = Regex.Match(input, @"\[([^]]+)\]").Groups[1].Value;
                // Console.WriteLine($"{dateRegex}");
            }

            var sortedShifts = shifts.OrderBy(p => p.shiftTime).ToList();
            return sortedShifts;
        }
        public static List<Coordinate> ParseCoordinates(List<string> inputs)
        {
            List<Coordinate> coordinates = new List<Coordinate>();
            var count = 0;
            foreach(var input in inputs)
            {
                var coords = input.Split(',');
                var x = int.Parse(coords[0]);
                var y = int.Parse(coords[1]);
                var newCoord = new Coordinate(x, y, count);
                count++;
                coordinates.Add(newCoord);
            }

            return coordinates;
        }

        public static List<Instruction> ParseInstructions(List<string> inputs)
        {
            var instructions = new List<Instruction>();

            foreach(var input in inputs)
            {
                var texts = input.Split(' ');
                var instruct = new Instruction();
                instruct.current = texts[1][0];
                instruct.laterStep = texts[7][0];
                instructions.Add(instruct);
            }
            return instructions;
        }
    }
}