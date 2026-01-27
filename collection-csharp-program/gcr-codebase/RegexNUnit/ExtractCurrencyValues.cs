using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program {
    static void Main() {
        string text = "The price is $45.99, and the discount is $ 10.50.";
        List<string> money = new List<string>();

        foreach (Match m in Regex.Matches(text, @"\$\s?\d+(\.\d{2})?"))
            money.Add(m.Value);

        foreach (string amount in money)
            Console.WriteLine(amount);
    }
}
