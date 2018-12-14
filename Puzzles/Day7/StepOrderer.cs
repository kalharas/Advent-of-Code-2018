using System;
using System.Collections.Generic;
using System.Linq;
using Helpers.Extensions;

public class StepOrderer
{
    public void SortOrder(IList<Instruction> instructions)
    {
        var sets = new HashSet<char>();
        var dependencies = new HashSet<Tuple<char, char>>();
        foreach (var instruction in instructions)
        {
            sets.Add(instruction.current);
            sets.Add(instruction.laterStep);
            dependencies.Add(new Tuple<char, char>(instruction.current, instruction.laterStep));
        }
        var depes = dependencies.OrderBy(t => t.Item1).ToHashSet();

        var result = TopologicalSort(sets, depes);

        foreach (char ch in result)
            Console.Write(ch + "");
    }


    public void PartOne(string input)
    {
        var dependencies = new List<(string pre, string post)>();

        input.Lines().ForEach(x => dependencies.Add((x.Words().ElementAt(1), x.Words().ElementAt(7))));

        var allSteps = dependencies.Select(x => x.pre).Concat(dependencies.Select(x => x.post)).Distinct().OrderBy(x => x).ToList();
        var result = string.Empty;

        while (allSteps.Any())
        {
            var valid = allSteps.Where(s => !dependencies.Any(d => d.post == s)).First();

            result += valid;

            allSteps.Remove(valid);
            dependencies.RemoveAll(d => d.pre == valid);
        }

        Console.WriteLine(result);
    }

    public void PartTwo(string input)
    {
        var dependencies = new List<(string pre, string post)>();

        input.Lines().ForEach(x => dependencies.Add((x.Words().ElementAt(1), x.Words().ElementAt(7))));

        var allSteps = dependencies.Select(x => x.pre).Concat(dependencies.Select(x => x.post)).Distinct().OrderBy(x => x).ToList();
        var workers = new List<int>(5) { 0, 0, 0, 0, 0 };
        var currentSecond = 0;
        var doneList = new List<(string step, int finish)>();

        while (allSteps.Any() || workers.Any(w => w > currentSecond))
        {
            doneList.Where(d => d.finish <= currentSecond).ForEach(x => dependencies.RemoveAll(d => d.pre == x.step));
            doneList.RemoveAll(d => d.finish <= currentSecond);

            var valid = allSteps.Where(s => !dependencies.Any(d => d.post == s)).ToList();

            for (var w = 0; w < workers.Count && valid.Any(); w++)
            {
                if (workers[w] <= currentSecond)
                {
                    workers[w] = GetWorkTime(valid.First()) + currentSecond;
                    allSteps.Remove(valid.First());
                    doneList.Add((valid.First(), workers[w]));
                    valid.RemoveAt(0);
                }
            }

            currentSecond++;
        }

        Console.WriteLine(currentSecond.ToString());
    }

    private static int GetWorkTime(string v)
    {
        return (v[0] - 'A') + 61;
    }

    /// <summary>
    /// Topological Sorting (Kahn's algorithm) 
    /// </summary>
    /// <remarks>https://en.wikipedia.org/wiki/Topological_sorting</remarks>
    /// <typeparam name="T"></typeparam>
    /// <param name="nodes">All nodes of directed acyclic graph.</param>
    /// <param name="edges">All edges of directed acyclic graph.</param>
    /// <returns>Sorted node in topological order.</returns>
    static List<char> TopologicalSort(HashSet<char> nodes, HashSet<Tuple<char, char>> edges)
    {
        // Empty list that will contain the sorted elements
        var L = new List<char>();

        // Set of all nodes with no incoming edges
        var S = new List<char>(nodes.Where(n => edges.All(e => e.Item2.Equals(n) == false)));

        // while S is non-empty do
        while (S.Any())
        {

            //  remove a node n from S
            var n = S.First();
            S.Remove(n);

            // add n to tail of L
            L.Add(n);

            // for each node m with an edge e from n to m do
            var edgesz = edges.Where(e => e.Item1.Equals(n)).ToList();
            foreach (var e in edgesz)
            {
                var m = e.Item2;

                // remove edge e from the graph
                edges.Remove(e);

                // if m has no other incoming edges then
                if (edges.All(me => me.Item2.Equals(m) == false))
                {
                    var indexToInsert = S.Count;
                    // insert m into S
                    for (int i = 0; i < S.Count; i++)
                    {
                        if (S[i] < m)
                            continue;
                        else
                        {
                            indexToInsert = i;
                            break;
                        }
                    }

                    S.Insert(indexToInsert, m);
                }
            }
        }

        // if graph has edges then
        if (edges.Any())
        {
            // return error (graph has at least one cycle)
            return null;
        }
        else
        {
            // return L (a topologically sorted order)
            return L;
        }
    }
}