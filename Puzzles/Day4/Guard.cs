using System.Collections.Generic;

public class Guard{
    public int id {get;set;}
    public Dictionary<int, int> minuteSleepDict {get;set;}
    public int[,] shiftTimes {get;set;}
    public Shift guardShift{get;set;}
    public int totalSleep {get;set;}
    public Guard()
    {
        minuteSleepDict = new Dictionary<int, int>();
        shiftTimes = new int[10,10];
        totalSleep= 0;
    }
}