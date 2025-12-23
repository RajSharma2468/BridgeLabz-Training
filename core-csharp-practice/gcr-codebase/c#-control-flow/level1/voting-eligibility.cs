using System;

class VotingCheckApp
{
    static void Main()
    {
        int age = Convert.ToInt32(Console.ReadLine());

        if (age >= 18)
            Console.WriteLine("The person's age is " + age + " and can vote.");
        else
            Console.WriteLine("The person's age is " + age + " and cannot vote.");
    }
}
