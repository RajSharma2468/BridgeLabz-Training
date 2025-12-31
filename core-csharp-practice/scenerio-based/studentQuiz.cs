using System;

class EduQuizSystem
{
    static int totalQuestions;
    static string[] answerKey;
    string[] userAnswers;

    string adminId = "admin@gmail.com";
    string adminPass = "admin123";

    static void Main(string[] args)
    {
        EduQuizSystem app = new EduQuizSystem();
        app.Initialize();
    }

    void Initialize()
    {
        totalQuestions = 10;
        answerKey = new string[] { "a1","a2","a3","a4","a5","a6","a7","a8","a9","a10" };
        userAnswers = new string[totalQuestions];

        Console.WriteLine("\n========== EDUQUIZ SYSTEM ==========\n");
        ShowLoginMenu();
    }

    void ShowLoginMenu()
    {
        while (true)
        {
            Console.WriteLine("\n1. Admin Login");
            Console.WriteLine("2. Student Login");
            Console.WriteLine("3. Exit");
            Console.Write("Enter choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    if (VerifyAdmin())
                        while (AdminPanel()) ;
                    break;

                case 2:
                    while (StudentPanel()) ;
                    break;

                case 3:
                    return;
            }
        }
    }

    bool StudentPanel()
    {
        Console.WriteLine("\n--- Student Menu ---");
        Console.WriteLine("1. Attempt Quiz");
        Console.WriteLine("2. Exit");
        Console.Write("Choice: ");

        int option = int.Parse(Console.ReadLine());

        if (option == 1)
            TakeQuiz();
        else
            return false;

        return true;
    }

    void TakeQuiz()
    {
        for (int i = 0; i < totalQuestions; i++)
        {
            Console.Write("Answer for Question " + (i + 1) + ": ");
            userAnswers[i] = Console.ReadLine();
        }

        Console.WriteLine("\n----- RESULT -----\n");

        int score = EvaluateScore();
        double percent = GetPercentage(score);

        Console.WriteLine("Score: " + score + "/" + totalQuestions);
        Console.WriteLine("Percentage: " + percent + "%");

        Console.WriteLine(percent >= 50 ? "Status: PASS" : "Status: FAIL");
    }

    int EvaluateScore()
    {
        int score = 0;

        for (int i = 0; i < totalQuestions; i++)
        {
            if (string.Equals(answerKey[i], userAnswers[i],
                StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Question " + (i + 1) + ": Correct");
                score++;
            }
            else
            {
                Console.WriteLine("Question " + (i + 1) + ": Incorrect");
                Console.WriteLine("Correct Answer: " + answerKey[i]);
            }
            Console.WriteLine();
        }
        return score;
    }

    double GetPercentage(int score)
    {
        return ((double)score / totalQuestions) * 100;
    }

    bool AdminPanel()
    {
        Console.WriteLine("\n--- Admin Menu ---");
        Console.WriteLine("1. Modify Answer Key");
        Console.WriteLine("2. View Answer Key");
        Console.WriteLine("3. Logout");
        Console.Write("Choice: ");

        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                UpdateAnswerKey();
                break;

            case 2:
                ShowAnswerKey();
                break;

            case 3:
                return false;
        }
        return true;
    }

    void ShowAnswerKey()
    {
        for (int i = 0; i < totalQuestions; i++)
            Console.WriteLine("Q" + (i + 1) + " : " + answerKey[i]);
    }

    void UpdateAnswerKey()
    {
        for (int i = 0; i < totalQuestions; i++)
        {
            Console.Write("New answer for Question " + (i + 1) + ": ");
            answerKey[i] = Console.ReadLine();
        }
        Console.WriteLine("Answer key updated successfully.");
    }

    bool VerifyAdmin()
    {
        Console.Write("Admin Email: ");
        string email = Console.ReadLine();
        Console.Write("Admin Password: ");
        string pass = Console.ReadLine();

        if (email == adminId && pass == adminPass)
        {
            Console.WriteLine("Login successful");
            return true;
        }

        Console.WriteLine("Invalid credentials");
        return false;
    }
}
