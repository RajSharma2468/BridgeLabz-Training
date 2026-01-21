using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<string, int> votes = new Dictionary<string, int>();
        SortedDictionary<string, int> sortedVotes = new SortedDictionary<string, int>();
        LinkedList<string> voteOrder = new LinkedList<string>();

        Console.WriteLine("Enter number of voters");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Enter candidate name");
            string name = Console.ReadLine();

            if (!votes.ContainsKey(name))
                votes[name] = 0;

            votes[name] = votes[name] + 1;
            voteOrder.AddLast(name);
        }

        foreach (var v in votes)
            sortedVotes[v.Key] = v.Value;

        Console.WriteLine("Vote Order");
        foreach (string v in voteOrder)
            Console.WriteLine(v);

        Console.WriteLine("Final Result Sorted");
        foreach (var v in sortedVotes)
            Console.WriteLine(v.Key + " " + v.Value);
    }
}
