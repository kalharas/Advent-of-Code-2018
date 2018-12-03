using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AdventCode2018.Day1
{
    public static class CalibrationManager
    {
        public static void CalibrateEveryTwice(List<int> frequencies)
        {
            Dictionary<int, int> calibratedFrequency = new Dictionary<int, int>();
            //Initial calibration is 0 so it needs to be counted.
            calibratedFrequency.Add(0, 1);

            var keyValue = 0;
            var stop = false;
            while (!stop)
            {
                for(int i = 0; i < frequencies.Count; i++)
                {
                    keyValue += frequencies[i];
                    if (calibratedFrequency.ContainsKey(keyValue))
                    {
                        Console.WriteLine($"first reaches {keyValue} twice");
                        stop = true;
                        calibratedFrequency[keyValue]++;
                        break;                        
                    }
                    else {
                        calibratedFrequency.Add(keyValue,1);
                    }
                }
            }
        }

        public static void PrintSums(List<int> frequencies)
        {
            var sum = frequencies.Sum();
            Console.WriteLine($"{sum}");
        }
    }
}