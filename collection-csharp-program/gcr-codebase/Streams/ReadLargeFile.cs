using System;
using System.IO;

class LargeFileRead
{
    static void Main()
    {
        using (StreamReader reader = new StreamReader("large.log"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.ToLower().Contains("error"))
                {
                    Console.WriteLine(line);
                }
            }
        }
    }
}
