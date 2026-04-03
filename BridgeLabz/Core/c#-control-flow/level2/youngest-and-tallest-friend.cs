using System;

class FriendCompareApp
{
    static void Main()
    {
        int ageAmar = Convert.ToInt32(Console.ReadLine());
        int ageAkbar = Convert.ToInt32(Console.ReadLine());
        int ageAnthony = Convert.ToInt32(Console.ReadLine());

        int heightAmar = Convert.ToInt32(Console.ReadLine());
        int heightAkbar = Convert.ToInt32(Console.ReadLine());
        int heightAnthony = Convert.ToInt32(Console.ReadLine());

        if (ageAmar < ageAkbar && ageAmar < ageAnthony)
            Console.WriteLine("Amar is the youngest");
        else if (ageAkbar < ageAmar && ageAkbar < ageAnthony)
            Console.WriteLine("Akbar is the youngest");
        else
            Console.WriteLine("Anthony is the youngest");

        if (heightAmar > heightAkbar && heightAmar > heightAnthony)
            Console.WriteLine("Amar is the tallest");
        else if (heightAkbar > heightAmar && heightAkbar > heightAnthony)
            Console.WriteLine("Akbar is the tallest");
        else
            Console.WriteLine("Anthony is the tallest");
    }
}
