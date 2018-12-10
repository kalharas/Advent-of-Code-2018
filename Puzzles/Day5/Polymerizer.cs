using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Helpers.Extensions;

public class Polymerizer{
    public void React(string input)
    {
        var alphabet = "abcdefghijklmnopqrstuvwxyz";
        var maxReactive = int.MaxValue;
        CultureInfo culture = CultureInfo.CurrentCulture;

        foreach(var character in alphabet) 
        {
            var newInput = input.Replace(character.ToString(), "", true, culture);
            var result = ReactNormally(newInput);
            if (result <= maxReactive)
            {
                maxReactive = result;
            }
        };
        Console.WriteLine($"{maxReactive}");
    }

    public void ReactPart2(string input)
    {
        var result = ReactNormally(input);
        Console.WriteLine($"{result}");
    }

    private int ReactNormally(string input)
    {
        var output = string.Empty;
        var copyInput = input;
        var skipNext = false;
        var indexesToRemove = new List<int>();
        var len = input.Length;

        for (int i  = 0; i < len; i++)
        {
            if (i + 1 == input.Length)
                {
                    output += copyInput[i];
                    break;
                }
            if (input[i].CanReact(input[i+1]) && !skipNext)
            {
                indexesToRemove.Add(i);
                skipNext = true;
            }
            else if(!skipNext){
                output += copyInput[i];                
            }
            else{
                skipNext = false;
            }
        }

        if (output.Length == input.Length)
        {
            return output.Length;
        }
        return ReactNormally(output);
    }
}