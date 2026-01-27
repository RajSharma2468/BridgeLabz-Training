using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program {
    static void Main() {
        string text = "This is is a repeated repeated word test.";
        HashSet<string> repeated = new HashSet<string>();

        foreach (Match m in Regex.Matches(text, @"\b(\w+)\s+\1\b"))
            repeated.Add(m.Groups[1].Value);

        foreach (string word in repeated)
            Console.WriteLine(word);
    }
}
