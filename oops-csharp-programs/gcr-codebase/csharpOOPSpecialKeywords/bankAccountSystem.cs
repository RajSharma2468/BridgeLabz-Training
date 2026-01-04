using System;

class BankAccount
{
    public static string bankName = "State Bank of India";
    private static int totalAccounts = 0;

    public string accountHolderName;
    public readonly int accountNumber;

    public BankAccount(string accountHolderName, int accountNumber)
    {
        this.accountHolderName = accountHolderName;
        this.accountNumber = accountNumber;
        totalAccounts++;
    }

    public static void GetTotalAccounts()
    {
        Console.WriteLine("Total Accounts: " + totalAccounts);
    }

    public void DisplayDetails(object obj)
    {
        if (obj is BankAccount)
        {
            Console.WriteLine("Bank Name: " + bankName);
            Console.WriteLine("Account Holder: " + accountHolderName);
            Console.WriteLine("Account Number: " + accountNumber);
        }
    }
}

class Program
{
    static void Main()
    {
        BankAccount acc1 = new BankAccount("Raj", 101);
        acc1.DisplayDetails(acc1);
        BankAccount.GetTotalAccounts();
    }
}
