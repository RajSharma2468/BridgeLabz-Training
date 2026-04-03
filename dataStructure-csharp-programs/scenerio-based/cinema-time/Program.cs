internal class Program
{
    public static string[] MovieTitles;
    public static string[] Showtimes;
    public static int MovieCapacity = 10;
    public static int Index = 0;

    static Program(){
        MovieTitles = new string[MovieCapacity];
        Showtimes = new string[MovieCapacity];
    }
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        menu.ShowMenu();
    }
}