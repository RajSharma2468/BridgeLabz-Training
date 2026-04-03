using System;
using System.Collections.Generic;

namespace BankManagement
{
public class BankManager
{


        //===========================================GetDetails==========>

       public void GetDetails()
        {
            Console.WriteLine("Enter Account Number");
            string AC = Console.ReadLine();
            if (string.IsNullOrEmpty(AC) || !Program.accounts.ContainsKey(AC))
            {
                Console.WriteLine("Account Does Not Exist ===========>"); return;
            }
            Program.accounts[AC].DisplayAccountInfo();
        }



        //=============================================DisplayAllAccounts=======================>

        public void DisplayAllAccounts()
        {
            Console.WriteLine("\n========== All Accounts ==========");
            if (Program.accounts.Count == 0)
           {
                Console.WriteLine("No accounts found.");
                return;
            }
        
          foreach (Account account in Program.accounts.Values)
            {
               account.DisplayAccountInfo();
               Console.WriteLine("----------------------------------");
         }
    }



        //========================================DeleteAccount======================>


        public void DeleteAccount()
        {
            Console.WriteLine("Enter Account Number That You want to Permanently Delete");
            string AC = Console.ReadLine();
            if (string.IsNullOrEmpty(AC) || !Program.accounts.ContainsKey(AC))
            {
                Console.WriteLine("Account Does Not Exist ===============>"); return;
            }
            Program.accounts.Remove(AC);
            Console.WriteLine("\nAccount Deleted Successfully ===============>\n");
        }





        //===========================================CreateAccount======================>

        public void CreateAccount()
        {
            Console.WriteLine("Press 1. for Saving\nPress 2. for Current");
            int input = int.Parse(Console.ReadLine());
            if (input == 1)
            {
                Console.WriteLine("Enter : accountNumber , initialBalance, interestRate Alternatively");
                //string accountNumber, double initialBalance, double interestRate
                string AC = Console.ReadLine();
                if (Program.accounts.ContainsKey(AC))
                {
                    Console.WriteLine("Account Already Exists=======> ");
                    return;
                }
                double initialBalance = double.Parse(Console.ReadLine());
                double interestRate = double.Parse(Console.ReadLine());
                Program.accounts.Add(AC, new SavingsAccount(AC, initialBalance, interestRate));
                Console.WriteLine("Savings Account Created Successfully=======> ");
            }
            else if (input == 2)
            {
                Console.WriteLine("Enter : accountNumber , initialBalance, overDraftLimit Alternatively");
                //string accountNumber, double initialBalance, double overdraftLimit
                string AC = Console.ReadLine();
                if (Program.accounts.ContainsKey(AC))
                {
                    Console.WriteLine("Account Already Exists=======> ");
                    return;
                }
                double initialBalance = double.Parse(Console.ReadLine());
                double overDraftLimit = double.Parse(Console.ReadLine());
                Program.accounts.Add(AC, new CurrentAccount(AC, initialBalance, overDraftLimit));
                Console.WriteLine("Current Account Created Successfully=======> ");
            }
            else
            {
                Console.WriteLine("Invalid Input Try Again==============>");
                return;
            }
        }
    }

}