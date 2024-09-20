using Lab1.App;

namespace Lab1.Test;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [TestCase("agcta")]
    [TestCase("aGcTa")]
    [TestCase("AGCTA")]
    public void IsDnaSequence_IsDnaSequence(string sequence)
    {
        Assert.That(Program.IsDnaSequence(sequence), Is.True, $"{sequence} should be DNA sequence");
    }

    [Test]
    [TestCase("agctfa")]
    [TestCase("aGcTsa")]
    [TestCase("AGCTAV")]
    [TestCase("")]
    public void IsDnaSequence_IsNotDnaSequence(string sequence)
    {
        Assert.That(Program.IsDnaSequence(sequence), Is.False,  $"{sequence} should not be DNA sequence");
    }
}
