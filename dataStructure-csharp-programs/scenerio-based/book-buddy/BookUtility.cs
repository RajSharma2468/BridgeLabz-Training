internal class BookUtility: IBook
{
    private Book[] books = Program.Books;
    private int booksCapacity = Program.BookCapacity;
    private int index = Program.Index;

    public void AddBook()
    {
        Console.WriteLine("\n==== Book Adding Window ====\n");
        if(!(index < booksCapacity))
        {
            Console.WriteLine("\nNot enough capacity in the book array\n");
        }
        else
        {
            Console.Write("Please enter book title: ");
            string title = Console.ReadLine();
            Console.Write("Please enter book author: ");
            string author = Console.ReadLine();

            Book book = new Book(title, author);

            books[index++] = book;
            Console.WriteLine("\nBook added successfully\n");
        }
    }

    public void SearchByAuthor()
    {
        Console.WriteLine("\n==== Searching Book by Author ====\n");
        Console.Write("Please enter book author: ");
        string author = Console.ReadLine();
        bool bookFound = false;

        foreach (Book book in books)
        {
            if (book != null && book.GetAuthor().Equals(author))
            {
                Console.WriteLine(book);
                bookFound = true;
            }
        }

        if (!bookFound)
        {
            Console.WriteLine("\nBook not found\n");
        }
    }

    public void SearchByTitle()
    {
        Console.WriteLine("\n==== Searching Book by Title ====\n");
        Console.Write("Please enter book title: ");
        string title = Console.ReadLine();
        bool bookFound = false;

        foreach (Book book in books)
        {
            if (book != null && book.GetTitle().Equals(title))
            {
                Console.WriteLine(book);
                bookFound = true;
            }
        }

        if (!bookFound)
        {
            Console.WriteLine("\nBook not found\n");
        }
    }

    public void UpdateBook()
    {
        Console.WriteLine("\n==== Book Updation Window ====\n");
        Console.Write("Please enter the book name you want to update: ");
        string bookOldName = Console.ReadLine();
        Console.Write("Please enter the book's updated name: ");
        string bookNewName = Console.ReadLine();
        bool bookFound = false;

        foreach(Book book in books)
        {
            if (book != null && book.GetTitle().Equals(bookOldName))
            {
                book.SetTitle(bookNewName);
                bookFound = true;
            }
        }

        if (!bookFound)
        {
            Console.WriteLine("\nBook not found...\n");
        }
    }

    public void DisplayAllBooks()
    {
        Console.WriteLine("\n==== All Books ====\n");
        foreach(Book book in books)
        {
            if(book != null) Console.WriteLine(book);
        }
    }

    public void SortByTitle()
    {
        Console.WriteLine("\n==== Books sorted by Title ====\n");
        for (int i = 0; i < index - 1; i++)
        {
            for (int j = 0; j < index - i - 1; j++)
            {
                if (books[j] == null || books[j + 1] == null)
                    continue;

                if (string.Compare(books[j].GetTitle(), books[j + 1].GetTitle(), StringComparison.OrdinalIgnoreCase) > 0)
                {
                    Book temp = books[j];
                    books[j] = books[j + 1];
                    books[j + 1] = temp;
                }
            }
            DisplayAllBooks();
        }
    }

    public void SortByAuthor()
    {
        Console.WriteLine("\n==== Books sorted by Author ====\n");
        for (int i = 0; i < index - 1; i++)
        {
            for (int j = 0; j < index - i - 1; j++)
            {
                if (books[j] == null || books[j + 1] == null)
                    continue;

                if (string.Compare(books[j].GetAuthor(), books[j + 1].GetAuthor(), StringComparison.OrdinalIgnoreCase) > 0)
                {
                    Book temp = books[j];
                    books[j] = books[j + 1];
                    books[j + 1] = temp;
                }
            }
        }
        DisplayAllBooks();
    }
}