using System;

class Program
{
    static void CountVowelsConsonants(string str)
    {
        int vowels = 0, consonants = 0;

        for (int i = 0; i < str.Length; i++)
        {
            char ch = char.ToLower(str[i]);

            if (ch >= 'a' && ch <= 'z')
            {
                if (ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u')
                    vowels++;
                else
                    consonants++;
            }
        }

        Console.WriteLine("Vowels: " + vowels);
        Console.WriteLine("Consonants: " + consonants);
    }

    static void Main()
    {
        Console.Write("Enter string: ");
        string input = Console.ReadLine();
        CountVowelsConsonants(input);
    }
}
