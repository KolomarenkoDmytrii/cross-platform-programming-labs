using System;
using Lab3.Lib;
using static Lab3.Lib.ShortestTimeFinder;


namespace Lab3.App
{
    class Program
    {
        static void Main()
        {
            StationPath[] paths = [
                new StationPath(new Node(1, 2), new Time(5, 10)), // 1
                new StationPath(new Node(2, 4), new Time(10, 15)), // 2
                new StationPath(new Node(5, 4), new Time(0, 17)),
                new StationPath(new Node(4, 3), new Time(17, 20)), // 3
                new StationPath(new Node(3, 2), new Time(20, 35)),
                new StationPath(new Node(1, 3), new Time(2, 40)),
                new StationPath(new Node(3, 4), new Time(40, 45)),
                new StationPath(new Node(4, 5), new Time(40, 45))
            ];

            int answer = FindShortestTime(1, 5, paths);
            Console.WriteLine($"Answer: {answer}");
        }
    }
}
