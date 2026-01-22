using System;
using System.IO;

class FileReadWrite
{
    static void Main()
    {
        string sourceFile = "source.txt";
        string destinationFile = "destination.txt";

        try
        {
            if (!File.Exists(sourceFile))
            {
                Console.WriteLine("Source file does not exist.");
                return;
            }

            using (FileStream fsRead = new FileStream(sourceFile, FileMode.Open, FileAccess.Read))
            using (FileStream fsWrite = new FileStream(destinationFile, FileMode.Create, FileAccess.Write))
            {
                int data;
                while ((data = fsRead.ReadByte()) != -1)
                {
                    fsWrite.WriteByte((byte)data);
                }
            }

            Console.WriteLine("File copied successfully.");
        }
        catch (IOException ex)
        {
            Console.WriteLine("IO Error: " + ex.Message);
        }
    }
}
