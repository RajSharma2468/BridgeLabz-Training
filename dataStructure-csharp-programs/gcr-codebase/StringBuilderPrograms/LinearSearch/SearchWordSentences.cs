using System;

class Program
{
    static void Main()
    {
        string[] sentences = {
            "I love CSharp",
            "Java is good"
        };

        string word = "CSharp";

        for (int i = 0; i < sentences.Length; i++)
        {
            bool match = true;

            for (int j = 0; j < word.Length; j++)
            {
                if (sentences[i][j] != word[j])
                {
                    match = false;
                    break;
                }
            }

            if (match)
            {
                Console.WriteLine(sentences[i]);
                return;
            }
        }

        Console.WriteLine("Not Found");
    }
}
