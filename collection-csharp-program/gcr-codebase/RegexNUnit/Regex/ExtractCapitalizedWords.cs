using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program {
    static void Main() {
        string text = "The Eiffel Tower is in Paris and the Statue of Liberty is in New York.";
        List<string> words = new List<string>();

        foreach (Match m in Regex.Matches(text, @"\b[A-Z][a-z]*\b"))
            words.Add(m.Value);

        foreach (string word in words)
            Console.WriteLine(word);
    }
}
