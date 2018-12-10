using System;
using System.Collections.Generic;
using Helpers.Extensions;

public static class Polymerizer{
    public static void React(string input)
    {
        ReactNormally(input);
    }


    // private static void Reacting(string input)
    // {
    //     if (count <= 1)
    //     {
    //         return;
    //     }
    //     var a = input[0];
    //     var b = input[1];
    //     if(a.CanReact(b))
    //     {
    //         input = input.Remove(0,2);
    //         Reacting(input, input.Length);
    //     }
    //     else
    //     {
    //         input = input.Substring(1);
    //         Reacting(input, input.Length);
    //     }
    // }

    private static string RemoveReactives(string input)
    {
        var len = input.Length;
        var output = string.Empty;
        if (input[0].CanReact(input[1]))
        {
            output = input.Remove(0, 2);
            return RemoveReactives(output);
        }
        return input;
    }

    private static void ReactNormally(string input)
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
            Console.WriteLine($"{output.Length}");
            return;
        }
        ReactNormally(output);
    }
}