using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program {
    static void Main() {
        List<string> ssns = new List<string> { "123-45-6789", "123456789" };
        string pattern = @"^\d{3}-\d{2}-\d{4}$";

        foreach (string ssn in ssns) {
            string result = Regex.IsMatch(ssn, pattern) ? "Valid" : "Invalid";
            Console.WriteLine(ssn + " → " + result);
        }
    }
}
