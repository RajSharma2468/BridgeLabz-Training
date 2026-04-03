using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter number of students: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int handshakes = (n * (n - 1)) / 2;

        Console.WriteLine("The maximum number of handshakes is " + handshakes);
    }
}
