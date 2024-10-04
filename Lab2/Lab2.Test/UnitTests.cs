using Lab2.App;

namespace Lab2.Test;

public class Tests
{
    private BinarySumsNumberCalculator _cacheableCalculator;

    [SetUp]
    public void SetUp()
    {
        _cacheableCalculator = new BinarySumsNumberCalculator();
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
        BinarySumsNumberCalculator calculator = new BinarySumsNumberCalculator();
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
