using Lab4.Labs;

namespace Lab4.Test;

public class Lab1Tests
{
    [Test]
    [TestCase("agcta")]
    [TestCase("aGcTa")]
    [TestCase("AGCTA")]
    public void IsDnaSequence_IsDnaSequence(string sequence)
    {
        Assert.That(
            Lab1.IsDnaSequence(sequence),
            Is.True,
            $"'{sequence}' should be DNA sequence"
        );
    }

    [Test]
    [TestCase("agctfa")]
    [TestCase("aGcTsa")]
    [TestCase("AGCTAV")]
    [TestCase("")]
    public void IsDnaSequence_IsNotDnaSequence(string sequence)
    {
        Assert.That(
            Lab1.IsDnaSequence(sequence),
            Is.False,
            $"'{sequence}' should not be DNA sequence"
        );
    }

    [Test]
    [TestCase("agcta", "gta")]
    [TestCase("agCta", "gTA")]
    [TestCase("AGGGGGC", "GGC")]
    public void IsDnaSubsequence_IsDnaSubsequence(string sequence, string subsequence)
    {
        Assert.That(
            Lab1.IsDnaSubsequence(sequence, subsequence),
            Is.True,
            $"'{subsequence}' should be subsequence of '{sequence}'"
        );
    }

    [Test]
    [TestCase("gTA", "agcta")]
    [TestCase("agCtba", "gTA")]
    [TestCase("AGGGGGC", "")]
    [TestCase("AGGGGGC", "GAT")]
    public void IsDnaSubsequence_IsNotDnaSubsequence(string sequence, string subsequence)
    {
        Assert.That(
            Lab1.IsDnaSubsequence(sequence, subsequence),
            Is.False,
            $"'{subsequence}' should not be subsequence of '{sequence}'"
        );
    }
}

public class Lab2Tests
{
    private Lab2.BinarySumsNumberCalculator _cacheableCalculator;

    [SetUp]
    public void SetUp()
    {
        _cacheableCalculator = new Lab2.BinarySumsNumberCalculator();
    }

    [Test]
    [TestCase(7, 6)]
    [TestCase(6, 6)]
    [TestCase(4, 4)]
    [TestCase(3, 2)]
    [TestCase(1, 1)]
    [TestCase(2, 2)]
    [TestCase(-1, 0)]
    public void BinarySumsNumberCalculator_isAnswerCorrect(int number, int answer)
    {
        Lab2.BinarySumsNumberCalculator calculator = new Lab2.BinarySumsNumberCalculator();
        int result = calculator.Calculate(number);

        Assert.That(
            answer == result,
            Is.True,
            $"Number {number} must have {answer} binary sum(s), not {result}"
        );
    }

    [Test]
    [TestCase(7, 6)]
    [TestCase(6, 6)]
    [TestCase(4, 4)]
    [TestCase(3, 2)]
    [TestCase(1, 1)]
    [TestCase(2, 2)]
    [TestCase(-1, 0)]
    public void BinarySumsNumberCalculator_isAnswerCorrectWithCacheable(int number, int answer)
    {
        int result = _cacheableCalculator.Calculate(number);

        Assert.That(
            answer == result,
            Is.True,
            $"Number {number} must have {answer} binary sum(s), not {result}"
        );
    }
}

public class Lab3Tests
{
    public record TripInfo(
        int FromStation,
        int ToStation,
        int FromTime,
        int ToTime
    );

    private Lab3.Graph _testableGraph;

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

        _testableGraph = new Lab3.Graph(infos.Count() + 1);
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
    [TestCase(1, 5, Lab3.Graph.INFINITY)]
    [TestCase(1, 2, 10)]
    [TestCase(3, 4, 45)]
    [TestCase(5, 1, Lab3.Graph.INFINITY)]
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
