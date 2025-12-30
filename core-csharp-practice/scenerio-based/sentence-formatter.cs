using System;

class Program
{
    static string Format(string s)
    {
        if (s == null) return "";

        string r = "";
        bool cap = true, sp = false;

        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];

            if (c == ' ')
            {
                if (!sp) { r += c; sp = true; }
            }
            else
            {
                sp = false;
                if (cap && c >= 'a' && c <= 'z')
                {
                    r += (char)(c - 32);
                    cap = false;
                }
                else r += c;

                if (c == '.' || c == '?' || c == '!')
                {
                    r += ' ';
                    cap = true;
                    sp = true;
                }
            }
        }
        return r;
    }

    static void Analyze(string s, string o, string n)
    {
        string w = "", outp = "", longW = "";
        int count = 0;

        for (int i = 0; i <= s.Length; i++)
        {
            char c = (i == s.Length) ? ' ' : s[i];

            if (c != ' ') w += c;
            else if (w.Length > 0)
            {
                count++;
                if (w.Length > longW.Length) longW = w;
                outp += Same(w, o) ? n + " " : w + " ";
                w = "";
            }
        }

        Console.WriteLine(count);
        Console.WriteLine(longW);
        Console.WriteLine(outp);
    }

    static bool Same(string a, string b)
    {
        if (a.Length != b.Length) return false;

        for (int i = 0; i < a.Length; i++)
        {
            char x = a[i], y = b[i];
            if (x >= 'A' && x <= 'Z') x = (char)(x + 32);
            if (y >= 'A' && y <= 'Z') y = (char)(y + 32);
            if (x != y) return false;
        }
        return true;
    }

    static void Main()
    {
        string s = Console.ReadLine();
        string f = Format(s);
        Console.WriteLine(f);

        string oldW = Console.ReadLine();
        string newW = Console.ReadLine();

        Analyze(f, oldW, newW);
    }
}
