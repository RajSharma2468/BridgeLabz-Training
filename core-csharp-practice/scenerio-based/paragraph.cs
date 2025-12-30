using System;

class Program
{
    static void AnalyzeParagraph(string text)
    {
        int wordCount = 0;
        int maxLen = 0;
        string longest = "";
        string word = "";

        for (int i = 0; i <= text.Length; i++)
        {
            if (i < text.Length && text[i] != ' ')
            {
                word = word + text[i];
            }
            else
            {
                if (word.Length > 0)
                {
                    wordCount++;

                    if (word.Length > maxLen)
                    {
                        maxLen = word.Length;
                        longest = word;
                    }
                    word = "";
                }
            }
        }

        Console.WriteLine("Word Count = " + wordCount);
        Console.WriteLine("Longest Word = " + longest);
    }

    static string ReplaceWord(string text, string oldWord, string newWord)
    {
        string result = "";
        string word = "";

        for (int i = 0; i <= text.Length; i++)
        {
            if (i < text.Length && text[i] != ' ')
            {
                word = word + text[i];
            }
            else
            {
                if (word.Length > 0)
                {
                    if (CompareIgnoreCase(word, oldWord))
                        result = result + newWord;
                    else
                        result = result + word;
                }

                if (i < text.Length)
                    result = result + " ";

                word = "";
            }
        }
        return result;
    }

    static bool CompareIgnoreCase(string a, string b)
    {
        if (a.Length != b.Length) return false;

        for (int i = 0; i < a.Length; i++)
        {
            char c1 = a[i];
            char c2 = b[i];

            if (c1 >= 'A' && c1 <= 'Z') c1 = (char)(c1 + 32);
            if (c2 >= 'A' && c2 <= 'Z') c2 = (char)(c2 + 32);

            if (c1 != c2) return false;
        }
        return true;
    }

    static void Main()
    {
        Console.WriteLine("Enter paragraph:");
        string text = Console.ReadLine();

        bool onlySpace = true;
        for (int i = 0; i < text.Length; i++)
            if (text[i] != ' ') onlySpace = false;

        if (text.Length == 0 || onlySpace)
        {
            Console.WriteLine("Empty or invalid paragraph");
            return;
        }

        AnalyzeParagraph(text);

        Console.WriteLine("Enter word to replace:");
        string oldWord = Console.ReadLine();

        Console.WriteLine("Enter new word:");
        string newWord = Console.ReadLine();

        string updated = ReplaceWord(text, oldWord, newWord);

        Console.WriteLine("Updated Paragraph:");
        Console.WriteLine(updated);
    }
}
