using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<int, double> accounts = new Dictionary<int, double>();
        SortedDictionary<double, int> sortedAccounts = new SortedDictionary<double, int>();
        Queue<int> withdrawalQueue = new Queue<int>();

        Console.WriteLine("Enter number of accounts");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Enter Account Number");
            int accNo = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Balance");
            double balance = double.Parse(Console.ReadLine());

            accounts[accNo] = balance;
            sortedAccounts[balance] = accNo;
        }

        Console.WriteLine("Enter number of withdrawal requests");
        int w = int.Parse(Console.ReadLine());

        for (int i = 0; i < w; i++)
        {
            Console.WriteLine("Enter Account Number For Withdrawal");
            withdrawalQueue.Enqueue(int.Parse(Console.ReadLine()));
        }

        Console.WriteLine("Accounts Sorted By Balance");
        foreach (var acc in sortedAccounts)
            Console.WriteLine(acc.Value + " " + acc.Key);

        Console.WriteLine("Processing Withdrawals");
        while (withdrawalQueue.Count > 0)
        {
            int acc = withdrawalQueue.Dequeue();
            Console.WriteLine("Withdrawal processed for account " + acc);
        }
    }
}
