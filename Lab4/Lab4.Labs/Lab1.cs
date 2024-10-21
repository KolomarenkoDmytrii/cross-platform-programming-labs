/*
Вхідні дані
Перший рядок вхідного файлу INPUT.TXT містить послідовність s, другий - послідовність t.
Розмір вхідного файлу вбирається у 256 кілобайт.
*/

using System;
using System.IO;

namespace Lab4.Labs
{
    public class Lab1
    {
        public static bool IsDnaSequence(string sequence)
        {
            if (sequence.Length == 0)
                return false;

            char[] allowedSymbols = ['A', 'G', 'C', 'T'];
            foreach (char symbol in sequence.ToUpper())
            {
                if (!allowedSymbols.Contains(symbol))
                    return false;
            }

            return true;
        }

        public static bool IsDnaSubsequence(string sequence, string subsequence)
        {
            if (subsequence.Length > sequence.Length)
                return false;

            if (!IsDnaSequence(sequence) || !IsDnaSequence(subsequence))
                return false;

            int count = 0;
            foreach (char symbol in sequence)
            {
                if (Char.ToUpper(subsequence[count]) == Char.ToUpper(symbol))
                    count++;
            }

            return count == subsequence.Length;
        }

        public static void WriteAnswer(string inputFilePath, string outputFilePath)
        {
            string? subsequence = "";
            string? sequence = "";

            if (new FileInfo(inputFilePath).Length > 256 * 1024)
                throw new Exception(
                    "The input file is too big: " +
                        "the maximum input file size is 256 KB"
                );

            using (StreamReader input = new StreamReader(inputFilePath))
            {
                subsequence = input.ReadLine();
                sequence = input.ReadLine();

                if (subsequence == null || sequence == null)
                    throw new Exception(
                        "Could not read the subsequence or sequence string"
                    );
            }

            using (StreamWriter output = new StreamWriter(outputFilePath))
            {
                output.WriteLine(
                    IsDnaSubsequence(sequence, subsequence) ? "YES" : "NO"
                );
            }
        }
    }
}
