using System;
using System.Text;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < 100000; i++)
        {
            sb.Append("A");
        }

        sw.Stop();
        Console.WriteLine(sw.ElapsedMilliseconds + " ms");
    }
}
