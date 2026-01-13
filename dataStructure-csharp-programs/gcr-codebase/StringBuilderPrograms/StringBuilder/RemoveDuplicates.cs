using System;
using System.Text;

class Program
{
    static void Main()
    {
        string input = "programming";
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < input.Length; i++)
        {
            bool found = false;

            for (int j = 0; j < result.Length; j++)
            {
                if (input[i] == result[j])
                {
                    found = true;
                    break;
                }
            }

            if (!found)
                result.Append(input[i]);
        }

        Console.WriteLine(result.ToString());
    }
}
