using System;

class CircularTour
{
    static int FindStart(int[] petrol, int[] dist)
    {
        int start = 0, balance = 0, deficit = 0;

        for (int i = 0; i < petrol.Length; i++)
        {
            balance += petrol[i] - dist[i];
            if (balance < 0)
            {
                deficit += balance;
                start = i + 1;
                balance = 0;
            }
        }

        return (balance + deficit >= 0) ? start : -1;
    }

    static void Main()
    {
        int[] petrol = { 4, 6, 7, 4 };
        int[] dist = { 6, 5, 3, 5 };

        Console.WriteLine(FindStart(petrol, dist));
    }
}
