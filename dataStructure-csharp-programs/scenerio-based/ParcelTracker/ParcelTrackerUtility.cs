using System;

internal class ParcelTrackerUtility : IParcelTracker
{
    private ParcelStage head;

    public ParcelTrackerUtility()
    {
        head = null;
    }

    // Default delivery chain
    public void AddInitialStages()
    {
        head = new ParcelStage("Packed");
        head.Next = new ParcelStage("Shipped");
        head.Next.Next = new ParcelStage("In Transit");
        head.Next.Next.Next = new ParcelStage("Delivered");

        Console.WriteLine("Default delivery stages added.\n");
    }

    // Add custom checkpoint in between
    public void AddCheckpoint()
    {
        if (head == null)
        {
            Console.WriteLine("No parcel stages available.\n");
            return;
        }

        Console.Write("Enter stage after which to add checkpoint: ");
        string afterStage = Console.ReadLine();

        Console.Write("Enter new checkpoint name: ");
        string newStage = Console.ReadLine();

        ParcelStage temp = head;

        while (temp != null && !temp.StageName.Equals(afterStage))
        {
            temp = temp.Next;
        }

        if (temp == null)
        {
            Console.WriteLine("Stage not found. Parcel may be lost!\n");
            return;
        }

        ParcelStage newNode = new ParcelStage(newStage);
        newNode.Next = temp.Next;
        temp.Next = newNode;

        Console.WriteLine("Checkpoint added successfully.\n");
    }

    // Forward tracking
    public void TrackParcel()
    {
        Console.WriteLine("\n📦 PARCEL TRACKING STATUS\n");

        if (head == null)
        {
            Console.WriteLine("Parcel lost! No tracking data found (null pointer).\n");
            return;
        }

        ParcelStage temp = head;

        while (temp != null)
        {
            Console.Write(temp.StageName);

            if (temp.Next != null)
                Console.Write("  →  ");

            temp = temp.Next;
        }

        Console.WriteLine("\n");
    }
}
