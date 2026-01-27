using System;

class UserRegistration
{
    public void RegisterUser(string username, string email, string password)
    {
        if (username == "" || email == "" || password == "")
            throw new ArgumentException("Invalid input");

        Console.WriteLine("User Registered Successfully");
    }
}

class Program
{
    static void Main()
    {
        UserRegistration ur = new UserRegistration();
        try
        {
            ur.RegisterUser("raj", "raj@email.com", "Pass1234");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
