internal class Program
{
    public static Book[] Books;
    public static int BookCapacity;
    public static int Index;
    static Program()
    {
        BookCapacity = 10;
        Index = 0;
        Books = new Book[BookCapacity];
    }
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        menu.ShowMenu();
    }
}