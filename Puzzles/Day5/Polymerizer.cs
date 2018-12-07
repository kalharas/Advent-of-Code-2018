using System;
using System.Collections.Generic;
using Helpers.Extensions;

public static class Polymerizer{
    public static void React(string input)
    {
        ReactNormally(input);
    }

    private static void Reacting(string input, int count)
    {
        if (count <= 1)
        {
            return;
        }
        var a = input[0];
        var b = input[1];
        if(a.CanReact(b))
        {
            input = input.Remove(0,2);
            Reacting(input, input.Length);
        }
        else
        {
            input = input.Substring(1);
            Reacting(input, input.Length);
        }
    }

    private static void ReactNormally(string input)
    {
        var output = string.Empty;
        var copyInput = input;
        var skipNext = false;
        var indexesToRemove = new List<int>();

        for (int i  = 0; i < input.Length; i++)
        {
            if (i + 1 == input.Length)
                break;
            if (input[i].CanReact(input[i+1]))
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
{            Console.WriteLine($"{output.Length}");
    return;
}

        ReactNormally(output);
    }
}