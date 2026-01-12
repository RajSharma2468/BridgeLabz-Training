using System;

class MetalFactoryPipeCutting
{
    private static int RodLength = 8;
    private static int[] prices;
    private static int optimalCuttingPrice;
    private static string optimalCuttingSequence;
    private static int customCuttingPrice;
    private static string customCuttingSequence;

    static MetalFactoryPipeCutting()
    {
        prices = new int[] { 0, 2, 4, 3, 3, 8, 1, 7, 4 };
    }

    static void Main(string[] args)
    {
        MetalFactoryPipeCutting app = new MetalFactoryPipeCutting();
        app.StartApplication();
    }

    void StartApplication()
    {
        int userChoice;
        do
        {
            Console.WriteLine("\n======== METAL FACTORY PIPE CUTTING ========");
            Console.WriteLine("1. Find most optimal cutting");
            Console.WriteLine("2. Try custom cutting");
            Console.WriteLine("3. Compare optimal and custom");
            Console.WriteLine("0. Exit");
            Console.Write("Enter choice: ");

            userChoice = int.Parse(Console.ReadLine());

            switch (userChoice)
            {
                case 1:
                    FindMostOptimalCutting();
                    break;

                case 2:
                    FindCustomCutting();
                    break;

                case 3:
                    FindMostOptimalCutting();
                    FindCustomCutting();
                    CompareResults();
                    break;
            }

        } while (userChoice != 0);
    }

    void FindMostOptimalCutting()
    {
        optimalCuttingPrice = 0;
        optimalCuttingSequence = "";

        FindOptimalRecursively(RodLength, 0, "");

        Console.WriteLine("\nMost Optimal Cutting:");
        Console.WriteLine("Cut Sequence: " + optimalCuttingSequence);
        Console.WriteLine("Total Price: " + optimalCuttingPrice);
    }

    void FindOptimalRecursively(int remainingLength, int currentPrice, string currentSequence)
    {
        if (remainingLength == 0)
        {
            if (currentPrice > optimalCuttingPrice)
            {
                optimalCuttingPrice = currentPrice;
                optimalCuttingSequence = currentSequence.TrimEnd('-');
            }
            return;
        }

        for (int cut = 1; cut <= remainingLength; cut++)
        {
            FindOptimalRecursively(
                remainingLength - cut,
                currentPrice + prices[cut],
                currentSequence + cut + "-"
            );
        }
    }

    void FindCustomCutting()
    {
        Console.Write("\nEnter custom cutting (example: 2-1-3-2): ");
        customCuttingSequence = Console.ReadLine();

        customCuttingPrice = 0;
        int totalLength = 0;

        string[] cuts = customCuttingSequence.Split('-');

        foreach (string part in cuts)
        {
            int cut = int.Parse(part);

            if (cut <= 0 || cut >= prices.Length)
            {
                Console.WriteLine("Invalid cut size detected!");
                customCuttingPrice = 0;
                return;
            }

            totalLength += cut;
            customCuttingPrice += prices[cut];
        }

        if (totalLength != RodLength)
        {
            Console.WriteLine("Invalid Cutting: Length mismatch!");
            customCuttingPrice = 0;
            return;
        }

        Console.WriteLine("\nCustom Cutting:");
        Console.WriteLine("Cut Sequence: " + customCuttingSequence);
        Console.WriteLine("Total Price: " + customCuttingPrice);
    }

    void CompareResults()
    {
        Console.WriteLine("\n==== COMPARISON RESULTS ====");
        Console.WriteLine("Optimal Price: " + optimalCuttingPrice);
        Console.WriteLine("Custom Price: " + customCuttingPrice);

        if (customCuttingPrice > optimalCuttingPrice)
            Console.WriteLine("Custom cutting beats optimal.");
        else if (customCuttingPrice < optimalCuttingPrice)
            Console.WriteLine("Custom cutting is NOT optimal.");
        else
            Console.WriteLine("Custom cutting is optimal.");
    }
}
