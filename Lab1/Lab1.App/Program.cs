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
            Console.WriteLine(IsDnaSequence("agcta"));
            Console.WriteLine(IsDnaSequence("agcfta"));
            Console.WriteLine(IsDnaSubsequence("agcta", "gta"));
        }
    }
}
