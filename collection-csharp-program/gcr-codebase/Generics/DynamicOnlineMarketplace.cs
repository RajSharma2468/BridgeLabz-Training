using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Dynamic Online Marketplace ===\n");

        // Step 1: Initialize products
        List<string> productNames = new List<string> 
        { 
            "C# Programming Book", "Laptop", "T-Shirt", "Jeans", 
            "Smartphone", "Headphones", "Rice Bag", "Coffee Powder", "Gaming Chair"
        };

        List<string> productCategories = new List<string> 
        { 
            "Books", "Electronics", "Clothing", "Clothing", 
            "Electronics", "Electronics", "Groceries", "Groceries", "Furniture"
        };

        List<double> productPrices = new List<double> 
        { 
            500, 55000, 800, 1200, 40000, 2000, 1500, 600, 7500 
        };

        List<double> productDiscounts = new List<double> 
        { 
            10, 5, 20, 15, 7, 10, 5, 5, 10 
        };

        // Step 2: User can add a new product
        Console.WriteLine("Do you want to add a new product? (yes/no)");
        string response = Console.ReadLine().ToLower();
        if (response == "yes")
        {
            Console.Write("Enter Product Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Category: ");
            string category = Console.ReadLine();
            Console.Write("Enter Price: ");
            double price = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter Discount (%): ");
            double discount = Convert.ToDouble(Console.ReadLine());

            productNames.Add(name);
            productCategories.Add(category);
            productPrices.Add(price);
            productDiscounts.Add(discount);

            Console.WriteLine("\nProduct added successfully!\n");
        }

        // Step 3: Display all products with discounts
        Console.WriteLine("=== Product List with Discounts ===\n");
        for (int i = 0; i < productNames.Count; i++)
        {
            double discountedPrice = productPrices[i] - (productPrices[i] * productDiscounts[i] / 100);

            Console.WriteLine("Product Name   : " + productNames[i]);
            Console.WriteLine("Category       : " + productCategories[i]);
            Console.WriteLine("Original Price : " + productPrices[i]);
            Console.WriteLine("Discount (%)   : " + productDiscounts[i]);
            Console.WriteLine("Final Price    : " + discountedPrice);
            Console.WriteLine(new string('-', 50));
        }

        // Step 4: Sort products by final price
        Console.WriteLine("\n=== Products Sorted by Final Price ===\n");

        List<int> sortedIndices = new List<int>();
        for (int i = 0; i < productPrices.Count; i++)
            sortedIndices.Add(i);

        // Bubble sort indices based on final price
        for (int i = 0; i < sortedIndices.Count - 1; i++)
        {
            for (int j = 0; j < sortedIndices.Count - i - 1; j++)
            {
                double price1 = productPrices[sortedIndices[j]] - (productPrices[sortedIndices[j]] * productDiscounts[sortedIndices[j]] / 100);
                double price2 = productPrices[sortedIndices[j + 1]] - (productPrices[sortedIndices[j + 1]] * productDiscounts[sortedIndices[j + 1]] / 100);

                if (price1 > price2)
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
            double finalPrice = productPrices[idx] - (productPrices[idx] * productDiscounts[idx] / 100);
            Console.WriteLine("Product: " + productNames[idx] + " | Category: " + productCategories[idx] + " | Price: " + finalPrice);
        }

        // Step 5: Display products by category
        Console.WriteLine("\n=== Products by Category ===\n");
        List<string> categoriesPrinted = new List<string>();
        for (int i = 0; i < productCategories.Count; i++)
        {
            string cat = productCategories[i];
            if (!categoriesPrinted.Contains(cat))
            {
                categoriesPrinted.Add(cat);
                Console.WriteLine("Category: " + cat);
                for (int j = 0; j < productNames.Count; j++)
                {
                    if (productCategories[j] == cat)
                    {
                        double finalPrice = productPrices[j] - (productPrices[j] * productDiscounts[j] / 100);
                        Console.WriteLine("  - " + productNames[j] + " : " + finalPrice);
                    }
                }
                Console.WriteLine();
            }
        }

        Console.WriteLine("=== Marketplace Display Completed Successfully ===");
    }
}
