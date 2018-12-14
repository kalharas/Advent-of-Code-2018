using System.Collections.Generic;

public class LicenseCalculator
{
    public void Part1(IEnumerable<int> inputList)
    {
        var tree = new List<MyNode>();
        var headerInfo = new MyHeaderInfo(){
            NumberOfChildren = inputList[0],
            NumberOfMetaEntries = inputList[1]
        };

    }
}