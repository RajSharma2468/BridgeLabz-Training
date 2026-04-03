using System;

class Program
{
    static string ToggleCase(string str)
    {
        string result = "";

        for (int i = 0; i < str.Length; i++)
        {
            char ch = str[i];

            if (ch >= 'A' && ch <= 'Z')
                result += (char)(ch + 32);
            else if (ch >= 'a' && ch <= 'z')
                result += (char)(ch - 32);
            else
                result += ch;
        }
        return result;
    }

    static void Main()
    {
        Console.Write("Enter string: ");
        string input = Console.ReadLine();
        Console.WriteLine("Toggled String: " + ToggleCase(input));
    }
}
