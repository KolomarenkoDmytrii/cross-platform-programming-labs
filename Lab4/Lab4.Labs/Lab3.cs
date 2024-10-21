using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab4.Labs
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

        public static void WriteAnswer(string inputFilePath, string outputFilePath)
        {
            int startStation = 0;
            Graph? graph = null;

            using (StreamReader input = new StreamReader(inputFilePath))
            {

                string[] numbers = input.ReadLine().Split(' ');
                int stationsNumber = Int32.Parse(numbers[0]);
                startStation = Int32.Parse(numbers[1]);

                graph = new Graph(stationsNumber + 1);

                int tripsNumber = Int32.Parse(input.ReadLine());

                for (int j = 0; j < tripsNumber; j++)
                {
                    numbers = input.ReadLine().Split(' ');
                    int count = Int32.Parse(numbers[0]);
                    for (int i = 1; i < count * 2 - 2; i += 2)
                    {
                        int fromStation = Int32.Parse(numbers[i]);
                        int fromTime = Int32.Parse(numbers[i + 1]);
                        int toStation = Int32.Parse(numbers[i + 2]);
                        int toTime = Int32.Parse(numbers[i + 3]);

                        graph.AddEdge(fromStation, toStation, fromTime, toTime);
                    }
                }
            }

            List<int> times = graph.FindShortestTimes(1);

            using (StreamWriter output = new StreamWriter(outputFilePath))
            {
                output.WriteLine(
                    times[startStation] == Graph.INFINITY ? -1 : times[startStation]
                );
            }
        }
    }
}
