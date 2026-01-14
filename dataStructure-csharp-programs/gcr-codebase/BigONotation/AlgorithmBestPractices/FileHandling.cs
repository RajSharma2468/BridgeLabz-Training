using System;
using System.IO;

class Program
{
    static void Main()
    {
        FileStream fs = new FileStream("sample.txt", FileMode.Open);
        byte[] buffer = new byte[1024];

        while (fs.Read(buffer, 0, buffer.Length) > 0)
        {
            // process data
        }

        fs.Close();
        Console.WriteLine("File read completed");
    }
}
