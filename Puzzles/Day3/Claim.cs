using System;

namespace AdventCode2018.Puzzles.Day3
{
    public class Claim
    {
        public int id {get;set;}
        private int DistanceFromTopOfFabric {get;set;}
        private int DistanceFromLeftOfFabric {get;set;}
        private int Width {get;set;}
        private int height {get;set;}

        public int StartX{ get {
           return DistanceFromLeftOfFabric;
        }}

        public int StartY {get {
            return DistanceFromTopOfFabric;
        }}

        public int EndX { get {
            return DistanceFromLeftOfFabric + Width;
        }}

        public int EndY {get {
            return DistanceFromTopOfFabric + height;
        }}

        public Claim(int id, int distanceFromLeftOfFabric, int distanceFromTopOfFabric, int width, int height)
        {
            this.id = id;
            DistanceFromTopOfFabric = distanceFromTopOfFabric;
            DistanceFromLeftOfFabric = distanceFromLeftOfFabric;
            Width = width;
            this.height = height;
        }
    }

}