using System;

class InsufficientFundsException : Exception
{
    public InsufficientFundsException(string msg) : base(msg) { }
}

class BankAccount
{
    double balance = 5000;

    public void Withdraw(double amount)
    {
        if (amount < 0)
            throw new ArgumentException("Invalid amount!");

        if (amount > balance)
            throw new InsufficientFundsException("Insufficient balance!");

        balance -= amount;
        Console.WriteLine("Withdrawal successful, new balance: " + balance);
    }
}

class Program
{
    static void Main()
    {
        BankAccount account = new BankAccount();

        try
        {
            Console.Write("Enter withdraw amount: ");
            double amount = double.Parse(Console.ReadLine());
            account.Withdraw(amount);
        }
        catch (InsufficientFundsException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
