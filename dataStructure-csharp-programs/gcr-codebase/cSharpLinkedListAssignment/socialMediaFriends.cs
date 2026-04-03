using System;

class UserNode
{
    public string name;
    public UserNode next;

    public UserNode(string name)
    {
        this.name = name;
    }
}

class SocialMedia
{
    UserNode head;

    public void Add(string name)
    {
        UserNode node = new UserNode(name);
        node.next = head;
        head = node;
    }

    public void Display()
    {
        UserNode temp = head;
        while (temp != null)
        {
            Console.WriteLine("User: " + temp.name);
            temp = temp.next;
        }
    }
}

class Program
{
    static void Main()
    {
        SocialMedia sm = new SocialMedia();
        sm.Add("Raj");
        sm.Add("Aman");
        sm.Display();
    }
}
