using System;
using System.Buffers;
namespace CafeteriaApp
{
    

    class Program
    {
        
        public static string[] Menu =
        {
            "Espresso",
            "Cappuccino",
            "Latte",
            "Americano",
            "Masala Chai",
            "Cold Coffee",
            "Veg Sandwich",
            "Cheese Sandwich",
            "French Fries",
            "Chocolate Brownie"
        };
        public static int[] Amount = { 120, 150, 160, 140, 60, 130, 100, 120, 90, 110 };
        static Program()
        {
            Console.WriteLine("\n===========================Welcome to the Cafeteria Application!==========================\n");
        }

        static void Main()
        {
            Owner owner = new Owner();
            Customer customer = new Customer();
            while (true)
            {
                Console.WriteLine("\n<=================Home Page===========================>\n");
                Console.WriteLine("\nPress 1. For Owner Login\nPress 2. For Customer Login\nPress 3. For Exit");
                int mode = int.Parse(Console.ReadLine());
                if (mode == 1) owner.LoggedAsOwner();
                else if (mode == 2) customer.LoggedAsCustomer();
                else if (mode == 3) return;
                else { Console.WriteLine("-----------Invalid Input------"); return; }
            }
        }

    }
}