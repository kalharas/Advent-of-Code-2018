using System;
using System.Collections.Generic;

public class StepOrderer
{
    public void SortOrder(IList<Instruction> instructions)
    {
        //Define the list
        var links = new LinkedList<char>();
        var instruct = instructions[0];
        links.AddFirst(instruct.current);
        links.AddAfter(links.First, instruct.laterStep);
        for(int i = 1; i < instructions.Count; i++)
        {
            // foreach(char ch in links){
            //     Console.Write(ch + ""); 
            // }
            // Console.WriteLine();
                
            instruct = instructions[i];
            
            var currentNode = links.Find(instruct.current);
            
                if (links.First.Value == instruct.current)
                {
                    var nextNode = links.First.Next;
                    if (nextNode.Value > instruct.laterStep)
                        links.AddBefore(nextNode, instruct.laterStep);
                    else if(nextNode.Value < instruct.laterStep)
                        links.AddAfter(nextNode, instruct.laterStep);
                    else
                        continue;
                }
                else if(currentNode != null)
                {
                    var nodeToFix = links.Find(instruct.laterStep);
                    if(nodeToFix != null)
                        links.Remove(nodeToFix);
                    var nextNode = currentNode.Next;
                    if (nextNode == null)
                    {
                        links.AddLast(instruct.laterStep);
                    }
                    else
                    {

                        if(nextNode.Value > instruct.laterStep)
                            links.AddBefore(nextNode, instruct.laterStep);
                        else if(nextNode.Value < instruct.laterStep)
                            links.AddAfter(nextNode, instruct.laterStep);
                        else
                            continue;
                    }

                }
                else{
                    links.AddLast(instruct.current);
                    links.AddLast(instruct.laterStep);
                }
        }
        foreach(char ch in links) 
            Console.Write(ch + ""); 
        //Chose the start (alphabetically first)
    }
}