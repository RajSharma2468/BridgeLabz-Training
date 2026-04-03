using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Personalized Meal Plan Generator ===\n");

        // Step 1: Initialize meal data
        List<string> mealNames = new List<string>
        {
            "Vegetable Salad", "Vegan Smoothie", "Keto Chicken", "High Protein Shake",
            "Quinoa Bowl", "Tofu Stir Fry", "Grilled Salmon", "Protein Pancakes"
        };

        List<string> mealTypes = new List<string>
        {
            "Vegetarian", "Vegan", "Keto", "High-Protein",
            "Vegetarian", "Vegan", "Keto", "High-Protein"
        };

        List<int> calories = new List<int>
        {
            150, 200, 350, 250,
            180, 220, 400, 300
        };

        List<int> servings = new List<int>
        {
            1, 1, 1, 1,
            2, 2, 1, 2
        };

        // Step 2: User input to add a new meal
        Console.WriteLine("Do you want to add a new meal? (yes/no)");
        string response = Console.ReadLine().ToLower();
        if (response == "yes")
        {
            Console.Write("Enter Meal Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Meal Type (Vegetarian/Vegan/Keto/High-Protein): ");
            string type = Console.ReadLine();
            Console.Write("Enter Calories: ");
            int cal = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Servings: ");
            int serve = Convert.ToInt32(Console.ReadLine());

            mealNames.Add(name);
            mealTypes.Add(type);
            calories.Add(cal);
            servings.Add(serve);

            Console.WriteLine("\nMeal added successfully!\n");
        }

        // Step 3: Display all meals
        Console.WriteLine("=== All Meal Plans ===\n");
        for (int i = 0; i < mealNames.Count; i++)
        {
            Console.WriteLine("Meal Name   : " + mealNames[i]);
            Console.WriteLine("Meal Type   : " + mealTypes[i]);
            Console.WriteLine("Calories    : " + calories[i]);
            Console.WriteLine("Servings    : " + servings[i]);
            Console.WriteLine(new string('-', 50));
        }

        // Step 4: Sort meals by calories
        Console.WriteLine("\n=== Meals Sorted by Calories (Ascending) ===\n");

        List<int> sortedIndices = new List<int>();
        for (int i = 0; i < mealNames.Count; i++)
            sortedIndices.Add(i);

        // Bubble sort by calories
        for (int i = 0; i < sortedIndices.Count - 1; i++)
        {
            for (int j = 0; j < sortedIndices.Count - i - 1; j++)
            {
                if (calories[sortedIndices[j]] > calories[sortedIndices[j + 1]])
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
            Console.WriteLine("Meal: " + mealNames[idx] + " | Type: " + mealTypes[idx] + 
                              " | Calories: " + calories[idx] + " | Servings: " + servings[idx]);
        }

        // Step 5: Display meals by type
        Console.WriteLine("\n=== Meals by Type ===\n");
        List<string> typesPrinted = new List<string>();
        for (int i = 0; i < mealTypes.Count; i++)
        {
            string type = mealTypes[i];
            if (!typesPrinted.Contains(type))
            {
                typesPrinted.Add(type);
                Console.WriteLine("Meal Type: " + type);
                for (int j = 0; j < mealNames.Count; j++)
                {
                    if (mealTypes[j] == type)
                    {
                        Console.WriteLine("  - " + mealNames[j] + " | Calories: " + calories[j] + 
                                          " | Servings: " + servings[j]);
                    }
                }
                Console.WriteLine();
            }
        }

        Console.WriteLine("=== Personalized Meal Plan Display Completed Successfully ===");
    }
}
