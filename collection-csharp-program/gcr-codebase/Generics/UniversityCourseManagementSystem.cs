using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== University Course Management System ===\n");

        // Step 1: Initialize courses
        List<string> courseNames = new List<string>
        {
            "Data Structures", "Operating Systems", "Database Systems",
            "English", "Physics", "Mathematics", "Chemistry", "Machine Learning"
        };

        List<string> departments = new List<string>
        {
            "Computer Science", "Computer Science", "Computer Science",
            "Humanities", "Science", "Science", "Science", "Computer Science"
        };

        List<string> evaluationType = new List<string>
        {
            "Exam", "Exam", "Assignment",
            "Assignment", "Exam", "Exam", "Assignment", "Exam"
        };

        List<int> credits = new List<int>
        {
            4, 4, 3, 2, 3, 4, 2, 4
        };

        List<int> maxMarks = new List<int>
        {
            100, 100, 50, 50, 100, 100, 50, 100
        };

        // Step 2: User input to add a new course
        Console.WriteLine("Do you want to add a new course? (yes/no)");
        string response = Console.ReadLine().ToLower();
        if (response == "yes")
        {
            Console.Write("Enter Course Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Department: ");
            string dept = Console.ReadLine();
            Console.Write("Enter Evaluation Type (Exam/Assignment): ");
            string eval = Console.ReadLine();
            Console.Write("Enter Credits: ");
            int credit = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Max Marks: ");
            int marks = Convert.ToInt32(Console.ReadLine());

            courseNames.Add(name);
            departments.Add(dept);
            evaluationType.Add(eval);
            credits.Add(credit);
            maxMarks.Add(marks);

            Console.WriteLine("\nCourse added successfully!\n");
        }

        // Step 3: Display all courses
        Console.WriteLine("=== All Courses ===\n");
        for (int i = 0; i < courseNames.Count; i++)
        {
            Console.WriteLine("Course Name      : " + courseNames[i]);
            Console.WriteLine("Department       : " + departments[i]);
            Console.WriteLine("Evaluation Type  : " + evaluationType[i]);
            Console.WriteLine("Credits          : " + credits[i]);
            Console.WriteLine("Max Marks        : " + maxMarks[i]);
            Console.WriteLine(new string('-', 50));
        }

        // Step 4: Sort courses by credits
        Console.WriteLine("\n=== Courses Sorted by Credits (Ascending) ===\n");

        List<int> sortedIndices = new List<int>();
        for (int i = 0; i < courseNames.Count; i++)
            sortedIndices.Add(i);

        // Bubble sort indices based on credits
        for (int i = 0; i < sortedIndices.Count - 1; i++)
        {
            for (int j = 0; j < sortedIndices.Count - i - 1; j++)
            {
                if (credits[sortedIndices[j]] > credits[sortedIndices[j + 1]])
                {
                    int temp = sortedIndices[j];
                    sortedIndices[j] = sortedIndices[j + 1];
                    sortedIndices[j + 1] = temp;
                }
            }
        }

        for (int i = 0; i < sortedIndices.Count; i++)
        {
            int idx = sortedIndices[i];
            Console.WriteLine("Course: " + courseNames[idx] + " | Department: " + departments[idx] +
                              " | Credits: " + credits[idx] + " | Max Marks: " + maxMarks[idx] +
                              " | Evaluation: " + evaluationType[idx]);
        }

        // Step 5: Display courses by department
        Console.WriteLine("\n=== Courses by Department ===\n");
        List<string> departmentsPrinted = new List<string>();
        for (int i = 0; i < departments.Count; i++)
        {
            string dept = departments[i];
            if (!departmentsPrinted.Contains(dept))
            {
                departmentsPrinted.Add(dept);
                Console.WriteLine("Department: " + dept);
                for (int j = 0; j < courseNames.Count; j++)
                {
                    if (departments[j] == dept)
                    {
                        Console.WriteLine("  - " + courseNames[j] + " | Credits: " + credits[j] +
                                          " | Max Marks: " + maxMarks[j] + " | Evaluation: " + evaluationType[j]);
                    }
                }
                Console.WriteLine();
            }
        }

        Console.WriteLine("=== University Course Management Display Completed Successfully ===");
    }
}
