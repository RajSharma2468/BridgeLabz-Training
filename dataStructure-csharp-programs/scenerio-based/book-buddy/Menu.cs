internal class Menu
{
    private IBook bookUtility;
    public void ShowMenu()
    {
        bookUtility = new BookUtility();
        Console.WriteLine("\n==== Book Buddy ====\n");
        int choice;
        do
        {
            Console.WriteLine("1. Add Book.");
            Console.WriteLine("2. Search By Author.");
            Console.WriteLine("3. Search By Title.");
            Console.WriteLine("4. Update Book");
            Console.WriteLine("5. Display all Books.");
            Console.WriteLine("6.Sort by Title");
            Console.WriteLine("7. Sort by Author");
            Console.WriteLine("0. Exit");
            Console.Write("Enter your choice: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    bookUtility.AddBook();
                    break;
                case 2:
                    bookUtility.SearchByAuthor();
                    break;
                case 3:
                    bookUtility.SearchByTitle();
                    break;
                case 4:
                    bookUtility.UpdateBook();
                    break;
                case 5:
                    bookUtility.DisplayAllBooks();
                    break;
                case 6:
                    bookUtility.SortByTitle();
                    break;
                case 7:
                    bookUtility.SortByAuthor();
                    break;

            }
        } while (choice != 0);
    }
}