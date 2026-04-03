using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program {
    static void Main() {
        string text = "Contact us at support@example.com and info@company.org";
        List<string> emails = new List<string>();

        foreach (Match m in Regex.Matches(text, @"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}"))
            emails.Add(m.Value);

        foreach (string email in emails)
            Console.WriteLine(email);
    }
}
