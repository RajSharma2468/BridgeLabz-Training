using System;

class HandshakesDirect
{
    static void Main()
    {
        Console.WriteLine("Enter number of students");
        int numberOfStudents = Convert.ToInt32(Console.ReadLine());

        int handshakes = (numberOfStudents * (numberOfStudents - 1)) / 2;
        Console.WriteLine("Possible handshakes = " + handshakes);
    }
}
