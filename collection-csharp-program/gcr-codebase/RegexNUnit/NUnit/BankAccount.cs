using System;

class BankAccount
{
    private double balance = 0;

    public void Deposit(double amount)
    {
        balance += amount;
    }

    public void Withdraw(double amount)
    {
        if (amount > balance)
            Console.WriteLine("Insufficient funds");
        else
            balance -= amount;
    }

    public double GetBalance()
    {
        return balance;
    }
}

class Program
{
    static void Main()
    {
        BankAccount acc = new BankAccount();
        acc.Deposit(1000);
        acc.Withdraw(300);
        acc.Withdraw(800);
        Console.WriteLine("Balance: " + acc.GetBalance());
    }
}
