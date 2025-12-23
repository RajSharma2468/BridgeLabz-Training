using System;

class ClockAngle
{
    static void Main()
    {
        Console.Write("Enter hour: ");
        int hour = int.Parse(Console.ReadLine());

        Console.Write("Enter minutes: ");
        int minutes = int.Parse(Console.ReadLine());

        double hourAngle = (hour % 12) * 30 + (minutes * 0.5);
        double minuteAngle = minutes * 6;

        double angle = Math.Abs(hourAngle - minuteAngle);
        double finalAngle = Math.Min(angle, 360 - angle);

        Console.WriteLine("Angle between hands at " + hour + ":" + minutes.ToString("D2") + " is "  + finalAngle + " degrees");
    }
}
