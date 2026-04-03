using System;

#region Abstraction - Interface
public interface ILogManager
{
    void AddCallLog(string phoneNumber, string message);
    void SearchByKeyword(string keyword);
    void FilterByTime(DateTime startTime, DateTime endTime);
    void DisplayAllLogs();
}
#endregion

#region Base Class (Encapsulation)
public abstract class CallLog
{
    private string phoneNumber;
    private string message;
    private DateTime timeStamp;

    public string PhoneNumber
    {
        get { return phoneNumber; }
        protected set { phoneNumber = value; }
    }

    public string Message
    {
        get { return message; }
        protected set { message = value; }
    }

    public DateTime TimeStamp
    {
        get { return timeStamp; }
        protected set { timeStamp = value; }
    }

    protected CallLog(string phoneNumber, string message, DateTime timeStamp)
    {
        PhoneNumber = phoneNumber;
        Message = message;
        TimeStamp = timeStamp;
    }

    // Polymorphism
    public abstract void Display();
}
#endregion

#region Inheritance
public class ServiceCallLog : CallLog
{
    public ServiceCallLog(string phoneNumber, string message, DateTime timeStamp)
        : base(phoneNumber, message, timeStamp)
    {
    }

    public override void Display()
    {
        Console.WriteLine("Phone Number: " + PhoneNumber);
        Console.WriteLine("Message: " + Message);
        Console.WriteLine("Time: " + TimeStamp);
        Console.WriteLine("--------------------------------");
    }
}
#endregion

#region Manager Class
public class CallLogManager : ILogManager
{
    private CallLog[] callLogs;
    private int count;

    public CallLogManager(int size)
    {
        callLogs = new CallLog[size];
        count = 0;
    }

    public void AddCallLog(string phoneNumber, string message)
    {
        if (count >= callLogs.Length)
        {
            Console.WriteLine("Call log storage is full.");
            return;
        }

        callLogs[count] = new ServiceCallLog(phoneNumber, message, DateTime.Now);
        count++;
        Console.WriteLine("Call log added successfully.");
    }

    public void SearchByKeyword(string keyword)
    {
        bool found = false;
        Console.WriteLine("\nSEARCH RESULTS:");

        for (int i = 0; i < count; i++)
        {
            if (callLogs[i].Message.Contains(keyword))
            {
                callLogs[i].Display();
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("No logs found for keyword: " + keyword);
        }
    }

    public void FilterByTime(DateTime startTime, DateTime endTime)
    {
        bool found = false;
        Console.WriteLine("\nFILTERED LOGS:");

        for (int i = 0; i < count; i++)
        {
            if (callLogs[i].TimeStamp >= startTime &&
                callLogs[i].TimeStamp <= endTime)
            {
                callLogs[i].Display();
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("No logs found in this time range.");
        }
    }

    public void DisplayAllLogs()
    {
        if (count == 0)
        {
            Console.WriteLine("No call logs available.");
            return;
        }

        for (int i = 0; i < count; i++)
        {
            callLogs[i].Display();
        }
    }
}
#endregion

#region Main Program
class Program
{
    static void Main()
    {
        ILogManager manager = new CallLogManager(20);

        while (true)
        {
            Console.WriteLine("\nCUSTOMER SERVICE CALL LOG MANAGER");
            Console.WriteLine("1. Add Call Log");
            Console.WriteLine("2. Search by Keyword");
            Console.WriteLine("3. Filter by Time Range");
            Console.WriteLine("4. View All Logs");
            Console.WriteLine("5. Exit");
            Console.Write("Enter choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddLog(manager);
                    break;

                case 2:
                    SearchLog(manager);
                    break;

                case 3:
                    FilterLog(manager);
                    break;

                case 4:
                    manager.DisplayAllLogs();
                    break;

                case 5:
                    return;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }

    static void AddLog(ILogManager manager)
    {
        Console.Write("Enter phone number: ");
        string phone = Console.ReadLine();

        Console.Write("Enter message: ");
        string message = Console.ReadLine();

        manager.AddCallLog(phone, message);
    }

    static void SearchLog(ILogManager manager)
    {
        Console.Write("Enter keyword: ");
        string keyword = Console.ReadLine();

        manager.SearchByKeyword(keyword);
    }

    static void FilterLog(ILogManager manager)
    {
        Console.Write("Enter start time (yyyy-MM-dd HH:mm): ");
        DateTime start = DateTime.Parse(Console.ReadLine());

        Console.Write("Enter end time (yyyy-MM-dd HH:mm): ");
        DateTime end = DateTime.Parse(Console.ReadLine());

        manager.FilterByTime(start, end);
    }
}
#endregion
