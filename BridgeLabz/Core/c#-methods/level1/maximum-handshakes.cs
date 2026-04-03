using System;

class Handshakes
{
    static int CalculateHandshakes(int n)
    {
        return (n * (n - 1)) / 2;
    }

    static void Main()
    {
        Console.WriteLine("Enter number of students");
        int students = Convert.ToInt32(Console.ReadLine());

        int result = CalculateHandshakes(students);
        Console.WriteLine("Maximum handshakes = " + result);
    }
}
