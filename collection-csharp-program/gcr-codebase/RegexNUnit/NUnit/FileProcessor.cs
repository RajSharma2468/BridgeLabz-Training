using System;
using System.IO;

class FileProcessor
{
    public void WriteToFile(string filename, string content)
    {
        File.WriteAllText(filename, content);
    }

    public string ReadFromFile(string filename)
    {
        return File.ReadAllText(filename);
    }
}

class Program
{
    static void Main()
    {
        FileProcessor fp = new FileProcessor();
        string file = "test.txt";

        fp.WriteToFile(file, "Hello File!");
        Console.WriteLine("File Content: " + fp.ReadFromFile(file));
    }
}
