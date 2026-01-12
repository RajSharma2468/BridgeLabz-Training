using System;

class CustomFurnitureManufacturingDP
{
    private static int RodLength = 12;
    private static int[] prices = { 0, 2, 5, 7, 9, 10, 17, 17, 20, 24, 30, 33, 34 };

    static void Main(string[] args)
    {
        int choice;
        do
        {
            Console.WriteLine("\n===== CUSTOM FURNITURE MANUFACTURING (DP) =====");
            Console.WriteLine("1. Maximize Revenue");
            Console.WriteLine("2. Maximize Revenue with Waste Constraint");
            Console.WriteLine("3. Maximize Revenue + Minimize Waste");
            Console.WriteLine("0. Exit");
            Console.Write("Enter choice: ");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    ScenarioA();
                    break;

                case 2:
                    ScenarioB();
                    break;

                case 3:
                    ScenarioC();
                    break;
            }

        } while (choice != 0);
    }

    // ================= SCENARIO A =================
    static void ScenarioA()
    {
        int[] dp = new int[RodLength + 1];
        int[] cut = new int[RodLength + 1];

        for (int i = 1; i <= RodLength; i++)
        {
            int max = 0;
            for (int j = 1; j <= i; j++)
            {
                if (prices[j] + dp[i - j] > max)
                {
                    max = prices[j] + dp[i - j];
                    cut[i] = j;
                }
            }
            dp[i] = max;
        }

        Console.WriteLine("\n--- Scenario A: Max Revenue ---");
        PrintCutSequence(cut, RodLength);
        Console.WriteLine("Total Revenue: ₹" + dp[RodLength]);
        Console.WriteLine("Waste: 0 ft");
    }

    // ================= SCENARIO B =================
    static void ScenarioB()
    {
        Console.Write("Enter allowed waste (ft): ");
        int allowedWaste = int.Parse(Console.ReadLine());

        int[] dp = new int[RodLength + 1];
        int[] cut = new int[RodLength + 1];

        for (int i = 1; i <= RodLength; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                if (prices[j] + dp[i - j] > dp[i])
                {
                    dp[i] = prices[j] + dp[i - j];
                    cut[i] = j;
                }
            }
        }

        int bestRevenue = 0;
        int bestLength = 0;

        for (int len = RodLength - allowedWaste; len <= RodLength; len++)
        {
            if (dp[len] > bestRevenue)
            {
                bestRevenue = dp[len];
                bestLength = len;
            }
        }

        Console.WriteLine("\n--- Scenario B: Revenue with Waste Constraint ---");
        PrintCutSequence(cut, bestLength);
        Console.WriteLine("Total Revenue: ₹" + bestRevenue);
        Console.WriteLine("Waste: " + (RodLength - bestLength) + " ft");
    }

    // ================= SCENARIO C =================
    static void ScenarioC()
    {
        int[] dp = new int[RodLength + 1];
        int[] cut = new int[RodLength + 1];

        for (int i = 1; i <= RodLength; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                if (prices[j] + dp[i - j] > dp[i])
                {
                    dp[i] = prices[j] + dp[i - j];
                    cut[i] = j;
                }
            }
        }

        int bestRevenue = 0;
        int bestLength = 0;

        for (int i = 0; i <= RodLength; i++)
        {
            if (dp[i] > bestRevenue ||
               (dp[i] == bestRevenue && (RodLength - i) < (RodLength - bestLength)))
            {
                bestRevenue = dp[i];
                bestLength = i;
            }
        }

        Console.WriteLine("\n--- Scenario C: Max Revenue + Min Waste ---");
        PrintCutSequence(cut, bestLength);
        Console.WriteLine("Total Revenue: ₹" + bestRevenue);
        Console.WriteLine("Waste: " + (RodLength - bestLength) + " ft");
    }

    // ================= HELPER =================
    static void PrintCutSequence(int[] cut, int length)
    {
        Console.Write("Cut Sequence: ");
        while (length > 0)
        {
            Console.Write(cut[length] + " ");
            length -= cut[length];
        }
        Console.WriteLine();
    }
}
