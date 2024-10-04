using Lab3.App;
using Lab3.Lib;

namespace Lab3.Test;

public class Tests
{
    public record TripInfo(
        int FromStation,
        int ToStation,
        int FromTime,
        int ToTime
    );

    private Graph _testableGraph;

    [SetUp]
    public void Setup()
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

        _testableGraph = new Graph(infos.Count() + 1);
        foreach (TripInfo info in infos)
            _testableGraph.AddEdge(
                info.FromStation,
                info.ToStation,
                info.FromTime,
                info.ToTime
            );
    }

    [Test]
    [TestCase(1, 3, 20)]
    [TestCase(1, 5, Graph.INFINITY)]
    [TestCase(1, 2, 10)]
    [TestCase(3, 4, 45)]
    [TestCase(5, 1, Graph.INFINITY)]
    public void FindShortestTimes_isAnswerCorrect(int start, int end, int answer)
    {
        List<int> times = _testableGraph.FindShortestTimes(start);
        int result = times[end];

        Assert.That(
            result == answer,
            Is.True,
            $"Answer for start {start} and end {end} must be {answer}, not {result}"
        );
    }
}
