using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program {
    static void Main() {
        string text = "Visit https://www.google.com and http://example.org";
        List<string> links = new List<string>();

        foreach (Match m in Regex.Matches(text, @"https?://[^\s]+"))
            links.Add(m.Value);

        foreach (string link in links)
            Console.WriteLine(link);
    }
}
