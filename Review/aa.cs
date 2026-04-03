using System;

class CustomStack
{
    private int[] arr;
    private int top;

    public CustomStack(int size)
    {
        arr = new int[size];
        top = -1;
    }

    public void Push(int value)
    {
        arr[++top] = value;
    }

    public int Pop()
    {
        return arr[top--];
    }

    public int Peek()
    {
        return arr[top];
    }

    public bool IsEmpty()
    {
        return top == -1;
    }
}

class ExpressionEvaluator
{
    static int Precedence(char op)
    {
        if (op == '+' || op == '-') return 1;
        if (op == '*' || op == '/') return 2;
        return 0;
    }

    static int ApplyOperator(int b, int a, char op)
    {
        switch (op)
        {
            case '+': return a + b;
            case '-': return a - b;
            case '*': return a * b;
            case '/': return a / b;
        }
        return 0;
    }

    // 🔹 INFIX EVALUATION
    static int EvaluateInfix(string exp)
    {
        CustomStack values = new CustomStack(exp.Length);
        CustomStack ops = new CustomStack(exp.Length);

        foreach (char ch in exp)
        {
            if (ch == ' ') continue;

            if (char.IsDigit(ch))
            {
                values.Push(ch - '0');
            }
            else if (ch == '(')
            {
                ops.Push(ch);
            }
            else if (ch == ')')
            {
                while ((char)ops.Peek() != '(')
                {
                    values.Push(
                        ApplyOperator(values.Pop(), values.Pop(), (char)ops.Pop())
                    );
                }
                ops.Pop(); // remove '('
            }
            else
            {
                while (!ops.IsEmpty() &&
                       Precedence((char)ops.Peek()) >= Precedence(ch))
                {
                    values.Push(
                        ApplyOperator(values.Pop(), values.Pop(), (char)ops.Pop())
                    );
                }
                ops.Push(ch);
            }
        }

        while (!ops.IsEmpty())
        {
            values.Push(
                ApplyOperator(values.Pop(), values.Pop(), (char)ops.Pop())
            );
        }

        return values.Pop();
    }

    static void Main()
    {
        string infix = "(5+3)*(8-2)";
        Console.WriteLine("Infix Result: " + EvaluateInfix(infix));
    }
}
