using System;
using System.Collections.Generic;

class Product
{
    public string productName;
    public double quantity;
    public double pricePerUnit;

    public Product(string productName, double quantity, double pricePerUnit)
    {
        this.productName = productName;
        this.quantity = quantity;
        this.pricePerUnit = pricePerUnit;
    }

    public double GetCost()
    {
        return quantity * pricePerUnit;
    }
}

class Customer
{
    public string name;
    public List<Product> products = new List<Product>();

    public Customer(string name)
    {
        this.name = name;
    }

    public void AddProduct(Product p)
    {
        products.Add(p);
    }
}

class BillGenerator
{
    public void GenerateBill(Customer customer)
    {
        double total = 0;

        Console.WriteLine("Customer: " + customer.name);

        foreach (Product p in customer.products)
        {
            double cost = p.GetCost();
            Console.WriteLine(p.productName + " Cost: " + cost);
            total += cost;
        }

        Console.WriteLine("Total Bill: " + total);
    }
}

class Program
{
    static void Main()
    {
        Customer customer = new Customer("Alice");

        customer.AddProduct(new Product("Apples", 2, 3));
        customer.AddProduct(new Product("Milk", 1, 2));

        BillGenerator bg = new BillGenerator();
        bg.GenerateBill(customer);
    }
}
