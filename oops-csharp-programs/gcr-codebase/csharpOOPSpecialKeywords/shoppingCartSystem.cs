using System;

class Product
{
    public static double Discount = 10.0;

    public string productName;
    public double price;
    public int quantity;
    public readonly int productID;

    public Product(string productName, double price, int quantity, int productID)
    {
        this.productName = productName;
        this.price = price;
        this.quantity = quantity;
        this.productID = productID;
    }

    public static void UpdateDiscount(double newDiscount)
    {
        Discount = newDiscount;
    }

    public void DisplayDetails(object obj)
    {
        if (obj is Product)
        {
            Console.WriteLine("Product Name: " + productName);
            Console.WriteLine("Product ID: " + productID);
            Console.WriteLine("Price: " + price);
            Console.WriteLine("Quantity: " + quantity);
            Console.WriteLine("Discount: " + Discount + "%");
        }
    }
}

class Program
{
    static void Main()
    {
        Product p = new Product("Laptop", 50000, 1, 301);
        Product.UpdateDiscount(15);
        p.DisplayDetails(p);
    }
}
