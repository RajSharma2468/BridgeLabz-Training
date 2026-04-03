using System;

class Program
{
    static Random r = new Random();

    static void Main()
    {
        Console.Write("Players (2-4): ");
        int n = Convert.ToInt32(Console.ReadLine());

        string[] p = new string[n];
        int[] pos = new int[n];

        int[] from = {3,5,11,20,27,21,17,19};
        int[] to   = {22,8,26,29,1,9,4,7};

        for (int i = 0; i < n; i++)
        {
            Console.Write("Name " + (i + 1) + ": ");
            p[i] = Console.ReadLine();
        }

        while (true)
        {
            for (int i = 0; i < n; i++)
            {
                int dice = r.Next(1, 7);
                int old = pos[i];
                int next = old + dice;

                if (next > 100) continue;

                for (int j = 0; j < from.Length; j++)
                {
                    if (from[j] == next)
                    {
                        switch (to[j] > from[j] ? 1 : 0)
                        {
                            case 1:
                            case 0:
                                next = to[j];
                                break;
                        }
                    }
                }

                pos[i] = next;
                Console.WriteLine(p[i] + ": " + dice + " | " + old + " -> " + next);

                if (next == 100)
                {
                    Console.WriteLine(p[i] + " WINS!");
                    return;
                }
            }
        }
    }
}
