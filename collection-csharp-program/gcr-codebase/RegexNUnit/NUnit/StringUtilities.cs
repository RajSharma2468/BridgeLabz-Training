using System;

class StringUtils
{
    public string Reverse(string str)
    {
        char[] arr = str.ToCharArray();
        Array.Reverse(arr);
        return new string(arr);
    }

    public bool IsPalindrome(string str)
    {
        string rev = Reverse(str);
        return str.ToLower() == rev.ToLower();
    }

    public string ToUpperCase(string str)
    {
        return str.ToUpper();
    }
}

class Program
{
    static void Main()
    {
        StringUtils s = new StringUtils();
        Console.WriteLine("Reverse: " + s.Reverse("hello"));
        Console.WriteLine("Palindrome: " + s.IsPalindrome("madam"));
        Console.WriteLine("Upper: " + s.ToUpperCase("csharp"));
    }
}
