using System;

class Program
{
    static string LongestWord(string sentence)
    {
        string[] words = sentence.Split(' ');
        string longest = words[0];

        for (int i = 1; i < words.Length; i++)
        {
            if (words[i].Length > longest.Length)
                longest = words[i];
        }
        return longest;
    }

    static void Main()
    {
        Console.Write("Enter sentence: ");
        string input = Console.ReadLine();
        Console.WriteLine("Longest Word: " + LongestWord(input));
    }
}
