using System;
using System.Collections.Generic;
using System.Linq;

public static class GuardPicker {

    private static string shiftStartsKey = "Guard";
    private static string sleepsKey = "falls";

    public static void FindWeakestGuard(List<Shift> shiftInfoList)
    {
        Dictionary<int,Guard> guards = new Dictionary<int, Guard>();
        var activeGuardId = -1;
        int sleepMinute = 0;
        foreach(var shift in shiftInfoList)
        {
            var splitInfo = shift.info.Split(" ");
            Console.WriteLine($"ID: {shift.shiftId}: {shift.shiftTime} === {shift.info}");
            if (shift.info.Contains(shiftStartsKey))
            {
                var guardId = splitInfo[1].Replace("#","");
                var guard = new Guard();
                guard.id = int.Parse(guardId);
                activeGuardId = guard.id;
                
                guards.TryAdd(guard.id, value: guard);
            }
            else{
                Guard activeGuard;
                guards.TryGetValue(activeGuardId, out activeGuard);
                if (splitInfo[0] == sleepsKey)
                {
                    sleepMinute = shift.shiftTime.Minute;
                    if (!activeGuard.minuteSleepDict.TryAdd(sleepMinute, 1))
                    {
                        activeGuard.minuteSleepDict[sleepMinute]++;
                    }
                }
                else 
                {
                    var wakeUpMoment = shift.shiftTime.Minute;
                    var minutesSlept = wakeUpMoment - sleepMinute;
                    activeGuard.totalSleep += minutesSlept;
                    for (int i = sleepMinute; i < wakeUpMoment; i++)
                    {
                        if (!activeGuard.minuteSleepDict.TryAdd(i, 1))
                        {
                            activeGuard.minuteSleepDict[i]++;
                        }
                    }
                }
            }            
        }
        var guardsList = guards.Values.OrderByDescending(g => g.totalSleep).ToList();
        ShowMostSleepingGuardAnswer1(guardsList);
        ShowMostSleepingGuardAnswer2(guardsList);
    }

    private static void ShowMostSleepingGuardAnswer1(List<Guard> guardsList)
    {
        var guardaa = guardsList[0];
        var ababa = guardaa.minuteSleepDict.Max(p => p.Value);
        var aaa = guardaa.minuteSleepDict.Where(v => v.Value == ababa).Select(k => k.Key).First();
        Console.WriteLine($"TOP OF THE LIST guardId {guardsList[0].id} with total sleep {guardsList[0].totalSleep}");
        Console.WriteLine($"answer is {guardsList[0].id * aaa}");
    }

        private static void ShowMostSleepingGuardAnswer2(List<Guard> guardsList)
    {
        var maxMinutesSlept = 0;
        var idGuardSelected = 0;
        var minuteSelected = 0;
        foreach(var guard in guardsList)
        {
            if(guard.totalSleep != 0)
            {
                var abada = guard.minuteSleepDict.Max(p => p.Value);
                if (abada > maxMinutesSlept)
                {
                    maxMinutesSlept = abada;
                    idGuardSelected = guard.id;
                    minuteSelected = guard.minuteSleepDict.Where(v => v.Value == maxMinutesSlept).Select(k => k.Key).First();
                }
            }
        }
        Console.WriteLine($"TOP OF THE LIST guardId {guardsList[0].id} with total sleep {guardsList[0].totalSleep}");
        Console.WriteLine($"answer is {idGuardSelected * minuteSelected}");
    }
}