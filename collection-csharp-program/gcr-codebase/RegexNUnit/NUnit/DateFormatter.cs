using System;

class DateFormatter
{
    public string FormatDate(string inputDate)
    {
        DateTime dt;
        if (DateTime.TryParse(inputDate, out dt))
            return dt.ToString("dd-MM-yyyy");
        else
            return "Invalid Date";
    }
}

class Program
{
    static void Main()
    {
        DateFormatter df = new DateFormatter();
        Console.WriteLine(df.FormatDate("2025-01-27"));
    }
}
