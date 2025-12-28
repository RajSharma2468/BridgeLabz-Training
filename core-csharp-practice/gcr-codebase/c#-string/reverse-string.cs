using System;

class Program
{
    static string ReverseString(string str)
    {
        string rev = "";
        for (int i = str.Length - 1; i >= 0; i--)
            rev += str[i];

        return rev;
    }

    static void Main()
    {
        Console.Write("Enter string: ");
        string input = Console.ReadLine();
        Console.WriteLine("Reversed String: " + ReverseString(input));
    }
}
