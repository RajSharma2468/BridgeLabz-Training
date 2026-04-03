using System;
using System.Text.RegularExpressions;

class PasswordValidator
{
    public bool IsValid(string password)
    {
        if (password.Length < 8) return false;
        if (!Regex.IsMatch(password, "[A-Z]")) return false;
        if (!Regex.IsMatch(password, "[0-9]")) return false;
        return true;
    }
}

class Program
{
    static void Main()
    {
        PasswordValidator pv = new PasswordValidator();
        Console.WriteLine("Password valid: " + pv.IsValid("Test1234"));
    }
}
