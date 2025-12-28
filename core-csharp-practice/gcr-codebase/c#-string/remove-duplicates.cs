using System;

class Program
{
    static string RemoveDuplicates(string str)
    {
        string result = "";

        for (int i = 0; i < str.Length; i++)
        {
            if (!result.Contains(str[i].ToString()))
                result += str[i];
        }
        return result;
    }

    static void Main()
    {
        Console.Write("Enter string: ");
        string input = Console.ReadLine();
        Console.WriteLine("After Removing Duplicates: " + RemoveDuplicates(input));
    }
}
