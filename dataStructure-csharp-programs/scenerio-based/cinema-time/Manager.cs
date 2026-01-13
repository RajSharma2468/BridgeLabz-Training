internal class Manager
{
    public static string ManagerEmail;
    public static string ManagerPassword;
    private static string ManagerName;

    static Manager()
    {
        ManagerEmail = "manager@gmail.com";
        ManagerPassword = "manager";
        ManagerName = "Manager";
    }

    public override string ToString()
    {
        return $"Manager Name: {ManagerName}";
    }
}