using System;

class EduQuiz
{
    static int NumberOfQuestions=10;
    static string[] correctAnswers = {"A", "C", "B", "D", "A","B", "C", "D", "A", "C"};
    static string[] studentAnswers;
    static void Main()
    {
        EduQuiz obj = new EduQuiz();
        studentAnswers = new string[NumberOfQuestions];
        Console.WriteLine("Enter answers for 10 questions (A/B/C/D):");
        for (int i = 0; i < studentAnswers.Length; i++)
        {
            Console.Write($"Question {i + 1}: ");
            studentAnswers[i] = Console.ReadLine();
        }

        int score = obj.CalculateScore();
        obj.DisplayResultWithFeedback(score);
    }

    // Method to calculate score
    int CalculateScore()
    {
        int score = 0;
        for (int i = 0; i < correctAnswers.Length; i++)
        {
            if (string.Equals(correctAnswers[i], studentAnswers[i],StringComparison.OrdinalIgnoreCase))score++;
        }
        return score;
    }

    // Method to display detailed feedback
    void DisplayResultWithFeedback(int score)
    {
        Console.WriteLine("\n--- Quiz Result ---");

        for (int i = 0; i < correctAnswers.Length; i++)
        {
            bool isCorrect = string.Equals(correctAnswers[i], studentAnswers[i],StringComparison.OrdinalIgnoreCase);
            Console.WriteLine(
                $"Question {i + 1}: {(isCorrect ? "Correct" : "Incorrect")}"
            );
        }

        double percentage = (score*100.0)/NumberOfQuestions;
        Console.WriteLine($"\nTotal Score: {score}/10");
        Console.WriteLine($"Percentage: {percentage}%");

        if (percentage >= 40)
            Console.WriteLine("Result: PASS ✅");
        else
            Console.WriteLine("Result: FAIL ❌");
    }
}