using System;
namespace CafeteriaApp
{
    class Owner
    
    {
        private string ownerName = "Ashish";
        private string ownerPassword = "Ashish@123";
        public void LoggedAsOwner()
        {
            Console.WriteLine("\nEnter Owner Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Owner Password:");
            string password = Console.ReadLine();
            if (name == ownerName && password == ownerPassword)
            {
                Console.WriteLine("Owner Logged In Successfully!");
                ManageMenu();
            }
            else
            {
                Console.WriteLine("Invalid Owner Credentials!");
                return;
            }

        }


        private void ManageMenu()
        {
            while (true)
            {
                Console.WriteLine("\nOwner Menu:");
                Console.WriteLine("1. View Menu");
                Console.WriteLine("2. Add Item");
                Console.WriteLine("3. Remove Item");
                Console.WriteLine("4. Logout");
                Console.Write("Choose an option: ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        ViewMenu();
                        break;
                    case 2:
                        AddItem();
                        break;
                    case 3:
                        RemoveItem();
                        break;
                    case 4:
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
            Console.WriteLine("\nCurrent Menu:");
            for (int i = 0; i < Program.Menu.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Program.Menu[i]} - {Program.Amount[i]}");
            }
        }
        private void AddItem()
        {
            Console.Write("Enter item name to add: ");
            string itemName = Console.ReadLine();
            Console.Write("Enter item price: ");
            int itemPrice = int.Parse(Console.ReadLine());
            Array.Resize(ref Program.Menu, Program.Menu.Length + 1);
            Array.Resize(ref Program.Amount, Program.Amount.Length + 1);
            Program.Menu[^1] = itemName;
            Program.Amount[^1] = itemPrice;
            Console.WriteLine($"Item '{itemName}' added successfully!");
        }
        private void RemoveItem()
        {
            Console.Write("Enter item number to remove: ");
            int itemNumber = int.Parse(Console.ReadLine());
            if (itemNumber < 1 || itemNumber > Program.Menu.Length)
            {
                Console.WriteLine("Invalid item number.");
                return;
            }
            string itemName = Program.Menu[itemNumber - 1];
            for (int i = itemNumber - 1; i < Program.Menu.Length - 1; i++)
            {
                Program.Menu[i] = Program.Menu[i + 1];
                Program.Amount[i] = Program.Amount[i + 1];
            }
            Array.Resize(ref Program.Menu, Program.Menu.Length - 1);
            Array.Resize(ref Program.Amount, Program.Amount.Length - 1);
            Console.WriteLine($"Item '{itemName}' removed successfully!");
        }
    }
}