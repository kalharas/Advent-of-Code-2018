using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventCode2018.Puzzles.Day3
{
    public static class Tailor
    {
        public static void FindOverlaps(List<Claim> claims)
        {
            Dictionary<int, bool> singledOutId = new Dictionary<int, bool>();
            int[,,] fabric = new int[1000, 1000, 2];
            foreach (var claimedFabric in claims)
            {
                singledOutId.Add(claimedFabric.id, true);
                for (int i = claimedFabric.StartX; i < claimedFabric.EndX; i++)
                {
                    for (int j = claimedFabric.StartY; j < claimedFabric.EndY; j++)
                    {
                        var hitCount = fabric[i, j, 0];
                        hitCount++;
                        fabric[i, j, 0] = hitCount;
                        if (hitCount == 1)
                        {
                            fabric[i, j, 1] = claimedFabric.id;
                        }
                        if (hitCount >= 2)
                        {
                            //get the prev claim Id
                            var prevClaimId = fabric[i, j, 1];
                            fabric[i, j, 1] = claimedFabric.id;
                            singledOutId[prevClaimId] = false;
                            singledOutId[claimedFabric.id] = false;
                        }
                    }
                }
            }
            var count = 0;
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    if (fabric[i, j, 0] >= 2)
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine($"{count} square inches of fabric are within two or more claims");

            var singledOutIdClaim = (from claimsDict in singledOutId
                                     where claimsDict.Value == true
                                     select claimsDict.Key).FirstOrDefault();
            Console.WriteLine($"Claim with Id {singledOutIdClaim} doesn't overlap");
        }
    }
}