internal class ManagerUtility: IManager
{
    private string[] MovieTitles = Program.MovieTitles;
    private string[] Showtimes = Program.Showtimes;
    private int MovieCapacity = Program.MovieCapacity;
    private int Index = Program.Index;
    public bool AuthenticateManager()
    {
        Console.WriteLine("\nAuthencation Window\n");
        Console.Write("Enter your email id: ");
        string emailId = Console.ReadLine();
        Console.Write("Enter your password: ");
        string password = Console.ReadLine();

        if(Manager.ManagerPassword.Equals(password) && Manager.ManagerEmail.Equals(emailId))
        {
            Console.WriteLine("\nAuthentication Successfull!!\n");
            return true;
        }

        Console.WriteLine("\nAuthentication Failed!!\n");
        return false;
    }

    public void AddMovie()
    {
        Console.WriteLine("\n=== Movie Adding Window ===\n");
        Console.Write("Please enter the movie name: ");
        string movieName = Console.ReadLine();
        Console.Write("Please enter the showtime: ");
        string showtime = Console.ReadLine();

        if (Index < MovieCapacity)
        {
            MovieTitles[Index] = movieName;
            Showtimes[Index] = showtime;
            Index++;
            Console.WriteLine("Movie Show added succesfully!!");
        }
        else
        {
            Console.WriteLine("Movie Array Full.");
        }

        Console.WriteLine("\n");
    }

    public void SearchMovie()
    {
        Console.WriteLine("\n=== Movie Searching Window ===\n");
        Console.Write("Please enter movie name: ");
        string movieName = Console.ReadLine();
        bool movieFound = false;
        
        for(int i = 0; i < Index; i++)
        {
            if (MovieTitles[i].Contains(movieName))
            {
                movieFound = true;
                Console.WriteLine("Movie Name: " + MovieTitles[i]);
                Console.WriteLine("Showtime: " + Showtimes[i]);
                Console.WriteLine("\n");
            }
        }

        if (!movieFound)
        {
            Console.WriteLine("No Movie Found...\n");
        }

        Console.WriteLine("\n");

    }

    public void DisplayAllMovies()
    {
        Console.WriteLine("\n=== All Movies Display ===\n");
        for(int i = 0; i < Index; i++)
        {
            Console.WriteLine($"Movie Title: { MovieTitles[i]} | Showtime: {Showtimes[i]}");
        }
        Console.WriteLine("\n");
    }
}