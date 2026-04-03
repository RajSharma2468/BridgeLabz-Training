using System;
using System.Collections.Generic;

#region Interface
interface ITaxable
{
    double CalculateTax();
    void GetTaxDetails();
}
#endregion

#region Abstract Class
abstract class Product
{
    private int productId;
    private string name;
    protected double price;

    public int ProductId
    {
        get { return productId; }
    }

    protected Product(int id, string pname, double pprice)
    {
        productId = id;
        name = pname;
        price = pprice;
    }

    public abstract double CalculateDiscount();

    public virtual double GetFinalPrice()
    {
        return price - CalculateDiscount();
    }

    public virtual void DisplayDetails()
    {
        Console.WriteLine("Product ID : " + productId);
        Console.WriteLine("Name       : " + name);
        Console.WriteLine("Price      : " + price);
    }
}
#endregion

#region Electronics
class Electronics : Product, ITaxable
{
    public Electronics(int id, string name, double price)
        : base(id, name, price) { }

    public override double CalculateDiscount()
    {
        return price * 0.10;
    }

    public double CalculateTax()
    {
        return price * 0.18;
    }

    public void GetTaxDetails()
    {
        Console.WriteLine("Tax        : " + CalculateTax());
    }
}
#endregion

#region Clothing
class Clothing : Product
{
    public Clothing(int id, string name, double price)
        : base(id, name, price) { }

    public override double CalculateDiscount()
    {
        return price * 0.20;
    }
}
#endregion

#region Groceries
class Groceries : Product
{
    public Groceries(int id, string name, double price)
        : base(id, name, price) { }

    public override double CalculateDiscount()
    {
        return price * 0.05;
    }
}
#endregion

#region Main Program
class Program
{
    static void Main()
    {
        List<Product> products = new List<Product>();

        while (true)
        {
            Console.WriteLine("\nE-COMMERCE PLATFORM");
            Console.WriteLine("1. Add Electronics");
            Console.WriteLine("2. Add Clothing");
            Console.WriteLine("3. Add Groceries");
            Console.WriteLine("4. Display Products");
            Console.WriteLine("5. Exit");
            Console.Write("Enter Choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    products.Add(CreateElectronics());
                    break;

                case 2:
                    products.Add(CreateClothing());
                    break;

                case 3:
                    products.Add(CreateGroceries());
                    break;

                case 4:
                    DisplayProducts(products);
                    break;

                case 5:
                    return;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }

    static Electronics CreateElectronics()
    {
        Console.Write("ID: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Price: ");
        double price = double.Parse(Console.ReadLine());

        return new Electronics(id, name, price);
    }

    static Clothing CreateClothing()
    {
        Console.Write("ID: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Price: ");
        double price = double.Parse(Console.ReadLine());

        return new Clothing(id, name, price);
    }

    static Groceries CreateGroceries()
    {
        Console.Write("ID: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Price: ");
        double price = double.Parse(Console.ReadLine());

        return new Groceries(id, name, price);
    }

    static void DisplayProducts(List<Product> products)
    {
        foreach (Product p in products)
        {
            p.DisplayDetails();
            Console.WriteLine("Discount   : " + p.CalculateDiscount());

            if (p is ITaxable)
            {
                ((ITaxable)p).GetTaxDetails();
            }

            Console.WriteLine("Final Price: " + p.GetFinalPrice());
            Console.WriteLine("---------------------------");
        }
    }
}
#endregion
