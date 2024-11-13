using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab5.Labs
{
    public class Lab3
    {
        public class Priority
        {
            public int time;
            public int vertex;

            public Priority(int time, int vertex)
            {
                this.time = time;
                this.vertex = vertex;
            }
        }

        public class Edge
        {
            public int toVertex;
            public int fromTime;
            public int toTime;

            public Edge(int toVertex, int fromTime, int toTime)
            {
                this.toVertex = toVertex;
                this.fromTime = fromTime;
                this.toTime = toTime;
            }
        }

        public class Graph
        {
            public List<List<Edge>> graph;
            public const int INFINITY = Int32.MaxValue;

            public Graph(int numberOfStations)
            {
                graph = new List<List<Edge>>(numberOfStations);

                for (int i = 0; i < numberOfStations; i++)
                    graph.Add(new List<Edge>());
            }

            public void AddEdge(int fromStation, int toStation, int fromTime, int toTime)
            {
                graph[fromStation].Add(new Edge(toStation, fromTime, toTime));
            }

            public List<int> FindShortestTimes(int start)
            {
                List<int> times = new List<int>(graph.Count);

                for (int i = 0; i < graph.Count; i++)
                    times.Add(INFINITY);

                if (start < 0 || start >= graph.Count)
                    return times;

                times[start] = 0;

                PriorityQueue<Priority, int> queue = new PriorityQueue<Priority, int>();
                queue.Enqueue(new Priority(0, start), 0);

                while (queue.Count != 0)
                {
                    int vertex = queue.Peek().vertex;
                    int time = queue.Peek().time;
                    queue.Dequeue();

                    if (time > times[vertex])
                        continue;

                    foreach (Edge i in graph[vertex])
                    {
                        // if edge (vertex, toStation) has information what
                        // fromTime train leaving from vertex time is bigger then
                        // times[vertex], we can't catch a train
                        if (i.fromTime < times[vertex])
                            continue;

                        int toStation = i.toVertex;
                        if (times[toStation] > i.toTime)
                        {
                            times[toStation] = i.toTime;
                            queue.Enqueue(new Priority(times[toStation], toStation), times[toStation]);
                        }
                    }
                }

                return times;
            }
        }

        public record TripInfo(
            int FromStation,
            int ToStation,
            int FromTime,
            int ToTime
        );

        public static int Run(int start, int end)
        {
            TripInfo[] infos = [
                new TripInfo(FromStation: 1, ToStation: 2, FromTime: 5, ToTime: 10),
                new TripInfo(FromStation: 2, ToStation: 4, FromTime: 10, ToTime: 15),
                new TripInfo(FromStation: 5, ToStation: 4, FromTime: 0, ToTime: 17),
                new TripInfo(FromStation: 4, ToStation: 3, FromTime: 17, ToTime: 20),
                new TripInfo(FromStation: 3, ToStation: 2, FromTime: 20, ToTime: 35),
                new TripInfo(FromStation: 1, ToStation: 3, FromTime: 2, ToTime: 40),
                new TripInfo(FromStation: 3, ToStation: 4, FromTime: 40, ToTime: 45)
            ];

            Graph graph = new Lab3.Graph(infos.Count() + 1);
            foreach (TripInfo info in infos)
                graph.AddEdge(
                    info.FromStation,
                    info.ToStation,
                    info.FromTime,
                    info.ToTime
                );

            List<int> times = graph.FindShortestTimes(start);
            if (end < 0 || end >= times.Count)
                return Graph.INFINITY;
            return times[end];
        }
    }
}
