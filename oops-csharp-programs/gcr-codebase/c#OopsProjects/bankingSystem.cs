using System;
using System.Collections.Generic;

#region Interface
interface ILoanable
{
    void ApplyForLoan();
}
#endregion

#region Abstract Class
abstract class BankAccount
{
    private int accountNumber;
    private string holderName;
    protected double balance;

    public int AccountNumber
    {
        get { return accountNumber; }
    }

    public string HolderName
    {
        get { return holderName; }
    }

    protected BankAccount(int accNo, string name, double bal)
    {
        accountNumber = accNo;
        holderName = name;
        balance = bal;
    }

    public void Deposit(double amount)
    {
        balance += amount;
    }

    public void Withdraw(double amount)
    {
        if (amount <= balance)
            balance -= amount;
        else
            Console.WriteLine("Insufficient Balance");
    }

    public abstract double CalculateInterest();

    public virtual void DisplayDetails()
    {
        Console.WriteLine("Account Number : " + accountNumber);
        Console.WriteLine("Holder Name    : " + holderName);
        Console.WriteLine("Balance        : " + balance);
        Console.WriteLine("Interest       : " + CalculateInterest());
    }
}
#endregion

#region Savings Account
class SavingsAccount : BankAccount, ILoanable
{
    public SavingsAccount(int accNo, string name, double bal)
        : base(accNo, name, bal)
    {
    }

    public override double CalculateInterest()
    {
        return balance * 0.04;
    }

    public void ApplyForLoan()
    {
        Console.WriteLine("Loan applied under Savings Account");
    }
}
#endregion

#region Current Account
class CurrentAccount : BankAccount, ILoanable
{
    public CurrentAccount(int accNo, string name, double bal)
        : base(accNo, name, bal)
    {
    }

    public override double CalculateInterest()
    {
        return balance * 0.02;
    }

    public void ApplyForLoan()
    {
        Console.WriteLine("Loan applied under Current Account");
    }
}
#endregion

#region Main Program
class Program
{
    static void Main()
    {
        List<BankAccount> accounts = new List<BankAccount>();

        while (true)
        {
            Console.WriteLine("\nBANKING SYSTEM");
            Console.WriteLine("1. Add Savings Account");
            Console.WriteLine("2. Add Current Account");
            Console.WriteLine("3. Deposit");
            Console.WriteLine("4. Withdraw");
            Console.WriteLine("5. Display Accounts");
            Console.WriteLine("6. Exit");
            Console.Write("Enter Choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddSavingsAccount(accounts);
                    break;

                case 2:
                    AddCurrentAccount(accounts);
                    break;

                case 3:
                    DepositAmount(accounts);
                    break;

                case 4:
                    WithdrawAmount(accounts);
                    break;

                case 5:
                    DisplayAccounts(accounts);
                    break;

                case 6:
                    return;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }

    static void AddSavingsAccount(List<BankAccount> accounts)
    {
        Console.Write("Enter Account Number: ");
        int acc = int.Parse(Console.ReadLine());

        Console.Write("Enter Holder Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Initial Balance: ");
        double bal = double.Parse(Console.ReadLine());

        accounts.Add(new SavingsAccount(acc, name, bal));
        Console.WriteLine("Savings Account Created");
    }

    static void AddCurrentAccount(List<BankAccount> accounts)
    {
        Console.Write("Enter Account Number: ");
        int acc = int.Parse(Console.ReadLine());

        Console.Write("Enter Holder Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Initial Balance: ");
        double bal = double.Parse(Console.ReadLine());

        accounts.Add(new CurrentAccount(acc, name, bal));
        Console.WriteLine("Current Account Created");
    }

    static void DepositAmount(List<BankAccount> accounts)
    {
        Console.Write("Enter Account Number: ");
        int acc = int.Parse(Console.ReadLine());

        Console.Write("Enter Amount: ");
        double amt = double.Parse(Console.ReadLine());

        foreach (BankAccount a in accounts)
        {
            if (a.AccountNumber == acc)
            {
                a.Deposit(amt);
                Console.WriteLine("Amount Deposited");
                return;
            }
        }

        Console.WriteLine("Account Not Found");
    }

    static void WithdrawAmount(List<BankAccount> accounts)
    {
        Console.Write("Enter Account Number: ");
        int acc = int.Parse(Console.ReadLine());

        Console.Write("Enter Amount: ");
        double amt = double.Parse(Console.ReadLine());

        foreach (BankAccount a in accounts)
        {
            if (a.AccountNumber == acc)
            {
                a.Withdraw(amt);
                return;
            }
        }

        Console.WriteLine("Account Not Found");
    }

    static void DisplayAccounts(List<BankAccount> accounts)
    {
        Console.WriteLine("\nACCOUNT LIST\n");

        foreach (BankAccount a in accounts)
        {
            a.DisplayDetails();
            Console.WriteLine("------------------------");
        }
    }
}
#endregion
