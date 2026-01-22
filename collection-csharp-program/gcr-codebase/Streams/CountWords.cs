using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class WordFrequency
{
    static void Main()
    {
        Dictionary<string, int> words = new Dictionary<string, int>();

        using (StreamReader reader = new StreamReader("text.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] data = line.Split(' ', ',', '.', '!', '?');
                foreach (string word in data)
                {
                    if (word == "")
                        continue;

                    string key = word.ToLower();

                    if (words.ContainsKey(key))
                        words[key]++;
                    else
                        words.Add(key, 1);
                }
            }
        }

        foreach (var item in words.OrderByDescending(x => x.Value).Take(5))
        {
            Console.WriteLine(item.Key + " : " + item.Value);
        }
    }
}
