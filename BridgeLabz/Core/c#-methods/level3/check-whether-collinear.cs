using System;

class CollinearPoints
{
    static bool AreCollinear(int x1, int y1, int x2, int y2, int x3, int y3)
    {
        int value = x1 * (y2 - y3) +
                    x2 * (y3 - y1) +
                    x3 * (y1 - y2);

        if (value == 0)
            return true;
        else
            return false;
    }

    static void Main()
    {
        Console.Write("Enter x1: ");
        int x1 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter y1: ");
        int y1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter x2: ");
        int x2 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter y2: ");
        int y2 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter x3: ");
        int x3 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter y3: ");
        int y3 = Convert.ToInt32(Console.ReadLine());

        bool result = AreCollinear(x1, y1, x2, y2, x3, y3);

        if (result)
            Console.WriteLine("The points are collinear");
        else
            Console.WriteLine("The points are NOT collinear");
    }
}
