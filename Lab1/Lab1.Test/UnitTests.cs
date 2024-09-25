using Lab1.App;
using System.IO;

namespace Lab1.Test;

public class Tests
{
    [Test]
    [TestCase("agcta")]
    [TestCase("aGcTa")]
    [TestCase("AGCTA")]
    public void IsDnaSequence_IsDnaSequence(string sequence)
    {
        Assert.That(
            Program.IsDnaSequence(sequence),
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
            Program.IsDnaSequence(sequence),
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
            Program.IsDnaSubsequence(sequence, subsequence),
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
            Program.IsDnaSubsequence(sequence, subsequence),
            Is.False,
            $"'{subsequence}' should not be subsequence of '{sequence}'"
        );
    }

    [Test]
    [TestCase("agcta", "gta")]
    [TestCase("agCta", "gTA")]
    [TestCase("AGGGGGC", "GGC")]
    public void Main_OutputFileMustContainYes(string sequence, string subsequence)
    {
        DirectoryInfo temporaryData = Directory.CreateDirectory("temp");

        string inputFile = Path.Combine(".", "temp", "INPUT.TXT");
        string outputFile = Path.Combine(".", "temp", "OUTPUT.TXT");

        using (StreamWriter input = new StreamWriter(inputFile))
        {
            input.WriteLine(subsequence);
            input.WriteLine(sequence);
        }

        Program.WriteAnswer(inputFile, outputFile);

        using (StreamReader output = new StreamReader(outputFile))
        {
            string answer = output.ReadLine();

            Assert.That(
                answer == "YES",
                Is.True,
                $"a combination of subsequence '{subsequence}' and " +
                    $"sequence '{sequence}' must give 'YES'"
            );
        }

        temporaryData.Delete(true); // true => recursive delete
    }

    [Test]
    [TestCase("gTA", "agcta")]
    [TestCase("agCtba", "gTA")]
    [TestCase("AGGGGGC", "")]
    [TestCase("AGGGGGC", "GAT")]
    public void Main_OutputFileMustContainNo(string sequence, string subsequence)
    {
        DirectoryInfo temporaryData = Directory.CreateDirectory("temp");

        string inputFile = Path.Combine(".", "temp", "INPUT.TXT");
        string outputFile = Path.Combine(".", "temp", "OUTPUT.TXT");

        using (StreamWriter input = new StreamWriter(inputFile))
        {
            input.WriteLine(subsequence);
            input.WriteLine(sequence);
        }

        Program.WriteAnswer(inputFile, outputFile);

        using (StreamReader output = new StreamReader(outputFile))
        {
            string answer = output.ReadLine();

            Assert.That(
                answer == "NO",
                Is.True,
                $"a combination of subsequence '{subsequence}' and " +
                    $"sequence '{sequence}' must give 'NO'"
            );
        }

        temporaryData.Delete(true); // true => recursive delete
    }
}
