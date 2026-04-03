using System;

class Program
{
    static bool IsAnagram(string s1, string s2)
    {
        if (s1.Length != s2.Length)
            return false;

        int[] count = new int[256];

        for (int i = 0; i < s1.Length; i++)
        {
            count[s1[i]]++;
            count[s2[i]]--;
        }

        for (int i = 0; i < 256; i++)
        {
            if (count[i] != 0)
                return false;
        }
        return true;
    }

    static void Main()
    {
        Console.Write("Enter first string: ");
        string s1 = Console.ReadLine();

        Console.Write("Enter second string: ");
        string s2 = Console.ReadLine();

        if (IsAnagram(s1, s2))
            Console.WriteLine("Strings are Anagrams");
        else
            Console.WriteLine("Strings are NOT Anagrams");
    }
}
