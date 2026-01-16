using System;
using TrafficManager.Roundabout;
using TrafficManager.Queue;

namespace TrafficManager
{
    class Program
    {
        static void Main()
        {
            CircularRoundabout roundabout = new CircularRoundabout();
            VehicleQueue waitingQueue = new VehicleQueue(3);

            waitingQueue.Enqueue("CAR-101");
            waitingQueue.Enqueue("CAR-102");
            waitingQueue.Enqueue("CAR-103");
            waitingQueue.Enqueue("CAR-104"); // overflow

            Console.WriteLine();

            string vehicle;
            vehicle = waitingQueue.Dequeue();
            if (vehicle != null) roundabout.AddVehicle(vehicle);

            vehicle = waitingQueue.Dequeue();
            if (vehicle != null) roundabout.AddVehicle(vehicle);

            roundabout.Display();

            Console.WriteLine();
            roundabout.RemoveVehicle();
            roundabout.Display();

            Console.WriteLine();
            vehicle = waitingQueue.Dequeue();
            if (vehicle != null) roundabout.AddVehicle(vehicle);

            roundabout.Display();
        }
    }
}
