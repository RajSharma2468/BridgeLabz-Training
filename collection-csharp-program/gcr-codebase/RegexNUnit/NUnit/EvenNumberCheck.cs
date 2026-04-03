using System;

class NumberUtils
{
    public bool IsEven(int number)
    {
        return number % 2 == 0;
    }
}

class Program
{
    static void Main()
    {
        NumberUtils n = new NumberUtils();
        int[] values = { 2, 4, 6, 7, 9 };

        foreach (int v in values)
        {
            Console.WriteLine(v + " is even? " + n.IsEven(v));
        }
    }
}
