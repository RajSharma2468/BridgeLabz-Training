using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program {
    static void Main() {
        List<string> cards = new List<string> { "4123456789012345", "5123456789012345", "3123456789012345" };
        string visa = @"^4\d{15}$";
        string master = @"^5\d{15}$";

        foreach (string card in cards) {
            if (Regex.IsMatch(card, visa))
                Console.WriteLine(card + " → Visa");
            else if (Regex.IsMatch(card, master))
                Console.WriteLine(card + " → MasterCard");
            else
                Console.WriteLine(card + " → Invalid");
        }
    }
}
