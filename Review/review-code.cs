using System;

class ClockAngle
{
    static void Main()
    {
        int hour, minute;

        Console.Write("Enter hour: ");
        hour = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter minute: ");
        minute = Convert.ToInt32(Console.ReadLine());

        
        if (hour >= 12)
            hour = hour - 12;

        
        int hourAngle = (hour * 30) + (minute * 30 / 60);
        int minuteAngle = minute * 6;

        int angle;

        if (hourAngle > minuteAngle)
            angle = hourAngle - minuteAngle;
        else
            angle = minuteAngle - hourAngle;

        Console.WriteLine("Angle between clock hands is " + angle + " degrees");
    }
}
