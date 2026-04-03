using System;
using System.Collections.Generic;

class EduResultsMain
{
    List<Student> allStudents = new List<Student>();
    MergeSortService sorter = new MergeSortService();

    public void AddDistrictData()
    {
        Console.WriteLine("Enter district name");
        string district = Console.ReadLine();

        Console.WriteLine("Enter number of students");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Enter student name");
            string name = Console.ReadLine();

            Console.WriteLine("Enter marks");
            int marks = int.Parse(Console.ReadLine());

            allStudents.Add(new Student(name, marks, district));
        }

        Console.WriteLine("District data added");
    }

    public void GenerateRankList()
    {
        if (allStudents.Count == 0)
        {
            Console.WriteLine("No student data available");
            return;
        }

        List<Student> sorted = sorter.MergeSort(allStudents);

        Console.WriteLine("State Rank List");
        int rank = 1;

        foreach (Student s in sorted)
        {
            Console.WriteLine(
                rank + " " +
                s.Name + " " +
                s.Marks + " " +
                s.District
            );
            rank++;
        }
    }
}
