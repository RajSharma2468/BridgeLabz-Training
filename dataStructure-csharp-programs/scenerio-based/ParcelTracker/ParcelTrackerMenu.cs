using System;

internal class ParcelTrackerMenu
{
    private ParcelTrackerUtility tracker = new ParcelTrackerUtility();

    public void ShowMenu()
    {
        int choice;
        do
        {
            Console.WriteLine("==== PARCEL TRACKER SYSTEM ====");
            Console.WriteLine("1. Add Default Delivery Stages");
            Console.WriteLine("2. Add Custom Checkpoint");
            Console.WriteLine("3. Track Parcel");
            Console.WriteLine("4. Exit");
            Console.Write("Enter choice: ");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    tracker.AddInitialStages();
                    break;
                case 2:
                    tracker.AddCheckpoint();
                    break;
                case 3:
                    tracker.TrackParcel();
                    break;
            }
        } while (choice != 4);
    }
}
