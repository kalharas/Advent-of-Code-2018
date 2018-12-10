public class Coordinate{

    public int xAxis {get;set;}
    public int yAxis {get;set;}
    public int tag {get;set;}
    public Coordinate(int x, int y, int value)
    {
        xAxis = x;
        yAxis = y;
        tag = value;
    }
}