using System;

class SlidingWindow
{
    static void MaxWindow(int[] arr, int k)
    {
        int n = arr.Length;
        int[] dq = new int[n];
        int front = 0, rear = -1;

        for (int i = 0; i < n; i++)
        {
            if (front <= rear && dq[front] <= i - k)
                front++;

            while (front <= rear && arr[dq[rear]] < arr[i])
                rear--;

            dq[++rear] = i;

            if (i >= k - 1)
                Console.Write(arr[dq[front]] + " ");
        }
    }

    static void Main()
    {
        int[] arr = { 1, 3, -1, -3, 5, 3, 6, 7 };
        MaxWindow(arr, 3);
    }
}
