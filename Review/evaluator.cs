using System;

// Custom Stack
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

// Expression Evaluator Utility Class
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

    //  INFIX EVALUATION
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

    //  POSTFIX EVALUATION
    static int EvaluatePostfix(string exp)
    {
        CustomStack stack = new CustomStack(exp.Length);

        foreach (char ch in exp)
        {
            if (char.IsDigit(ch))
            {
                stack.Push(ch - '0');
            }
            else
            {
                int b = stack.Pop();
                int a = stack.Pop();
                stack.Push(ApplyOperator(b, a, ch));
            }
        }
        return stack.Pop();
    }

    
    static void Main()
    {
        string infix = "(5+3)*(8-2)";
        string postfix = "53+82-*";

        Console.WriteLine("Infix Expression Result   : " + EvaluateInfix(infix));
        Console.WriteLine("Postfix Expression Result : " + EvaluatePostfix(postfix));
    }
}
