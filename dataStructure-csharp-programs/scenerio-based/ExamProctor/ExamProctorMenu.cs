using System;

internal class ExamProctorMenu
{
    private ExamProctorUtility exam = new ExamProctorUtility();

    public void ShowMenu()
    {
        int choice;
        do
        {
            Console.WriteLine("\n==== ONLINE EXAM PROCTOR ====");
            Console.WriteLine("1. Visit Question");
            Console.WriteLine("2. Answer Question");
            Console.WriteLine("3. Review Last Visited Question");
            Console.WriteLine("4. Submit Exam");
            Console.WriteLine("5. Exit");
            Console.Write("Enter choice: ");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    exam.VisitQuestion();
                    break;
                case 2:
                    exam.AnswerQuestion();
                    break;
                case 3:
                    exam.ReviewLastVisited();
                    break;
                case 4:
                    exam.SubmitExam();
                    break;
            }
        } while (choice != 5);
    }
}
