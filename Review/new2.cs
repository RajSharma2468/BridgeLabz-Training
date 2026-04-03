using System;
using System.Linq.Expressions;

class CustomStack
{
    private int[] arr;
    private int top;

    public CustomStack(int size)
    {
        arr = new int[size];
        top = -1;
    }
    public void push(int value)
    {
        arr[++top]=value;
    }

    public int pop()
    {
        return arr[top--];
    }

    public int peak()
    {
        return top;
    }

    public bool IsEmpty()
    {
        return top==-1;
    }
}
    class ExpressionEvaluator
    {
        static int Precedence(char op)
        {
            if(op=='+' ||op=='-' ) return 1;
            if(op=='/' || op=='*') return 2;
            return 0;
        }
        static int ApplyOperator(int b,int a,char op)
        {
            if(op='+') return a+b;
            if(op='-') return a-b;
            if(op='*') return a*b;
            if(op='/') return a/b;
            return 0;
        }
        static int Evaluate(String exp)
        {
            CustomStack values=new CustomStack(exp.Length);
            CustomStack ops=new CustomStack(exp.Length);

            for(int i = 0; i < exp.Length; i++)
            {
                char ch=exp[i];
                if(ch ==' ') continue;

                if(ch>0 && ch <= 9)
                {
                    values.push(ch- '0');
                }
                else if(ch == '(')
                {
                    ops.push(ch);
                }
                else if(ch == ')')
                {
                    while (ops.peak() !='(')
                    {
                        values.push(ApplyOperator(values.pop(),(char)ops.pop()));
                    }
                    ops.pop();
                }
                else
                {
                    while(!ops.IsEmpty() && Precedence((char)ops.peak()) >= Precedence(ch))
                    {
                        values.push(ApplyOperator(values.pop,values.pop,(char)ops.pop()));
                        ops.push(ch);
                    }
                    return values.pop;
                }
            
                 static void Main()
                {
                    static Expression = "(5+3)*(8-2)";
                    Console.WriteLine("Result: "+Evaluate(Expression));
                }
            
            
    }
    

