using System;
using AmbulanceRoute.Models;

namespace AmbulanceRoute.DataStructures
{
    class Node
    {
        public HospitalUnit Data;
        public Node Next;

        public Node(HospitalUnit unit)
        {
            Data = unit;
            Next = null;
        }
    }

    class CircularLinkedList
    {
        private Node head;

        public void Add(HospitalUnit unit)
        {
            Node node = new Node(unit);

            if (head == null)
            {
                head = node;
                head.Next = head;
                return;
            }

            Node temp = head;
            while (temp.Next != head)
            {
                temp = temp.Next;
            }

            temp.Next = node;
            node.Next = head;
        }

        public HospitalUnit FindAvailable()
        {
            if (head == null)
                return null;

            Node temp = head;

            do
            {
                if (temp.Data.IsAvailable)
                    return temp.Data;

                temp = temp.Next;
            }
            while (temp != head);

            return null;
        }

        public void Remove(string name)
        {
            if (head == null)
                return;

            Node curr = head;
            Node prev = null;

            do
            {
                if (curr.Data.UnitName == name)
                {
                    if (prev != null)
                        prev.Next = curr.Next;
                    else
                    {
                        Node last = head;
                        while (last.Next != head)
                            last = last.Next;

                        head = curr.Next;
                        last.Next = head;
                    }
                    return;
                }

                prev = curr;
                curr = curr.Next;
            }
            while (curr != head);
        }

        public void Display()
        {
            if (head == null)
                return;

            Node temp = head;
            do
            {
                Console.WriteLine(
                    temp.Data.UnitName + " | Available: " +
                    temp.Data.IsAvailable + " | Type: " +
                    temp.Data.GetUnitType()
                );
                temp = temp.Next;
            }
            while (temp != head);
        }
    }
}
