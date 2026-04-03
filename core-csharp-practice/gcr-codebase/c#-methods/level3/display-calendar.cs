using System;

class CalendarProgram
{
    static void Main()
    {
        Console.Write("Enter month (1-12): ");
        int month = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter year: ");
        int year = Convert.ToInt32(Console.ReadLine());

        DateTime date = new DateTime(year, month, 1);

        Console.WriteLine("\nSun Mon Tue Wed Thu Fri Sat");

        int startDay = (int)date.DayOfWeek;

        for (int i = 0; i < startDay; i++)
            Console.Write("    ");

        int daysInMonth = DateTime.DaysInMonth(year, month);

        for (int day = 1; day <= daysInMonth; day++)
        {
            Console.Write(day.ToString().PadLeft(3) + " ");
            if ((day + startDay) % 7 == 0)
                Console.WriteLine();
        }
    }
}
