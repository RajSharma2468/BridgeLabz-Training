using System;

[AttributeUsage(AttributeTargets.Method)]
class RoleAllowedAttribute : Attribute
{
    public string Role;
    public RoleAllowedAttribute(string role)
    {
        Role = role;
    }
}

class AdminPanel
{
    [RoleAllowed("ADMIN")]
    public void DeleteUser()
    {
        Console.WriteLine("User Deleted");
    }
}

class Program
{
    static void Main()
    {
        string currentRole = "USER";
        AdminPanel panel = new AdminPanel();

        var method = typeof(AdminPanel).GetMethod("DeleteUser");
        RoleAllowedAttribute attr =
            (RoleAllowedAttribute)Attribute.GetCustomAttribute(
                method, typeof(RoleAllowedAttribute));

        if (attr.Role == currentRole)
            method.Invoke(panel, null);
        else
            Console.WriteLine("Access Denied!");
    }
}
