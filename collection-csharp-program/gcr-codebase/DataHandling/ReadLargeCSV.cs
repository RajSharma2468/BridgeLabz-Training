using System;
using System.IO;

class Program
{
    static void Main()
    {
        int count = 0;

        using (StreamReader sr = new StreamReader("large.csv"))
        {
            while (!sr.EndOfStream)
            {
                for (int i = 0; i < 100 && !sr.EndOfStream; i++)
                {
                    sr.ReadLine();
                    count++;
                }
                Console.WriteLine("Processed " + count + " records");
            }
        }
    }
}
