using System;

class MathUtils
{
    public int Divide(int a, int b)
    {
        if (b == 0)
            throw new ArithmeticException("Division by zero not allowed");
        return a / b;
    }
}

class Program
{
    static void Main()
    {
        MathUtils m = new MathUtils();
        try
        {
            Console.WriteLine(m.Divide(10, 0));
        }
        catch (ArithmeticException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
