using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<string, double> cart = new Dictionary<string, double>();
        LinkedList<string> order = new LinkedList<string>();
        SortedDictionary<double, string> sortedItems = new SortedDictionary<double, string>();

        Console.WriteLine("Enter number of items");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Enter Product Name");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Price");
            double price = double.Parse(Console.ReadLine());

            cart[name] = price;
            order.AddLast(name);
            sortedItems[price] = name;
        }

        Console.WriteLine("Cart Items In Order");
        foreach (string item in order)
            Console.WriteLine(item + " " + cart[item]);

        Console.WriteLine("Items Sorted By Price");
        foreach (var item in sortedItems)
            Console.WriteLine(item.Value + " " + item.Key);
    }
}
