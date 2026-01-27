using System;
using System.Text.RegularExpressions;

class Program {
    static void Main() {
        string text = "This   is    an   example     with multiple spaces.";
        string result = Regex.Replace(text, @"\s+", " ");
        Console.WriteLine(result);
    }
}
