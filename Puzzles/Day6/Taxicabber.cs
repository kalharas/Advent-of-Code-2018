using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class Taxicabber {
    public void FindTheLargestArea(IList<Coordinate> coordinates){
        //first create the biggest grid by getting the max X or Y
        var maxCoord = 0;
        foreach(var coord in coordinates)
        {
            if (maxCoord < coord.xAxis)
            {
                maxCoord = coord.xAxis;
            }
            if(maxCoord < coord.yAxis)
            {
                maxCoord = coord.yAxis;
            }
        }

        Console.WriteLine($"max grid is {maxCoord + 1}, {maxCoord + 1}");

        int[,] grid = new int[maxCoord + 1,maxCoord + 1];

        var watchyy = Stopwatch.StartNew();
        for (int i = 0; i <= maxCoord; i++)
        {
            for (int j = 0; j <= maxCoord; j++)
            {
                var closestManhatten = int.MaxValue;
                foreach (var coordinate in coordinates)
                {
                    var distance = CalculateManhattanDistance(i, coordinate.xAxis, j, coordinate.yAxis);
                    if(distance == 0)
                    {
                        grid[i,j] = coordinate.tag;
                        break;
                    }
                    if (distance < closestManhatten)
                    {
                        closestManhatten = distance;
                        grid[i,j] = coordinate.tag;
                    }
                    else if(distance == closestManhatten)
                    {
                        grid[i,j] = -1;
                    }
                }
            }
        }

        var infiniteCoords =new List<Coordinate>(coordinates);
        var tagList = new List<int>();

        for (int i = 0; i <= maxCoord; i++)
        {
            var tag = grid[0,i];
            if(tag != -1){
                tagList.Add(tag);
            }
            tag = grid[maxCoord, i];
            if(tag != -1){
                tagList.Add(tag);
            }

            tag = grid[i, 0];
            if(tag != -1){
                tagList.Add(tag);
            }

            tag = grid[i, maxCoord];
            if(tag != -1){
                tagList.Add(tag);
            }
        }

        var finiteCoords = new List<Coordinate>(coordinates);
        tagList = tagList.Distinct().ToList();

        Console.WriteLine($"{tagList.Count} coordinates to remove");
        foreach(var coordinate in coordinates)
        {
            if (tagList.Contains(coordinate.tag))
            {
                finiteCoords.Remove(coordinate);
            }
        }
        
        Console.WriteLine($"{finiteCoords.Count} coordinates to left");
        Dictionary<int, int> tagCount = new Dictionary<int, int>();
        
        foreach (var finiteCoord in finiteCoords)
        {
            var maxCount = 0;
            for (int i = 0; i <= maxCoord; i++)
            {
                for (int j = 0; j <= maxCoord; j++)
                {
                    if (grid[j,i] == finiteCoord.tag)
                    {
                        maxCount++;
                    }
                }
            }
            tagCount.Add(finiteCoord.tag, maxCount);
        }

        Console.WriteLine($"{watchyy.ElapsedMilliseconds/1000} seconds spent on creating the grid");

        foreach (var keyValuePair in tagCount)
        {
            Console.WriteLine($"Tag: {keyValuePair.Key}, Size:{keyValuePair.Value}");
        }
        
        Console.WriteLine($"Size is {tagCount.Max(v => v.Value)}");
        watchyy.Stop();
        //Create the array with 3 dimension: x,y,closest indication
    }

    private static int CalculateManhattanDistance(int x1, int x2, int y1, int y2)
    {
        return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
    }

    private static void PrintGrid(int[,] grid)
    {
        for (int i = 0; i <= grid.Length; i++){
            for (int j = 0; j<= grid.Length; j++){
                Console.Write($"{grid[j,i]}");
            }
            Console.Write("\n");
        }
    }

    private static void PrintWithRemovedInfinites(int[,] grid, List<int> tagList)
    {
                for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j <= grid.Length; j++)
            {
                if (tagList.Contains(grid[j, i]))
                    grid[j, i] = -2;
                Console.Write($"{grid[j, i]}");
            }
            Console.Write("\n");
        }
    }
}