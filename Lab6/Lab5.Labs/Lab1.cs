/*
Вхідні дані
Перший рядок вхідного файлу INPUT.TXT містить послідовність s, другий - послідовність t.
Розмір вхідного файлу вбирається у 256 кілобайт.
*/

using System;
using System.IO;

namespace Lab5.Labs
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

        public static string Run(string? sequence, string? subsequence)
        {
            if (sequence == null)
                sequence = "";
            if (subsequence == null)
                subsequence = "";

            return IsDnaSubsequence(sequence, subsequence)? "YES" : "NO";
        }
    }
}
