using System;

class Program
{
    static void Main()
    {
        SmartCheckoutMain checkout = new SmartCheckoutMain();

        while (true)
        {
            SmartCheckoutMenu.Show();
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.WriteLine("Enter customer name");
                string name = Console.ReadLine();
                Customer customer = new Customer(name);

                Console.WriteLine("Enter number of items");
                int count = int.Parse(Console.ReadLine());

                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine("Enter item name");
                    string itemName = Console.ReadLine();
                    customer.Items.Enqueue(new Item(itemName));
                }

                checkout.AddCustomer(customer);
            }
            else if (choice == 2)
            {
                checkout.ProcessCustomer();
            }
            else
            {
                break;
            }
        }
    }
}
