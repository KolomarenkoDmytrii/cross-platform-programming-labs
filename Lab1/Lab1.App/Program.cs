using System;
using System.IO;

namespace Lab1.App
{
    public class Program
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

        static void Main()
        {
            try
            {
                string subsequence = "";
                string sequence = "";
                using (StreamReader input = new StreamReader("INPUT.TXT"))
                {
                    subsequence = input.ReadLine();
                    sequence = input.ReadLine();

                    if (subsequence == null || sequence == null)
                        throw new Exception("Could not read the subsequence or sequence string");
                    }

                using (StreamWriter output = new StreamWriter("OUTPUT.TXT"))
                {
                    output.WriteLine(
                        IsDnaSubsequence(sequence, subsequence) ? "YES" : "NO"
                    );
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"An error occured: {exception}");
            }
        }
    }
}
