using System;

class Program
{
    static void Main()
    {
        EduResultsMain system = new EduResultsMain();

        while (true)
        {
            EduResultsMenu.Show();
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                system.AddDistrictData();
            }
            else if (choice == 2)
            {
                system.GenerateRankList();
            }
            else
            {
                break;
            }
        }
    }
}
