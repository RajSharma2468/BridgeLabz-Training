using System;

class Node
{
    public int key;
    public int value;
    public Node next;
}

class CustomHashMap
{
    Node[] table = new Node[10];

    int Hash(int key)
    {
        return key % 10;
    }

    public void Put(int key, int value)
    {
        int index = Hash(key);

        Node newNode = new Node();
        newNode.key = key;
        newNode.value = value;
        newNode.next = null;

        if (table[index] == null)
        {
            table[index] = newNode;
        }
        else
        {
            newNode.next = table[index];
            table[index] = newNode;
        }
    }

    public int Get(int key)
    {
        int index = Hash(key);
        Node temp = table[index];

        while (temp != null)
        {
            if (temp.key == key)
                return temp.value;

            temp = temp.next;
        }
        return -1;
    }

    static void Main()
    {
        CustomHashMap map = new CustomHashMap();

        map.Put(1, 100);
        map.Put(11, 200);   // collision (1 % 10 == 11 % 10)

        Console.WriteLine(map.Get(1));
        Console.WriteLine(map.Get(11));
    }
}
