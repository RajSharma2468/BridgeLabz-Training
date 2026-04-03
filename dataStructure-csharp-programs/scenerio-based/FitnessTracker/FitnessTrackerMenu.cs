using System;

internal class FitnessTrackerMenu
{
    private FitnessTrackerUtility tracker = new FitnessTrackerUtility();

    public void ShowMenu()
    {
        int choice;
        do
        {
            Console.WriteLine("\n==== FITNESS TRACKER ====");
            Console.WriteLine("1. Add / Update User Steps");
            Console.WriteLine("2. Show Leaderboard");
            Console.WriteLine("3. Exit");
            Console.Write("Enter choice: ");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    tracker.AddOrUpdateUser();
                    break;
                case 2:
                    tracker.ShowLeaderboard();
                    break;
            }
        } while (choice != 3);
    }
}
