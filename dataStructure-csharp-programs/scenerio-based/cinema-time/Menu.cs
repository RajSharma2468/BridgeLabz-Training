internal class Menu
{
    private IManager utility;

    public Menu()
    {
        utility = new ManagerUtility();
    }
    public void ShowMenu()
    {
        Console.WriteLine("\n===== Welcome to the Movie Console ========\n");
        int choice;

        Console.WriteLine("Are you admin (y/n)?: ");
        char isAdmin = Console.ReadLine()[0];

        if (isAdmin != 'y' && isAdmin != 'n')
        {
            Console.WriteLine("Invalid Choice");
            return;
        }

        bool isAuthenticated = false;
        if (isAdmin == 'y') isAuthenticated = utility.AuthenticateManager();

        do
        {
            if (isAdmin == 'y' && isAuthenticated)
            {
                Console.WriteLine("0. Add a movie show.");
            }
            Console.WriteLine("1. Search a movie show");
            Console.WriteLine("2. Display all movie shows");
            Console.WriteLine("3. Exit");
            Console.Write("Please enter your choice: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 0:
                    if (isAuthenticated)
                    {
                        utility.AddMovie();
                    }
                    else
                    {
                        Console.WriteLine("You are not authenticated");
                    }
                    break;
                case 1:
                    utility.SearchMovie();
                    break;
                case 2:
                    utility.DisplayAllMovies();
                    break;
            }

        } while (choice != 3);
    }
}