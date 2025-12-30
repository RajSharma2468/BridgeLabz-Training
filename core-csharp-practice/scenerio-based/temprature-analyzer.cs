using System;

class Program
{
    static void TempAnalyze(float[,] t)
    {
        int hot = 0, cold = 0;
        float h = -999, c = 999;

        for (int i = 0; i < 7; i++)
        {
            float s = 0;
            for (int j = 0; j < 24; j++) s += t[i, j];
            float a = s / 24;

            if (a > h) { h = a; hot = i; }
            if (a < c) { c = a; cold = i; }

            Console.WriteLine("Day " + (i + 1) + " Avg: " + a);
        }
        Console.WriteLine("Hot Day: " + (hot + 1));
        Console.WriteLine("Cold Day: " + (cold + 1));
    }

    static void ScoreAnalyze(int[] m, int n)
    {
        int s = 0, hi = m[0], lo = m[0];

        for (int i = 0; i < n; i++)
        {
            s += m[i];
            if (m[i] > hi) hi = m[i];
            if (m[i] < lo) lo = m[i];
        }

        float a = (float)s / n;
        Console.WriteLine("Avg: " + a);
        Console.WriteLine("High: " + hi);
        Console.WriteLine("Low: " + lo);

        for (int i = 0; i < n; i++)
            if (m[i] > a) Console.WriteLine(m[i]);
    }

    static void Main()
    {
        float[,] t = new float[7, 24];
        float v = 20;
        for (int i = 0; i < 7; i++)
            for (int j = 0; j < 24; j++) t[i, j] = v++;

        TempAnalyze(t);

        int n;
        if (!int.TryParse(Console.ReadLine(), out n) || n <= 0) return;

        int[] m = new int[n];
        for (int i = 0; i < n; i++)
        {
            int x;
            if (!int.TryParse(Console.ReadLine(), out x) || x < 0) i--;
            else m[i] = x;
        }
        ScoreAnalyze(m, n);
    }
}
