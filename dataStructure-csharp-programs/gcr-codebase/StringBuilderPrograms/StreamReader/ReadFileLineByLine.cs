using System;
using System.IO;

class Program
{
    static void Main()
    {
        StreamReader sr = new StreamReader("sample.txt");
        string line;

        while ((line = sr.ReadLine()) != null)
        {
            Console.WriteLine(line);
        }

        sr.Close();
    }
}
