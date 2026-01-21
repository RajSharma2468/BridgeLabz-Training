using System;
using System.Collections.Generic;

class SmartCheckoutMain : ISmartCheckout
{
    Queue<Customer> customerQueue = new Queue<Customer>();
    SmartCheckoutUtility utility = new SmartCheckoutUtility();

    public void AddCustomer(Customer customer)
    {
        customerQueue.Enqueue(customer);
        Console.WriteLine("Customer added");
    }

    public void ProcessCustomer()
    {
        if (customerQueue.Count == 0)
        {
            Console.WriteLine("No customer in queue");
            return;
        }

        Customer customer = customerQueue.Dequeue();
        int total = 0;

        Console.WriteLine("Billing for " + customer.Name);

        while (customer.Items.Count > 0)
        {
            Item item = customer.Items.Dequeue();

            if (utility.StockMap.ContainsKey(item.ItemName)
                && utility.StockMap[item.ItemName] > 0)
            {
                total = total + utility.PriceMap[item.ItemName];
                utility.StockMap[item.ItemName] = utility.StockMap[item.ItemName] - 1;
                Console.WriteLine(item.ItemName + " purchased");
            }
            else
            {
                Console.WriteLine(item.ItemName + " not available");
            }
        }

        Console.WriteLine("Total amount " + total);
    }
}
