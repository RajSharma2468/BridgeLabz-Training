using System;

class Program
{
    static string FormatParagraph(string text)
    {
        string result = "";
        bool space = false;
        bool capital = true;

        for (int i = 0; i < text.Length; i++)
        {
            char ch = text[i];

            if (ch == ' ')
            {
                if (space)
                {
                    result = result + ch;
                    space = false;
                }
            }
            else if (ch == '.' || ch == '?' || ch == '!')
            {
                result = result + ch;
                result = result + ' ';
                capital = true;
                space = false;
            }
            else
            {
                if (capital && ch >= 'a' && ch <= 'z')
                {
                    ch = (char)(ch - 32);
                    capital = false;
                }
                else
                {
                    capital = false;
                }

                result = result + ch;
                space = true;
            }
        }

        return result;
    }

    static void Main()
    {
        Console.WriteLine("Enter paragraph:");
        string input = Console.ReadLine();

        string output = FormatParagraph(input);

        Console.WriteLine("Corrected Paragraph:");
        Console.WriteLine(output);
    }
}
