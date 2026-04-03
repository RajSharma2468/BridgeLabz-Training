using System;
using System.IO;

class Program
{
    static void Main()
    {
        FileStream fs = new FileStream("sample.txt", FileMode.Open);
        StreamReader sr = new StreamReader(fs);

        int ch;
        while ((ch = sr.Read()) != -1)
        {
            Console.Write((char)ch);
        }

        sr.Close();
        fs.Close();
    }
}
