using System;
using System.Text;
using System.IO;

class Program
{
    static string Encrypt(string text)
    {
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(text));
    }

    static string Decrypt(string cipher)
    {
        return Encoding.UTF8.GetString(Convert.FromBase64String(cipher));
    }

    static void Main()
    {
        string salary = "50000";
        string encrypted = Encrypt(salary);

        File.WriteAllText("secure.csv", encrypted);

        string read = File.ReadAllText("secure.csv");
        Console.WriteLine("Decrypted Salary: " + Decrypt(read));
    }
}
