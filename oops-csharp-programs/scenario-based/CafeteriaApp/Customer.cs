using System;
namespace CafeteriaApp
{
    class Customer
    {
        
        public void LoggedAsCustomer()
        {
            Console.WriteLine("Customer Logged In Successfully!");
            BrowseMenu();
        }
        private void BrowseMenu()
        {
            while (true)
            {
                Console.WriteLine("\nCustomer Menu:");
                Console.WriteLine("1. View Menu");
                Console.WriteLine("2. Place Order");
                Console.WriteLine("3. Logout");
                Console.Write("Choose an option: ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        ViewMenu();
                        break;
                    case 2:
                        PlaceOrder();
                        break;
                    case 3:
                        Console.WriteLine("Logging out...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        private void ViewMenu()
        {
            Console.WriteLine("\nCafeteria Menu:");
            for (int i = 0; i < Program.Menu.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Program.Menu[i]} - Rs.{Program.Amount[i]}");
            }
        }
        private void PlaceOrder()
        {
            ViewMenu();
            Console.WriteLine("\nEnter the item number to place an order:");
            int itemNumber = int.Parse(Console.ReadLine());
            if (itemNumber < 1 || itemNumber > Program.Menu.Length)
            {
                Console.WriteLine("Invalid item number. Please try again.");
                return;
            }
            Console.WriteLine($"You have ordered: {Program.Menu[itemNumber - 1]} for Rs.{Program.Amount[itemNumber - 1]}");
        }
    }
}