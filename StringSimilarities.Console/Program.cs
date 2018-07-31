using System.Linq;

namespace StringSimilarities.Console
{
    class Program
    {
        static void Main()
        {
            IStringSimilarities stringSimilarities = new LevenshteinStringSimilarities();
            string line;

            System.Console.WriteLine("Insert the two words, separated by a space: ");
            while ((line = System.Console.ReadLine()) != "exit")
            {
                var parts = line?.Split(' ').Where(i => i.Trim() != string.Empty).ToArray();

                if (parts?.Length == 2)
                {
                    var result = stringSimilarities.DetermineSimilarities(parts[0], parts[1]);
                    System.Console.WriteLine($"String similarities: {result}");
                }
                System.Console.WriteLine("Insert the two words, separated by a space: ");
            }
        }
    }
}
