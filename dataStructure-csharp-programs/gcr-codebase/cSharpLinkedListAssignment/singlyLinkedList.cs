using System;

class StudentNode
{
    public int rollNo;
    public string name;
    public int age;
    public string grade;
    public StudentNode next;

    public StudentNode(int rollNo, string name, int age, string grade)
    {
        this.rollNo = rollNo;
        this.name = name;
        this.age = age;
        this.grade = grade;
        next = null;
    }
}

class StudentLinkedList
{
    StudentNode head;

    public void Add(int rollNo, string name, int age, string grade)
    {
        StudentNode node = new StudentNode(rollNo, name, age, grade);
        if (head == null)
        {
            head = node;
            return;
        }

        StudentNode temp = head;
        while (temp.next != null)
            temp = temp.next;

        temp.next = node;
    }

    public void Display()
    {
        StudentNode temp = head;
        while (temp != null)
        {
            Console.WriteLine(
                temp.rollNo + " " +
                temp.name + " " +
                temp.age + " " +
                temp.grade
            );
            temp = temp.next;
        }
    }
}

class Program
{
    static void Main()
    {
        StudentLinkedList list = new StudentLinkedList();
        list.Add(1, "Rahul", 20, "A");
        list.Add(2, "Amit", 21, "B");
        list.Display();
    }
}
