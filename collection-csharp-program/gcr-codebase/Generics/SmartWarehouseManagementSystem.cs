using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Smart Warehouse Management System ===\n");

        // Step 1: Initialize warehouse items
        List<string> itemNames = new List<string> 
        { 
            "Laptop", "Mobile", "Tablet", "Rice", "Wheat", "Sugar", "Chair", "Table", "Headphones" 
        };

        List<string> itemCategories = new List<string> 
        { 
            "Electronics", "Electronics", "Electronics", 
            "Groceries", "Groceries", "Groceries", 
            "Furniture", "Furniture", "Electronics" 
        };

        List<int> itemQuantities = new List<int> 
        { 
            10, 25, 15, 50, 100, 80, 20, 15, 30 
        };

        List<double> itemPrices = new List<double> 
        { 
            55000, 15000, 12000, 1500, 1200, 1000, 7500, 5000, 2000 
        };

        // Step 2: User can add new warehouse item
        Console.WriteLine("Do you want to add a new warehouse item? (yes/no)");
        string response = Console.ReadLine().ToLower();
        if (response == "yes")
        {
            Console.Write("Enter Item Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Category: ");
            string category = Console.ReadLine();
            Console.Write("Enter Quantity: ");
            int quantity = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Price per Item: ");
            double price = Convert.ToDouble(Console.ReadLine());

            itemNames.Add(name);
            itemCategories.Add(category);
            itemQuantities.Add(quantity);
            itemPrices.Add(price);

            Console.WriteLine("\nItem added successfully!\n");
        }

        // Step 3: Display all items
        Console.WriteLine("=== Warehouse Items List ===\n");
        for (int i = 0; i < itemNames.Count; i++)
        {
            double totalValue = itemQuantities[i] * itemPrices[i];

            Console.WriteLine("Item Name      : " + itemNames[i]);
            Console.WriteLine("Category       : " + itemCategories[i]);
            Console.WriteLine("Quantity       : " + itemQuantities[i]);
            Console.WriteLine("Price per Unit : " + itemPrices[i]);
            Console.WriteLine("Total Value    : " + totalValue);
            Console.WriteLine(new string('-', 50));
        }

        // Step 4: Sort items by total value
        Console.WriteLine("\n=== Items Sorted by Total Value ===\n");

        List<int> sortedIndices = new List<int>();
        for (int i = 0; i < itemNames.Count; i++)
            sortedIndices.Add(i);

        // Bubble sort indices by total value
        for (int i = 0; i < sortedIndices.Count - 1; i++)
        {
            for (int j = 0; j < sortedIndices.Count - i - 1; j++)
            {
                double value1 = itemQuantities[sortedIndices[j]] * itemPrices[sortedIndices[j]];
                double value2 = itemQuantities[sortedIndices[j + 1]] * itemPrices[sortedIndices[j + 1]];

                if (value1 > value2)
                {
                    int temp = sortedIndices[j];
                    sortedIndices[j] = sortedIndices[j + 1];
                    sortedIndices[j + 1] = temp;
                }
            }
        }

        for (int i = 0; i < sortedIndices.Count; i++)
        {
            int idx = sortedIndices[i];
            double totalValue = itemQuantities[idx] * itemPrices[idx];
            Console.WriteLine("Item: " + itemNames[idx] + " | Category: " + itemCategories[idx] + " | Total Value: " + totalValue);
        }

        // Step 5: Display items by category
        Console.WriteLine("\n=== Items by Category ===\n");
        List<string> categoriesPrinted = new List<string>();
        for (int i = 0; i < itemCategories.Count; i++)
        {
            string cat = itemCategories[i];
            if (!categoriesPrinted.Contains(cat))
            {
                categoriesPrinted.Add(cat);
                Console.WriteLine("Category: " + cat);
                for (int j = 0; j < itemNames.Count; j++)
                {
                    if (itemCategories[j] == cat)
                    {
                        double totalValue = itemQuantities[j] * itemPrices[j];
                        Console.WriteLine("  - " + itemNames[j] + " | Quantity: " + itemQuantities[j] + " | Total Value: " + totalValue);
                    }
                }
                Console.WriteLine();
            }
        }

        Console.WriteLine("=== Warehouse Display Completed Successfully ===");
    }
}
