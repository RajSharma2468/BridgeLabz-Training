using System;
using System.Collections.Generic;

class ATMGreedy
{
    static void Main()
    {
        Console.Write("Enter withdrawal amount: ");
        int amount = int.Parse(Console.ReadLine());

        // Scenario A: All denominations
        List<int> scenarioA = new List<int>
        {
            500, 200, 100, 50, 20, 10, 5, 2, 1
        };

        Console.WriteLine("\nScenario A: All notes available");
        GreedyDispense(amount, scenarioA);

        // Scenario B: 500 removed
        List<int> scenarioB = new List<int>
        {
            200, 100, 50, 20, 10, 5, 2, 1
        };

        Console.WriteLine("\nScenario B: 500 note removed");
        GreedyDispense(amount, scenarioB);
    }

    static void GreedyDispense(int amount, List<int> denominations)
    {
        Dictionary<int, int> result = new Dictionary<int, int>();
        int remaining = amount;

        // Greedy selection
        foreach (int note in denominations)
        {
            if (remaining >= note)
            {
                int count = remaining / note;
                remaining = remaining % note;
                result[note] = count;
            }
        }

        // Exact amount possible
        if (remaining == 0)
        {
            Console.WriteLine("Notes Dispensed:");
            foreach (var note in result)
            {
                Console.WriteLine("₹" + note.Key + " x " + note.Value);
            }
        }
        // Fallback scenario
        else
        {
            Console.WriteLine("Exact amount not possible");

            int fallbackAmount = amount - remaining;
            Console.WriteLine("Fallback amount dispensed: ₹" + fallbackAmount);
        }
    }
}
