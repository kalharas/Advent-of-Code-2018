using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventCode2018.Puzzles.Day2
{
    public static class Scanner
    {
        internal static void ShowCheckSum(List<string> idList)
        {
            var twos = 0;
            var threes = 0;
            foreach (var id in idList)
            {
                var characters = id.ToCharArray();
                Dictionary<char, int> dict = new Dictionary<char, int>();
                for(int i = 0; i < characters.Length ; i++)
                {
                    var keyValue = characters[i];
                    if (dict.ContainsKey(keyValue))
                    {
                        var count = dict[keyValue]++;
                    }
                    else {
                        dict.Add(keyValue,1);
                    }
                }
                var a = dict.FirstOrDefault( hitCounts => hitCounts.Value == 2);
                var b = dict.FirstOrDefault( hitCounts => hitCounts.Value == 3);

                if (a.Value != 0)
                {
                    twos++;
                }
                if (b.Value != 0)
                {
                    threes++;
                }
                
            }
            var checksumResult = twos * threes;
            Console.WriteLine($"checksum is {checksumResult}");
        }

        internal static void FindAdjescentBox(List<string> idList)
        {
            var firstMatchIndex = 0;
            var isFirstMatch = false;

            for (int firstIndex = 0; firstIndex < idList.Count; firstIndex++)
            {
                for (int secondIndex = firstIndex + 1; secondIndex < idList.Count; secondIndex++)
                {
                    var aa = idList[firstIndex].ToCharArray();
                    var bb = idList[secondIndex].ToCharArray();
                    var isMatch = 0;
                    
                    for (int i = 0; i < aa.Length; i++)
                    {
                        isMatch = aa[i] ^ bb[i];
                        if (isMatch != 0 && !isFirstMatch)
                        {
                            isFirstMatch = true;
                            firstMatchIndex = i;
                        }
                        else if (isMatch != 0 && isFirstMatch)
                        {
                            isFirstMatch = false;
                            firstMatchIndex = 0;
                            break;
                        }
                    }
                if (isFirstMatch){
                 var commonLetters = idList[firstIndex].Remove(firstMatchIndex, 1);
                Console.WriteLine($"{idList[firstIndex]} has a match, common letters are {commonLetters} character");
                break;
                }
             }
                
            }
           
        }
    }
}