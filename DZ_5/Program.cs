using System;

namespace Task6_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrixA = new int[2, 3]
            {
                { 1, 2, 3 },
                { 4, 5, 6 }
            };
            int[,] matrixB = new int[3, 2] 
            {
                { 7, 8 },
                { 9, 10 },
                { 11, 12 }
            };
            Console.WriteLine("Первая матрица:");
            PrintMatrix(matrixA);

            Console.WriteLine("Вторая матрица:");
            PrintMatrix(matrixB);

            int[,] resultMatrix = MultiplyMatrices(matrixA, matrixB);
            Console.WriteLine("Результат умножения:");
            PrintMatrix(resultMatrix);
        }
        static void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static int[,] MultiplyMatrices(int[,] matA, int[,] matB)
        {
            int rowsA = matA.GetLength(0);
            int colsA = matA.GetLength(1);
            int colsB = matB.GetLength(1);
            int[,] result = new int[rowsA, colsB];
            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    for (int k = 0; k < colsA; k++)
                    {
                        result[i, j] = result[i, j] + (matA[i, k] * matB[k, j]);
                    }
                }
            }
            return result;
        }
    }
}