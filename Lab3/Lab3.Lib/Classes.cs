using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab3.Lib
{
    public class ShortestTimeFinder
    {
        public struct Node
        {
            public int start;
            public int end;

            public Node(int start, int end)
            {
                this.start = start;
                this.end = end;
            }
        }

        public struct Time
        {
            public int start;
            public int end;

            public Time(int start, int end)
            {
                this.start = start;
                this.end = end;
            }
        }

        public struct StationPath
        {
            public Node node;
            public Time time;

            public StationPath(Node node, Time time)
            {
                this.node = node;
                this.time = time;
            }
        }

        static public int FindShortestTime(int startStation, int endStation, StationPath[] paths)
        {
            int currentStation = startStation;
            List<int> checkedStations = new List<int>();
            StationPath minStation = new StationPath();
            // int answer = -1;

            while (currentStation != endStation)
            {
                StationPath[] currentNodes = Array.FindAll(
                    paths,
                    station => station.node.start == currentStation
                );

                Console.WriteLine("------------------------");
                // foreach (var c in checkedStations)
                //     Console.WriteLine(c);
                // Console.WriteLine($"currentStation = {currentStation}");
                foreach (var c in currentNodes)
                    Console.WriteLine($"StationPath(Node({c.node.start}, {c.node.end}), Time({c.time.start}, {c.time.end}))");

                if (checkedStations.Contains(currentNodes[0].node.start))
                    return -1;

                minStation = currentNodes.MinBy(
                    station => station.time.end - station.time.start
                );
                Console.WriteLine($"minStation = StationPath(Node({minStation.node.start}, {minStation.node.end}), Time({minStation.time.start}, {minStation.time.end}))");

                checkedStations.Add(minStation.node.start); //currentStation
                currentStation = minStation.node.end;

                // Console.WriteLine("=====");
                // foreach (var c in checkedStations)
                //     Console.WriteLine(c);
                // Console.WriteLine($"currentStation = {currentStation}");
            }

            return minStation.time.end;
        }
    }
}
