using System;
using System.IO;

class UserInputToFile
{
    static void Main()
    {
        try
        {
            StreamReader reader = new StreamReader(Console.OpenStandardInput());
            using (StreamWriter writer = new StreamWriter("userData.txt"))
            {
                Console.Write("Enter Name: ");
                string name = reader.ReadLine();

                Console.Write("Enter Age: ");
                string age = reader.ReadLine();

                Console.Write("Favorite Programming Language: ");
                string lang = reader.ReadLine();

                writer.WriteLine("Name: " + name);
                writer.WriteLine("Age: " + age);
                writer.WriteLine("Language: " + lang);
            }

            Console.WriteLine("Data saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
