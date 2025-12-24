using System;

class MatrixCopy
{
    static void Main()
    {
        Console.WriteLine("Enter rows");
        int rows = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter columns");
        int cols = Convert.ToInt32(Console.ReadLine());

        int[,] matrix = new int[rows, cols];
        int[] array = new int[rows * cols];
        int index = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.WriteLine("Enter element");
                matrix[i, j] = Convert.ToInt32(Console.ReadLine());
                array[index] = matrix[i, j];
                index++;
            }
        }

        Console.WriteLine("1D Array:");
        for (int i = 0; i < array.Length; i++)
            Console.WriteLine(array[i]);
    }
}
