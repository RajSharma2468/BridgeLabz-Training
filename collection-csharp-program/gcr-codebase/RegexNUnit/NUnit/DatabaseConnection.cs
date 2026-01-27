using System;

class DatabaseConnection
{
    public void Connect()
    {
        Console.WriteLine("Database Connected");
    }

    public void Disconnect()
    {
        Console.WriteLine("Database Disconnected");
    }
}

class Program
{
    static void Main()
    {
        DatabaseConnection db = new DatabaseConnection();
        db.Connect();

        Console.WriteLine("Performing DB operations...");

        db.Disconnect();
    }
}
