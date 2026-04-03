using System;
using System.Collections.Generic;
namespace BankManagement
{
class Program
{
        public static Dictionary<string, Account> accounts = new Dictionary<string, Account>();
        public static void Main(string[] args)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("   Bank Account Management System");
            Console.WriteLine("========================================");

            int mode = 0;

            while (true)
            {
                if (mode == 0)
                {
                    Console.WriteLine("\nPress 1. for Bank Manager\nPress 2. for Account Holder\nPress 3. for Exit");
                    if (!int.TryParse(Console.ReadLine(), out mode)) continue;
                }
                if (mode == 1)
                {
                    Console.WriteLine("Enter Password For Manager Login-In (Case-Sensitive)");
                    string password = Console.ReadLine();

                    if (password != "ashishDubey")
                    {
                        Console.WriteLine("Incorrect Password");
                        mode = 0;
                        continue;
                    }

                    BankManager bank = new BankManager();

                    while (true)
                    {
                        Console.WriteLine("\nMenu----->");
                        Console.WriteLine("1. Create Account");
                        Console.WriteLine("2. Delete Account");
                        Console.WriteLine("3. Get Account Details");
                        Console.WriteLine("4. Show All Accounts");
                        Console.WriteLine("5. Switch to Account Holder");
                        Console.WriteLine("Any other key to Exit");

                        if (!int.TryParse(Console.ReadLine(), out int choice)) break;

                        if (choice == 1) bank.CreateAccount();
                        else if (choice == 2) bank.DeleteAccount();
                        else if (choice == 3) bank.GetDetails();
                        else if (choice == 4) bank.DisplayAllAccounts();
                        else if (choice == 5)
                        {
                            mode = 2;
                            break;
                        }
                        else return;
                    }
                }

                // ================= EMPLOYEE =================
                else if (mode == 2)
                {
                    Console.WriteLine("Enter Account Number For Account Holder Login ");
                    string AC = Console.ReadLine();

                    if (!accounts.ContainsKey(AC))
                    {
                        Console.WriteLine("Account Does Not Exist");
                        mode = 0;
                        continue;
                    }

                    while (true)
                    {
                        Console.WriteLine("\nMenu----->");
                        Console.WriteLine("1. Deposit");
                        Console.WriteLine("2. Withdraw");
                        Console.WriteLine("3. View Account");
                        Console.WriteLine("4. Switch to Bank Manager");
                        Console.WriteLine("Any other key to Exit");

                        if (!int.TryParse(Console.ReadLine(), out int choice)) break;

                        if (choice == 1)
                        {
                            Console.WriteLine("Enter Amount");
                            accounts[AC].Deposit(double.Parse(Console.ReadLine()));
                        }
                        else if (choice == 2)
                        {
                            Console.WriteLine("Enter Amount");
                            accounts[AC].Withdraw(double.Parse(Console.ReadLine()));
                        }
                        else if (choice == 3)
                        {
                            accounts[AC].DisplayAccountInfo();
                        }
                        else if (choice == 4)
                        {
                            mode = 1;
                            break;
                        }
                        else return;
                    }
                }

                else if (mode == 3)
                {
                    Console.WriteLine("End of Demonstration");
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                    mode = 0;
                    continue;
                }
            }
        }
}
}