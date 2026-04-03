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
