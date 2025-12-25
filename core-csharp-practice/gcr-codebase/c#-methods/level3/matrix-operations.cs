using System;

class MatrixOperations
{
    static int[,] CreateMatrix(int rows, int cols)
    {
        Random rand = new Random();
        int[,] matrix = new int[rows, cols];

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                matrix[i, j] = rand.Next(1, 10);

        return matrix;
    }

    static void Display(int[,] m)
    {
        for (int i = 0; i < m.GetLength(0); i++)
        {
            for (int j = 0; j < m.GetLength(1); j++)
                Console.Write(m[i, j] + " ");
            Console.WriteLine();
        }
    }

    static int[,] Add(int[,] a, int[,] b)
    {
        int[,] result = new int[a.GetLength(0), a.GetLength(1)];

        for (int i = 0; i < a.GetLength(0); i++)
            for (int j = 0; j < a.GetLength(1); j++)
                result[i, j] = a[i, j] + b[i, j];

        return result;
    }

    static void Main()
    {
        int[,] A = CreateMatrix(2, 2);
        int[,] B = CreateMatrix(2, 2);

        Console.WriteLine("Matrix A:");
        Display(A);

        Console.WriteLine("Matrix B:");
        Display(B);

        Console.WriteLine("Addition:");
        Display(Add(A, B));
    }
}
