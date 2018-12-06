using System.Collections.Generic;

public class Guard{
    public int id {get;set;}
    public Dictionary<int, bool> sleepShift {get;set;}
    public List<Shift> DutyTimes{get;set;}
}