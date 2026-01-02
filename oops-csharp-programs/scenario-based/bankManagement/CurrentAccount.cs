using System;
using System.Collections.Generic;
namespace BankManagement
{
public class CurrentAccount : Account
{
    private double overdraftLimit;
    
    public double OverdraftLimit 
    { 
        get { return overdraftLimit; }
        set { overdraftLimit = value; }
    }
    
    public CurrentAccount(string accountNumber, double initialBalance, double overdraftLimit) 
        : base(accountNumber, initialBalance)
    {
        this.overdraftLimit = overdraftLimit;
    }
    
    public override bool Withdraw(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Withdrawal amount must be positive.");
            return false;
        }
        
        if (Balance - amount < -overdraftLimit)
        {
            Console.WriteLine($"Insufficient funds! Overdraft limit of ${overdraftLimit:F2} exceeded.");
            Console.WriteLine($"Available for withdrawal: ${(Balance + overdraftLimit):F2}");
            return false;
        }
        
        Balance -= amount;
        Console.WriteLine($"Withdrawn: ${amount:F2}");
        
        if (Balance < 0)
        {
            Console.WriteLine($"Warning: Overdraft used. Current balance: ${Balance:F2}");
        }
        
        return true;
    }
    
    public override void DisplayAccountInfo()
    {
        base.DisplayAccountInfo();
        Console.WriteLine($"Account Type: Current");
        Console.WriteLine($"Overdraft Limit: ${overdraftLimit:F2}");
        Console.WriteLine($"Available Credit: ${(Balance + overdraftLimit):F2}");
    }
}
}