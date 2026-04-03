using System;
using System.IO;

class UpperLower
{
    static void Main()
    {
        try
        {
            using (BufferedStream bs = new BufferedStream(File.OpenRead("input.txt")))
            using (StreamReader reader = new StreamReader(bs))
            using (StreamWriter writer = new StreamWriter("output.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    writer.WriteLine(line.ToLower()); 
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
