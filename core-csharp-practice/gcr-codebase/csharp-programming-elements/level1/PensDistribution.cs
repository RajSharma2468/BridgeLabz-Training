using System;

class Program
{
    static void Main()
    {
        int pens = 14;
        int students = 3;

        int perStudent = pens / students;
        int remaining = pens % students;

        Console.WriteLine("The Pen Per Student is " + perStudent +
                          " and the remaining pen not distributed is " + remaining);
    }
}
