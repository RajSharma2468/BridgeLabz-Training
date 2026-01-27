using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program {
    static void Main() {
        string text = "Events: 12/05/2023, 15/08/2024, 29/02/2020";
        List<string> dates = new List<string>();

        foreach (Match m in Regex.Matches(text, @"\b\d{2}/\d{2}/\d{4}\b"))
            dates.Add(m.Value);

        foreach (string date in dates)
            Console.WriteLine(date);
    }
}
