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
        arr[++top] = value;a
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
        if (op == '+') return a + b;
        if (op == '-') return a - b;
        if (op == '*') return a * b;
        if (op == '/') return a / b;
        return 0;
    }

    static int Evaluate(string exp)
    {
        CustomStack values = new CustomStack(exp.Length);
        CustomStack ops = new CustomStack(exp.Length);

        for (int i = 0; i < exp.Length; i++)
        {
            char ch = exp[i];

            if (ch == ' ') continue;

            if (ch >= '0' && ch <= '9')
            {
                values.Push(ch - '0');
            }
            else if (ch == '(')
            {
                ops.Push(ch);
            }
            else if (ch == ')')
            {
                while (ops.Peek() != '(')
                {
                    values.Push(
                        ApplyOperator(values.Pop(), values.Pop(), (char)ops.Pop())
                    );
                }
                ops.Pop(); 
            }
            else
            {
                while (!ops.IsEmpty() && Precedence((char)ops.Peek()) >= Precedence(ch))
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


// Main Program
    static void Main()
    {
        string expression = "(5+3)*(8-2)";
        Console.WriteLine("Result: " + Evaluate(expression));

        string postfix = "53+82-*";
        Console.WriteLine("Postfix Result: " + EvaluatePostfix(postfix));

    }
}
