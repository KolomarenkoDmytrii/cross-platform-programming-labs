using Lab2.App;
using System.IO;

namespace Lab2.Test;

public class Tests
{
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
}
