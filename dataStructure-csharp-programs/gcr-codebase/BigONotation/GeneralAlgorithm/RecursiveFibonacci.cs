using System;
using System.Collections.Generic;

class FibonacciMemo
{
    static Dictionary<int, int> memo = new Dictionary<int, int>();

    static int Fib(int n)
    {
        if (n <= 1) return n;

        if (memo.ContainsKey(n))
            return memo[n];

        int result = Fib(n - 1) + Fib(n - 2);
        memo[n] = result;
        return result;
    }

    static void Main()
    {
        Console.WriteLine(Fib(10));
    }
}
