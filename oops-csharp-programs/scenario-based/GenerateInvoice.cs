using System;
class GenerateInvoice
{
    private string[] Task;
    private int TaskCounter;
    private double[] Amount;
    private double TotalAmount;

    static GenerateInvoice()
    {
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine("|            Application Started              |");
        Console.WriteLine("----------------------------------------------");
    }

    static void Main()
    {
        GenerateInvoice obj = new GenerateInvoice();
        Console.WriteLine("\nEnter Tasks And Amount In given Format   :  \"Logo Design - 3000 INR, Web Page - 4500 INR\".  ");
        string Input = Console.ReadLine();
        obj.ParseString(Input);
        Console.WriteLine("\nPress 1. To Generate Invoice \nPress 2. To Get Total Amount\nPress 3. To Exit");
        int IP = int.Parse(Console.ReadLine());
        switch (IP)
        {
            case 1:
                Console.WriteLine("\n\n============================Generating Invoice=======================>\n\n");
                obj.GetTotalInvoice();
                break;
            case 2:
                Console.WriteLine($"Total Amount : {obj.TotalAmount}");
                break;
            case 3:
                Console.WriteLine("\n===================Program End=====================>");
                break;
            
            default:
                Console.WriteLine("\nInvalid Input===== Try Again==== :");
                break;
        }
       
    }



    void GetTotalInvoice()
    {
        if (TaskCounter == 0)
        {
            Console.WriteLine("No Task Assinged============>");
            return;
        }
        for(int i = 0; i < TaskCounter; i++)
        {
            Console.WriteLine($"Task : {Task[i]}  Amount : {Amount[i]}");
            TotalAmount += Amount[i];
        }
        Console.WriteLine($"\nTotal Amount {TotalAmount}");
    }

    void ParseString(string Input)
    {
        string[] Tasks = Input.Split(',');
        Task = new string[Tasks.Length];
        Amount = new double[Tasks.Length];
        for(int i = 0; i < Tasks.Length; i++)
        {
            string[] data = Tasks[i].Split('-');
            Task[TaskCounter] = data[0];
            Amount[TaskCounter] = Convert.ToDouble(data[1].Replace("INR","").Trim());
            TotalAmount += Amount[TaskCounter];
            TaskCounter++;
        }
    }

}