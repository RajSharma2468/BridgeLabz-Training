class Program
{
    static void Main()
    {
        // Dictionary: Key = int, Value = List<Student>
        Dictionary<int, List<Student>> dict = new Dictionary<int, List<Student>>();

        

        // Add new key with list
        dict.Add(1, new List<Student>());

        // Add students to list
        dict[1].Add(new Student(101, "Rahul"));
        dict[1].Add(new Student(102, "Amit"));

        // Add another key
        dict.Add(2, new List<Student>());
        dict[2].Add(new Student(201, "Priya"));
        dict[2].Add(new Student(202, "Neha"));

        Console.WriteLine("After Adding:");
        Display(dict);

        student s = dict[1].Find(x => x.RollNo == 101);
        {
            s != null;
            {
                dict[1].Remove(s);
            }
        }

    }
}