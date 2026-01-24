using System;
using System.Reflection;

/* Custom Attribute */
[AttributeUsage(AttributeTargets.Field)]
class MaxLengthAttribute : Attribute
{
    public int Length;

    public MaxLengthAttribute(int length)
    {
        Length = length;
    }
}

/* User Class */
class User
{
    [MaxLength(5)]
    public string Username;

    public User(string username)
    {
        FieldInfo field = this.GetType().GetField("Username");
        MaxLengthAttribute attr =
            (MaxLengthAttribute)Attribute.GetCustomAttribute(
                field, typeof(MaxLengthAttribute));

        if (attr != null && username.Length > attr.Length)
        {
            throw new ArgumentException(
                "Username length exceeds " + attr.Length);
        }

        Username = username;
    }
}

/* Main Program */
class Program
{
    static void Main()
    {
        try
        {
            User u1 = new User("Raj");
            Console.WriteLine("Username set: " + u1.Username);

            User u2 = new User("RajSharma"); // Will throw exception
            Console.WriteLine("Username set: " + u2.Username);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
