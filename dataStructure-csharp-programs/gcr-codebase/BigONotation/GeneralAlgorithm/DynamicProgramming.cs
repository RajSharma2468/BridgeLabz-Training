using System;

class FibonacciDP
{
    static void Main()
    {
        int n = 10;
        int[] dp = new int[n + 1];

        dp[0] = 0;
        dp[1] = 1;

        for (int i = 2; i <= n; i++)
            dp[i] = dp[i - 1] + dp[i - 2];

        Console.WriteLine(dp[n]);
    }
}
