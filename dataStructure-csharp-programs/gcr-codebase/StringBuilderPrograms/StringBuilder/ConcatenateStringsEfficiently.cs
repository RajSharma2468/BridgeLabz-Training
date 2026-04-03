using System;
using System.Text;

class Program
{
    static void Main()
    {
        string[] arr = { "Hello", " ", "World" };
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < arr.Length; i++)
        {
            sb.Append(arr[i]);
        }

        Console.WriteLine(sb.ToString());
    }
}
