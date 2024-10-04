using System;
using System.IO;
using Lab3.Lib;

namespace Lab3.App
{
    class Program
    {
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

        static void Main()
        {
            try
            {
                WriteAnswer("INPUT.TXT", "OUTPUT.TXT");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"An error occured: {exception}");
            }
        }
    }
}
