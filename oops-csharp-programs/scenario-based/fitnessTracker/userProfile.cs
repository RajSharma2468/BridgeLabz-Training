class UserProfile
{
    private string userName;
    private int age;

    public UserProfile(string name, int age)
    {
        userName = name;
        this.age = age;
    }

    public void DisplayUser()
    {
        Console.WriteLine("User Name : " + userName);
        Console.WriteLine("Age       : " + age);
    }
}
