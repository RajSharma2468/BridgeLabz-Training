using System;

class Program
{
    static string ReplaceWord(string sentence, string oldWord, string newWord)
    {
        string result = "";
        string[] words = sentence.Split(' ');

        for (int i = 0; i < words.Length; i++)
        {
            if (words[i] == oldWord)
                result += newWord;
            else
                result += words[i];

            if (i < words.Length - 1)
                result += " ";
        }
        return result;
    }

    static void Main()
    {
        Console.Write("Enter sentence: ");
        string sentence = Console.ReadLine();

        Console.Write("Enter word to replace: ");
        string oldWord = Console.ReadLine();

        Console.Write("Enter new word: ");
        string newWord = Console.ReadLine();

        Console.WriteLine("Modified Sentence: " + ReplaceWord(sentence, oldWord, newWord));
    }
}
