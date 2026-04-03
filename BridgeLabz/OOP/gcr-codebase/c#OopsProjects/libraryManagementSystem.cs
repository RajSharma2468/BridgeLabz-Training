using System;
using System.Collections.Generic;

#region Interface
interface IBorrowable
{
    void BorrowBook();
}
#endregion

#region Abstract Class
abstract class LibraryItem
{
    private int itemId;
    private string title;
    protected bool isAvailable;

    public int ItemId
    {
        get { return itemId; }
    }

    public string Title
    {
        get { return title; }
    }

    protected LibraryItem(int id, string name)
    {
        itemId = id;
        title = name;
        isAvailable = true;
    }

    public abstract int GetLoanDays();

    public virtual void DisplayDetails()
    {
        Console.WriteLine("Item ID     : " + itemId);
        Console.WriteLine("Title       : " + title);
        Console.WriteLine("Available   : " + isAvailable);
        Console.WriteLine("Loan Days   : " + GetLoanDays());
    }
}
#endregion

#region Book
class Book : LibraryItem, IBorrowable
{
    public Book(int id, string name) : base(id, name)
    {
    }

    public override int GetLoanDays()
    {
        return 14;
    }

    public void BorrowBook()
    {
        if (isAvailable)
        {
            isAvailable = false;
            Console.WriteLine("Book Borrowed Successfully");
        }
        else
        {
            Console.WriteLine("Book Not Available");
        }
    }
}
#endregion

#region Magazine
class Magazine : LibraryItem, IBorrowable
{
    public Magazine(int id, string name) : base(id, name)
    {
    }

    public override int GetLoanDays()
    {
        return 7;
    }

    public void BorrowBook()
    {
        if (isAvailable)
        {
            isAvailable = false;
            Console.WriteLine("Magazine Borrowed Successfully");
        }
        else
        {
            Console.WriteLine("Magazine Not Available");
        }
    }
}
#endregion

#region Main Program
class Program
{
    static void Main()
    {
        List<LibraryItem> items = new List<LibraryItem>();

        while (true)
        {
            Console.WriteLine("\nLIBRARY MANAGEMENT SYSTEM");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Add Magazine");
            Console.WriteLine("3. Borrow Item");
            Console.WriteLine("4. Display Items");
            Console.WriteLine("5. Exit");
            Console.Write("Enter Choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddBook(items);
                    break;

                case 2:
                    AddMagazine(items);
                    break;

                case 3:
                    BorrowItem(items);
                    break;

                case 4:
                    DisplayItems(items);
                    break;

                case 5:
                    return;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }

    static void AddBook(List<LibraryItem> items)
    {
        Console.Write("Enter Book ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Enter Book Title: ");
        string title = Console.ReadLine();

        items.Add(new Book(id, title));
        Console.WriteLine("Book Added");
    }

    static void AddMagazine(List<LibraryItem> items)
    {
        Console.Write("Enter Magazine ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Enter Magazine Title: ");
        string title = Console.ReadLine();

        items.Add(new Magazine(id, title));
        Console.WriteLine("Magazine Added");
    }

    static void BorrowItem(List<LibraryItem> items)
    {
        Console.Write("Enter Item ID: ");
        int id = int.Parse(Console.ReadLine());

        foreach (LibraryItem item in items)
        {
            if (item.ItemId == id && item is IBorrowable)
            {
                ((IBorrowable)item).BorrowBook();
                return;
            }
        }

        Console.WriteLine("Item Not Found");
    }

    static void DisplayItems(List<LibraryItem> items)
    {
        Console.WriteLine("\nLIBRARY ITEMS\n");

        foreach (LibraryItem item in items)
        {
            item.DisplayDetails();
            Console.WriteLine("----------------------");
        }
    }
}
#endregion
