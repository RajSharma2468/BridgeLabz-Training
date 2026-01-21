using System.Collections.Generic;

class Customer
{
    public string Name;
    public Queue<Item> Items;

    public Customer(string name)
    {
        Name = name;
        Items = new Queue<Item>();
    }
}
