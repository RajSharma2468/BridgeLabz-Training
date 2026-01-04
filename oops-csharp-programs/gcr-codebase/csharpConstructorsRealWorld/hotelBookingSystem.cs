using System;

class HotelBooking
{
    public string guestName;
    public string roomType;
    public int nights;

    // Default Constructor
    public HotelBooking()
    {
        guestName = "Guest";
        roomType = "Standard";
        nights = 1;
    }

    // Parameterized Constructor
    public HotelBooking(string guestName, string roomType, int nights)
    {
        this.guestName = guestName;
        this.roomType = roomType;
        this.nights = nights;
    }

    // Copy Constructor
    public HotelBooking(HotelBooking hb)
    {
        guestName = hb.guestName;
        roomType = hb.roomType;
        nights = hb.nights;
    }

    public void Display()
    {
        Console.WriteLine("Guest Name: " + guestName);
        Console.WriteLine("Room Type: " + roomType);
        Console.WriteLine("Nights: " + nights);
    }
}

class Program
{
    static void Main()
    {
        HotelBooking b1 = new HotelBooking("Amit", "Deluxe", 3);
        HotelBooking b2 = new HotelBooking(b1);

        b2.Display();
    }
}
