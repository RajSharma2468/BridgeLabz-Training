using System;
using System.Collections.Generic;

class Product
{
    public string name;
    public int price;

    public Product(string name, int price)
    {
        this.name = name;
        this.price = price;
    }
}

class Order
{
    public List<Product> products = new List<Product>();

    public void AddProduct(Product p)
    {
        products.Add(p);
    }

    public int CalculateTotal()
    {
        int total = 0;
        foreach (Product p in products)
            total += p.price;
        return total;
    }
}

class Customer
{
    public string name;

    public Customer(string name)
    {
        this.name = name;
    }

    public void PlaceOrder(Order o)
    {
        Console.WriteLine(name + " placed an order. Total = " + o.CalculateTotal());
    }
}

class Program
{
    static void Main()
    {
        Customer c = new Customer("Alice");
        Order o = new Order();

        o.AddProduct(new Product("Laptop", 50000));
        o.AddProduct(new Product("Mouse", 500));

        c.PlaceOrder(o);
    }
}
