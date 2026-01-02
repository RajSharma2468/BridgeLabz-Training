using System;
using System.Collections.Generic;

namespace BankManagement
{
    public abstract class Account
    {
        public string AccountNumber { get; set; }
        public double Balance { get; set; }
        public Account(string accountNumber, double initialBalance)
        {
            AccountNumber = accountNumber;
            Balance = initialBalance;
        }
        public void CheckBalance()
        {
            Console.WriteLine($"Current Balance: ${Balance:F2}");
        }
        public abstract bool Withdraw(double amount);
        public void Deposit(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Deposit amount must be positive.");
                return;
            }
            Balance += amount;
            Console.WriteLine($"Deposited: ${amount:F2}");
        }
        public virtual void DisplayAccountInfo()
        {
            Console.WriteLine($"Account Number: {AccountNumber}");
            Console.WriteLine($"Balance: ${Balance:F2}");
        }
    }

}
