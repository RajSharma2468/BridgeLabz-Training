using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter Fee: ");
        double fee = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Discount Percentage: ");
        double discountPercent = Convert.ToDouble(Console.ReadLine());

        double discount = (fee * discountPercent) / 100;
        double finalFee = fee - discount;

        Console.WriteLine("The discount amount is INR " + discount +
                          " and final discounted fee is INR " + finalFee);
    }
}
