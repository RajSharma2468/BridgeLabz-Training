using System;

namespace TrafficManager.Queue
{
    class VehicleQueue
    {
        private string[] queue;
        private int front;
        private int rear;
        private int capacity;

        public VehicleQueue(int size)
        {
            capacity = size;
            queue = new string[size];
            front = 0;
            rear = -1;
        }

        public bool IsFull()
        {
            return rear == capacity - 1;
        }

        public bool IsEmpty()
        {
            return front > rear;
        }

        public void Enqueue(string vehicle)
        {
            if (IsFull())
            {
                Console.WriteLine("Queue Overflow! Cannot add: " + vehicle);
                return;
            }

            queue[++rear] = vehicle;
            Console.WriteLine("Vehicle waiting: " + vehicle);
        }

        public string Dequeue()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue Underflow! No vehicles waiting");
                return null;
            }

            return queue[front++];
        }
    }
}
