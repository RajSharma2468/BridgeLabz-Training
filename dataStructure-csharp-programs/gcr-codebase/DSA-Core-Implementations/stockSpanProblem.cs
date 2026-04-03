using System;

class StockSpan
{
    static void CalculateSpan(int[] price)
    {
        int n = price.Length;
        int[] span = new int[n];
        int[] stack = new int[n];
        int top = -1;

        for (int i = 0; i < n; i++)
        {
            while (top != -1 && price[stack[top]] <= price[i])
                top--;

            span[i] = (top == -1) ? i + 1 : i - stack[top];
            stack[++top] = i;
        }

        for (int i = 0; i < n; i++)
            Console.Write(span[i] + " ");
    }

    static void Main()
    {
        int[] price = { 100, 80, 60, 70, 60, 75, 85 };
        CalculateSpan(price);
    }
}
