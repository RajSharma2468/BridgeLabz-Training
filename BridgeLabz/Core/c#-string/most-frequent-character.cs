using System;

class Program
{
    static char MostFrequentChar(string str)
    {
        int maxCount = 0;
        char result = str[0];

        for (int i = 0; i < str.Length; i++)
        {
            int count = 0;
            for (int j = 0; j < str.Length; j++)
            {
                if (str[i] == str[j])
                    count++;
            }

            if (count > maxCount)
            {
                maxCount = count;
                result = str[i];
            }
        }
        return result;
    }

    static void Main()
    {
        Console.Write("Enter string: ");
        string input = Console.ReadLine();
        Console.WriteLine("Most Frequent Character: " + MostFrequentChar(input));
    }
}
