using System;
using System.Collections.Generic;

internal class ExamProctorUtility : IExamProctor
{
    // Stack for navigation
    private Stack<int> questionStack;

    // HashMap for answers (questionId → answer)
    private Dictionary<int, string> answersMap;

    // Question bank
    private Question[] questions;

    public ExamProctorUtility()
    {
        questionStack = new Stack<int>();
        answersMap = new Dictionary<int, string>();

        questions = new Question[]
        {
            new Question(1, "A"),
            new Question(2, "B"),
            new Question(3, "C"),
            new Question(4, "D")
        };
    }

    public void VisitQuestion()
    {
        Console.Write("Enter Question ID to visit: ");
        int qid = int.Parse(Console.ReadLine());

        questionStack.Push(qid);
        Console.WriteLine("Visited Question " + qid);
    }

    public void AnswerQuestion()
    {
        Console.Write("Enter Question ID: ");
        int qid = int.Parse(Console.ReadLine());

        Console.Write("Enter Answer: ");
        string answer = Console.ReadLine();

        answersMap[qid] = answer;
        Console.WriteLine("Answer saved successfully!");
    }

    public void ReviewLastVisited()
    {
        if (questionStack.Count == 0)
        {
            Console.WriteLine("No questions visited yet!");
            return;
        }

        int lastQuestion = questionStack.Peek();
        Console.WriteLine("Last visited question: " + lastQuestion);
    }

    public void SubmitExam()
    {
        Console.WriteLine("\n==== EXAM SUBMISSION ====\n");
        int score = CalculateScore();
        Console.WriteLine("Final Score: " + score + "/" + questions.Length);
    }

    // ---------------- SCORING FUNCTION ----------------
    private int CalculateScore()
    {
        int score = 0;

        for (int i = 0; i < questions.Length; i++)
        {
            int qid = questions[i].QuestionId;

            if (answersMap.ContainsKey(qid) &&
                answersMap[qid].Equals(questions[i].CorrectAnswer))
            {
                score++;
            }
        }
        return score;
    }
}
