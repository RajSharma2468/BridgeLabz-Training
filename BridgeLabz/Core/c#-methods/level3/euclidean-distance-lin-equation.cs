using System;

class GeometryProgram
{
    static double CalculateDistance(int x1, int y1, int x2, int y2)
    {
        int dx = x2 - x1;
        int dy = y2 - y1;
        return Math.Sqrt(dx * dx + dy * dy);
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

        double distance = CalculateDistance(x1, y1, x2, y2);

        Console.WriteLine("Distance between points = " + distance);

        if (x1 == x2 && y1 == y2)
            Console.WriteLine("Points overlap");
        else
            Console.WriteLine("Line equation exists");
    }
}
