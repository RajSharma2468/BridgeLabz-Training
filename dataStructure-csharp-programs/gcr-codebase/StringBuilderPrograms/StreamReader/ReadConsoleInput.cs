using System;
using System.IO;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        StreamWriter sw = new StreamWriter("output.txt");

        sw.Write(input);
        sw.Close();
    }
}
