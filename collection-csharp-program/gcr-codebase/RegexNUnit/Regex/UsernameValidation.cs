using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program {
    static void Main() {
        List<string> usernames = new List<string> { "user_123", "123user", "us", "Valid_Name1" };
        string pattern = @"^[A-Za-z][A-Za-z0-9_]{4,14}$";

        foreach (string user in usernames) {
            string result = Regex.IsMatch(user, pattern) ? "Valid" : "Invalid";
            Console.WriteLine(user + " → " + result);
        }
    }
}
