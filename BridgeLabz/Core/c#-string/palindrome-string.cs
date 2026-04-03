using System;

class Program
{
    static bool IsPalindrome(string str)
    {
        int start = 0;
        int end = str.Length - 1;

        while (start < end)
        {
            if (str[start] != str[end])
                return false;

            start++;
            end--;
        }
        return true;
    }

    static void Main()
    {
        Console.Write("Enter string: ");
        string input = Console.ReadLine();

        if (IsPalindrome(input))
            Console.WriteLine("Palindrome String");
        else
            Console.WriteLine("Not a Palindrome");
    }
}
