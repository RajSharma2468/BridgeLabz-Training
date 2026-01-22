using System;
using System.IO;
using System.IO.Pipes;
using System.Threading;

class PipeDemo
{
    static void Main()
    {
        AnonymousPipeServerStream server = new AnonymousPipeServerStream(PipeDirection.Out);
        AnonymousPipeClientStream client = new AnonymousPipeClientStream(PipeDirection.In, server.ClientSafePipeHandle);

        Thread writer = new Thread(() =>
        {
            using (StreamWriter sw = new StreamWriter(server))
            {
                sw.AutoFlush = true;
                sw.WriteLine("Hello from writer thread");
            }
        });

        Thread reader = new Thread(() =>
        {
            using (StreamReader sr = new StreamReader(client))
            {
                Console.WriteLine(sr.ReadLine());
            }
        });

        writer.Start();
        reader.Start();

        writer.Join();
        reader.Join();
    }
}
