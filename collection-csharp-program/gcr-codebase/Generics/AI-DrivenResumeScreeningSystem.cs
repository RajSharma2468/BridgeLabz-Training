using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== AI-Driven Resume Screening System ===\n");

        // Step 1: Initialize job roles and candidate data
        List<string> candidateNames = new List<string>
        {
            "Raj Sharma", "Anita Verma", "Siddharth Singh", "Neha Kapoor", "Arjun Patel"
        };

        List<string> jobRoles = new List<string>
        {
            "Software Engineer", "Data Scientist", "Software Engineer", "Designer", "Data Scientist"
        };

        List<int> experienceYears = new List<int>
        {
            2, 3, 1, 4, 2
        };

        List<string> skills = new List<string>
        {
            "C#, SQL", "Python, ML", "Java, HTML", "Photoshop, Illustrator", "Python, SQL"
        };

        // Step 2: User input to add new candidate
        Console.WriteLine("Do you want to add a new candidate? (yes/no)");
        string response = Console.ReadLine().ToLower();
        if (response == "yes")
        {
            Console.Write("Enter Candidate Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Job Role: ");
            string role = Console.ReadLine();
            Console.Write("Enter Experience (in years): ");
            int exp = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Skills (comma separated): ");
            string skill = Console.ReadLine();

            candidateNames.Add(name);
            jobRoles.Add(role);
            experienceYears.Add(exp);
            skills.Add(skill);

            Console.WriteLine("\nCandidate added successfully!\n");
        }

        // Step 3: Display all candidates
        Console.WriteLine("=== All Candidates ===\n");
        for (int i = 0; i < candidateNames.Count; i++)
        {
            Console.WriteLine("Candidate Name : " + candidateNames[i]);
            Console.WriteLine("Job Role       : " + jobRoles[i]);
            Console.WriteLine("Experience     : " + experienceYears[i] + " years");
            Console.WriteLine("Skills         : " + skills[i]);
            Console.WriteLine(new string('-', 50));
        }

        // Step 4: Sort candidates by experience
        Console.WriteLine("\n=== Candidates Sorted by Experience (Descending) ===\n");

        List<int> sortedIndices = new List<int>();
        for (int i = 0; i < candidateNames.Count; i++)
            sortedIndices.Add(i);

        // Bubble sort indices by experience descending
        for (int i = 0; i < sortedIndices.Count - 1; i++)
        {
            for (int j = 0; j < sortedIndices.Count - i - 1; j++)
            {
                if (experienceYears[sortedIndices[j]] < experienceYears[sortedIndices[j + 1]])
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
            Console.WriteLine("Candidate: " + candidateNames[idx] + " | Job Role: " + jobRoles[idx] + 
                              " | Experience: " + experienceYears[idx] + " years | Skills: " + skills[idx]);
        }

        // Step 5: Display candidates by job role
        Console.WriteLine("\n=== Candidates by Job Role ===\n");
        List<string> rolesPrinted = new List<string>();
        for (int i = 0; i < jobRoles.Count; i++)
        {
            string role = jobRoles[i];
            if (!rolesPrinted.Contains(role))
            {
                rolesPrinted.Add(role);
                Console.WriteLine("Job Role: " + role);
                for (int j = 0; j < candidateNames.Count; j++)
                {
                    if (jobRoles[j] == role)
                    {
                        Console.WriteLine("  - " + candidateNames[j] + " | Experience: " + experienceYears[j] +
                                          " years | Skills: " + skills[j]);
                    }
                }
                Console.WriteLine();
            }
        }

        // Step 6: Filter candidates with experience >= 3 years
        Console.WriteLine("=== Candidates with 3+ Years Experience ===\n");
        for (int i = 0; i < candidateNames.Count; i++)
        {
            if (experienceYears[i] >= 3)
            {
                Console.WriteLine("Candidate: " + candidateNames[i] + " | Job Role: " + jobRoles[i] +
                                  " | Experience: " + experienceYears[i] + " years | Skills: " + skills[i]);
            }
        }

        Console.WriteLine("\n=== Resume Screening Completed Successfully ===");
    }
}
