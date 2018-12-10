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
        for (int i = 0; i < maxCoord; i++)
        {
            for (int j = 0; j < maxCoord; j++)
            {
                var closestManhatten = int.MaxValue;
                foreach (var coord in coordinates)
                {
                    var distance = CalculateManhattanDistance(i, coord.xAxis, j, coord.yAxis);
                    if (distance < closestManhatten)
                    {
                        closestManhatten = distance;
                        grid[i,j] = coord.tag;
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

        for (int i = 0; i < maxCoord; i++)
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

        foreach(var coordinate in coordinates)
        {
            if (tagList.Contains(coordinate.tag))
            {
                finiteCoords.Remove(coordinate);
            }
        }
        
        Dictionary<int, int> tagCount = new Dictionary<int, int>();
        var maxCount = 0;
        foreach (var finiteCoord in finiteCoords)
        {
            for (int i = 0; i < maxCoord; i++)
            {
                for (int j = 0; j < maxCoord; j++)
                {
                    if (grid[i,j] == finiteCoord.tag)
                    {
                        maxCount++;
                    }
                }
            }
            tagCount.Add(finiteCoord.tag, maxCount);
        }

        Console.WriteLine($"{watchyy.ElapsedMilliseconds} miliseconds spent on creating the grid");
        Console.WriteLine($"Size is {tagCount.Max(v => v.Value)}");
        watchyy.Stop();
        //Create the array with 3 dimension: x,y,closest indication
    }

    private static int CalculateManhattanDistance(int x1, int x2, int y1, int y2)
    {
        return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
    }
}