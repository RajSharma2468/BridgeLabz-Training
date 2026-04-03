using System;
using System.IO;
using System.Diagnostics;

class BufferedFileCopy
{
    static void Main()
    {
        string source = "largefile.dat";
        string destBuffered = "bufferedCopy.dat";
        string destNormal = "normalCopy.dat";

        byte[] buffer = new byte[4096];

        // Normal FileStream
        Stopwatch sw1 = Stopwatch.StartNew();
        using (FileStream fsRead = new FileStream(source, FileMode.Open))
        using (FileStream fsWrite = new FileStream(destNormal, FileMode.Create))
        {
            int bytesRead;
            while ((bytesRead = fsRead.Read(buffer, 0, buffer.Length)) > 0)
            {
                fsWrite.Write(buffer, 0, bytesRead);
            }
        }
        sw1.Stop();

        // BufferedStream
        Stopwatch sw2 = Stopwatch.StartNew();
        using (FileStream fsRead = new FileStream(source, FileMode.Open))
        using (BufferedStream bsRead = new BufferedStream(fsRead))
        using (FileStream fsWrite = new FileStream(destBuffered, FileMode.Create))
        using (BufferedStream bsWrite = new BufferedStream(fsWrite))
        {
            int bytesRead;
            while ((bytesRead = bsRead.Read(buffer, 0, buffer.Length)) > 0)
            {
                bsWrite.Write(buffer, 0, bytesRead);
            }
        }
        sw2.Stop();

        Console.WriteLine("Normal Stream Time: " + sw1.ElapsedMilliseconds + " ms");
        Console.WriteLine("Buffered Stream Time: " + sw2.ElapsedMilliseconds + " ms");
    }
}
