using System;
using System.Collections.Generic;

public static class GuardPicker {
    public static void FindWeakestGuard(List<Shift> shiftInfoList)
    {
        foreach(var shift in shiftInfoList)
        {
            Console.WriteLine($"{shift.shiftTime} === {shift.info}");
        }
    }
}