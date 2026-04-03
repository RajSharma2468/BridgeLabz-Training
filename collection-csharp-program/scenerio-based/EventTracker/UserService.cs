using System;

public class UserService
{
    [AuditTrail("User Login")]
    public void Login()
    {
        Console.WriteLine("User logged in successfully.");
    }

    [AuditTrail("User Logout")]
    public void Logout()
    {
        Console.WriteLine("User logged out.");
    }
}
