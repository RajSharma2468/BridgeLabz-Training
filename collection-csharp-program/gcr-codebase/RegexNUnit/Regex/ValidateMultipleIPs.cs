using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program {
    static void Main() {
        List<string> ips = new List<string> { "192.168.1.1", "256.100.50.0", "10.0.0.5" };
        string pattern = @"^((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)\.){3}(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)$";

        foreach (string ip in ips) {
            string result = Regex.IsMatch(ip, pattern) ? "Valid" : "Invalid";
            Console.WriteLine(ip + " → " + result);
        }
    }
}
