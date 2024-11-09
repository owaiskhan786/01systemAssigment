using System;
using System.Linq;
using System.Collections.Generic;

public interface IRandomNumberGenerator
{
    Dictionary<int, int> GenerateRandomNumberOccurrences(int rangeStart, int rangeEnd, int min, int max);
}

public class RandomNumberGenerator : IRandomNumberGenerator
{
    public Dictionary<int, int> GenerateRandomNumberOccurrences(int rangeStart, int rangeEnd, int min, int max)
    {
        max = max + 1;
        Random system01rand = new Random();
        int[] system01number = Enumerable.Range(rangeStart, rangeEnd)
                                         .Select(i => system01rand.Next(min, max))
                                         .ToArray();

        return system01number.GroupBy(n => n)
                             .ToDictionary(n => n.Key, n => n.Count());
    }
}

public interface IWordCounter
{
    void CountWordOccurrences(string[] words, string longString);
}

public class WordCounter : IWordCounter
{
    private char ToLowerCase(char c)
    {
        return (c >= 'A' && c <= 'Z') ? (char)(c + 32) : c;
    }

    private bool AreStringsEqualCaseInsensitive(string str1, string longString, int startIndex)
    {
        if (startIndex + str1.Length > longString.Length)
            return false;

        for (int i = 0; i < str1.Length; i++)
        {
            if (ToLowerCase(str1[i]) != ToLowerCase(longString[startIndex + i]))
                return false;
        }
        return true;
    }

    public void CountWordOccurrences(string[] words, string longString)
    {
        foreach (string word in words)
        {
            int count = 0;
            int wordLength = word.Length;

            for (int i = 0; i <= longString.Length - wordLength; i++)
            {
                if (AreStringsEqualCaseInsensitive(word.Trim(), longString, i))
                {
                    count++;
                    i += wordLength - 1;
                }
            }

            Console.WriteLine($"The word '{word.Trim()}' occurs {count} time(s).");
        }
    }
}

class Program
{
    private readonly IRandomNumberGenerator _randomNumberGenerator;
    private readonly IWordCounter _wordCounter;

    public Program(IRandomNumberGenerator randomNumberGenerator, IWordCounter wordCounter)
    {
        _randomNumberGenerator = randomNumberGenerator;
        _wordCounter = wordCounter;
    }

    static void Main()
    {
        IRandomNumberGenerator randomNumberGenerator = new RandomNumberGenerator();
        IWordCounter wordCounter = new WordCounter();
        Program program = new Program(randomNumberGenerator, wordCounter);

        program.Run();
    }

    public void Run()
    {
        Console.WriteLine("Select an option:");
        Console.WriteLine("1. Generate random number occurrences");
        Console.WriteLine("2. Count word occurrences in a string");
        Console.Write("Enter choice (1 or 2): ");
        string choice = Console.ReadLine();

        if (choice == "1")
        {
            Console.Write("Enter the range start: ");
            int rangeStart = int.Parse(Console.ReadLine());
            Console.Write("Enter the range end: ");
            int rangeEnd = int.Parse(Console.ReadLine());
            Console.Write("Enter the minimum random number value: ");
            int min = int.Parse(Console.ReadLine());
            Console.Write("Enter the maximum random number value: ");
            int max = int.Parse(Console.ReadLine());

            var result = _randomNumberGenerator.GenerateRandomNumberOccurrences(rangeStart, rangeEnd, min, max);
            foreach (var (number, count) in result)
            {
                Console.WriteLine($"Number {number} occurs {count} time(s).");
            }
        }
        else if (choice == "2")
        {
            Console.Write("Enter words to search (comma-separated): ");
            string[] words = Console.ReadLine().Split(',');
            Console.Write("Enter the long string to search in: ");
            string longString = Console.ReadLine();

            _wordCounter.CountWordOccurrences(words, longString);
        }
        else
        {
            Console.WriteLine("Invalid choice. Please enter 1 or 2.");
        }
    }
}
