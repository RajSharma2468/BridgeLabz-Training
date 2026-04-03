using System;
using System.Collections.Generic;

#region Interface
interface IDiscountable
{
    double ApplyDiscount();
    void GetDiscountDetails();
}
#endregion

#region Abstract Class
abstract class FoodItem
{
    private string itemName;
    protected double price;
    protected int quantity;

    public string ItemName
    {
        get { return itemName; }
    }

    protected FoodItem(string name, double p, int q)
    {
        itemName = name;
        price = p;
        quantity = q;
    }

    public abstract double CalculateTotalPrice();

    public virtual void GetItemDetails()
    {
        Console.WriteLine("Item Name : " + itemName);
        Console.WriteLine("Price     : " + price);
        Console.WriteLine("Quantity  : " + quantity);
    }
}
#endregion

#region VegItem
class VegItem : FoodItem, IDiscountable
{
    public VegItem(string name, double price, int qty)
        : base(name, price, qty) { }

    public override double CalculateTotalPrice()
    {
        return price * quantity;
    }

    public double ApplyDiscount()
    {
        return CalculateTotalPrice() * 0.10;
    }

    public void GetDiscountDetails()
    {
        Console.WriteLine("Discount  : " + ApplyDiscount());
    }
}
#endregion

#region NonVegItem
class NonVegItem : FoodItem, IDiscountable
{
    public NonVegItem(string name, double price, int qty)
        : base(name, price, qty) { }

    public override double CalculateTotalPrice()
    {
        return price * quantity + 50; // extra charge
    }

    public double ApplyDiscount()
    {
        return CalculateTotalPrice() * 0.05;
    }

    public void GetDiscountDetails()
    {
        Console.WriteLine("Discount  : " + ApplyDiscount());
    }
}
#endregion

#region Main Program
class Program
{
    static void Main()
    {
        List<FoodItem> menu = new List<FoodItem>();

        while (true)
        {
            Console.WriteLine("\nONLINE FOOD DELIVERY SYSTEM");
            Console.WriteLine("1. Add Veg Item");
            Console.WriteLine("2. Add Non-Veg Item");
            Console.WriteLine("3. Display Items");
            Console.WriteLine("4. Exit");
            Console.Write("Enter Choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    menu.Add(CreateVegItem());
                    break;

                case 2:
                    menu.Add(CreateNonVegItem());
                    break;

                case 3:
                    DisplayMenu(menu);
                    break;

                case 4:
                    return;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }

    static VegItem CreateVegItem()
    {
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Price: ");
        double price = double.Parse(Console.ReadLine());
        Console.Write("Quantity: ");
        int qty = int.Parse(Console.ReadLine());

        return new VegItem(name, price, qty);
    }

    static NonVegItem CreateNonVegItem()
    {
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Price: ");
        double price = double.Parse(Console.ReadLine());
        Console.Write("Quantity: ");
        int qty = int.Parse(Console.ReadLine());

        return new NonVegItem(name, price, qty);
    }

    static void DisplayMenu(List<FoodItem> menu)
    {
        foreach (FoodItem item in menu)
        {
            item.GetItemDetails();
            if (item is IDiscountable)
            {
                ((IDiscountable)item).GetDiscountDetails();
            }
            Console.WriteLine("Total Price : " + item.CalculateTotalPrice());
            Console.WriteLine("-----------------------------");
        }
    }
}
#endregion
