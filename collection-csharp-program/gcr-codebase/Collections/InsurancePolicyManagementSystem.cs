using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        HashSet<string> policySet = new HashSet<string>();
        LinkedList<Policy> insertionOrder = new LinkedList<Policy>();
        SortedSet<Policy> expirySorted = new SortedSet<Policy>();

        Console.WriteLine("Enter number of policies");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Enter Policy Number");
            string num = Console.ReadLine();

            Console.WriteLine("Enter Coverage Type");
            string type = Console.ReadLine();

            Console.WriteLine("Enter Expiry Date yyyy-mm-dd");
            DateTime date = DateTime.Parse(Console.ReadLine());

            Policy p = new Policy(num, type, date);

            if (policySet.Add(num))
            {
                insertionOrder.AddLast(p);
                expirySorted.Add(p);
            }
            else
            {
                Console.WriteLine("Duplicate Policy " + num);
            }
        }

        Console.WriteLine("All Unique Policies");
        foreach (Policy p in insertionOrder)
            Console.WriteLine(p.PolicyNumber + " " + p.CoverageType);

        Console.WriteLine("Policies Expiring Within 30 Days");
        foreach (Policy p in expirySorted)
        {
            if ((p.ExpiryDate - DateTime.Now).Days <= 30)
                Console.WriteLine(p.PolicyNumber);
        }

        Console.WriteLine("Enter Coverage Type To Search");
        string searchType = Console.ReadLine();

        foreach (Policy p in insertionOrder)
        {
            if (p.CoverageType == searchType)
                Console.WriteLine(p.PolicyNumber);
        }
    }
}

class Policy : IComparable<Policy>
{
    public string PolicyNumber;
    public string CoverageType;
    public DateTime ExpiryDate;

    public Policy(string n, string c, DateTime d)
    {
        PolicyNumber = n;
        CoverageType = c;
        ExpiryDate = d;
    }

    public int CompareTo(Policy other)
    {
        return ExpiryDate.CompareTo(other.ExpiryDate);
    }
}
