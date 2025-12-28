using System;

class Program
{
    static string RemoveChar(string str, char ch)
    {
        string result = "";

        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] != ch)
                result += str[i];
        }
        return result;
    }

    static void Main()
    {
        Console.Write("Enter string: ");
        string input = Console.ReadLine();

        Console.Write("Enter character to remove: ");
        char ch = Convert.ToChar(Console.ReadLine());

        Console.WriteLine("Modified String: " + RemoveChar(input, ch));
    }
}
