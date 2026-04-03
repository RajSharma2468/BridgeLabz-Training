using System;

class Program
{
    static int CountSubstring(string str, string sub)
    {
        int count = 0;

        for (int i = 0; i <= str.Length - sub.Length; i++)
        {
            if (str.Substring(i, sub.Length) == sub)
                count++;
        }
        return count;
    }

    static void Main()
    {
        Console.Write("Enter main string: ");
        string mainStr = Console.ReadLine();

        Console.Write("Enter substring: ");
        string subStr = Console.ReadLine();

        Console.WriteLine("Occurrences: " + CountSubstring(mainStr, subStr));
    }
}
