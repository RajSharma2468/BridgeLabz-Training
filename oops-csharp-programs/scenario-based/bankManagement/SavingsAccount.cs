using System;
using System.Collections.Generic;
namespace BankManagement
{
public class SavingsAccount : Account
{
    private double interestRate;
    private const double MIN_BALANCE = 100.00;
    
    public double InterestRate 
    { 
        get { return interestRate; }
        set { interestRate = value; }
    }
    
    public SavingsAccount(string accountNumber, double initialBalance, double interestRate) 
        : base(accountNumber, initialBalance)
    {
        this.interestRate = interestRate;
    }
    public override bool Withdraw(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Withdrawal amount must be positive.");
            return false;
        }
        if (Balance - amount < MIN_BALANCE)
        {
            Console.WriteLine($"Insufficient funds! Minimum balance of ${MIN_BALANCE:F2} must be maintained.");
            Console.WriteLine($"Available for withdrawal: ${(Balance - MIN_BALANCE):F2}");
            return false;
        }
        
        Balance -= amount;
        Console.WriteLine($"Withdrawn: ${amount:F2}");
        return true;
    }
    
    public void ApplyInterest()
    {
        double interest = Balance * interestRate / 100;
        Balance += interest;
        Console.WriteLine($"Interest applied: ${interest:F2}");
    }
    
    public override void DisplayAccountInfo()
    {
        base.DisplayAccountInfo();
        Console.WriteLine($"Account Type: Savings");
        Console.WriteLine($"Interest Rate: {interestRate}%");
        Console.WriteLine($"Minimum Balance: ${MIN_BALANCE:F2}");
    }
}
}