using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using AdventCode2018.Puzzles.Day3;

namespace AdventCode2018.Helpers
{
    public static class ClaimFactory
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
    }
}