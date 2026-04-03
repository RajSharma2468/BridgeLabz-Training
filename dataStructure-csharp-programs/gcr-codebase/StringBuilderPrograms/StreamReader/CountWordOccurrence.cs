using System;
using System.IO;

class Program
{
    static void Main()
    {
        StreamReader sr = new StreamReader("sample.txt");
        string word = "hello";
        int count = 0;
        string line;

        while ((line = sr.ReadLine()) != null)
        {
            string temp = "";

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] != ' ')
                    temp += line[i];
                else
                {
                    if (temp == word) count++;
                    temp = "";
                }
            }
            if (temp == word) count++;
        }

        sr.Close();
        Console.WriteLine(count);
    }
}
