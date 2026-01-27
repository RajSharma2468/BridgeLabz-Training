using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program {
    static void Main() {
        string text = "I love Java, Python, and JavaScript, but I haven't tried Go yet.";
        List<string> langs = new List<string>();

        foreach (Match m in Regex.Matches(text, @"\b(Java|Python|JavaScript|Go|C#|C\+\+)\b"))
            langs.Add(m.Value);

        foreach (string lang in langs)
            Console.WriteLine(lang);
    }
}
