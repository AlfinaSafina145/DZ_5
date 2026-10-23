using System;
using System.Collections.Generic;

namespace Homework6_2
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<LinkedList<int>> matrixA = new LinkedList<LinkedList<int>>();
            matrixA.AddLast(new LinkedList<int>(new int[] { 1, 2, 3 }));
            matrixA.AddLast(new LinkedList<int>(new int[] { 4, 5, 6 }));

            LinkedList<LinkedList<int>> matrixB = new LinkedList<LinkedList<int>>();
            matrixB.AddLast(new LinkedList<int>(new int[] { 7, 8 }));
            matrixB.AddLast(new LinkedList<int>(new int[] { 9, 10 }));
            matrixB.AddLast(new LinkedList<int>(new int[] { 11, 12 }));

            Console.WriteLine("Матрица A:");
            PrintMatrix(matrixA);

            Console.WriteLine("Матрица B:");
            PrintMatrix(matrixB);

            LinkedList<LinkedList<int>> result = MultiplyMatrices(matrixA, matrixB);

            Console.WriteLine("Результат умножения:");
            PrintMatrix(result);

            Console.ReadKey();
        }

        static void PrintMatrix(LinkedList<LinkedList<int>> matrix)
        {
            foreach (LinkedList<int> row in matrix)
            {
                foreach (int val in row)
                {
                    Console.Write(val + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static LinkedList<LinkedList<int>> MultiplyMatrices(LinkedList<LinkedList<int>> matA, LinkedList<LinkedList<int>> matB)
        {
            LinkedList<LinkedList<int>> result = new LinkedList<LinkedList<int>>();

            int colsB = matB.First.Value.Count;

            foreach (LinkedList<int> rowA in matA)
            {
                LinkedList<int> newRow = new LinkedList<int>();

                for (int j = 0; j < colsB; j++)
                {
                    int sum = 0;

                    LinkedListNode<int> nodeA = rowA.First;
                    LinkedListNode<LinkedList<int>> rowB = matB.First;

                    while (nodeA != null && rowB != null)
                    {
                        LinkedList<int> currentRowB = rowB.Value;
                        LinkedListNode<int> numberB = currentRowB.First;

                        for (int k = 0; k < j; k++)
                        {
                            numberB = numberB.Next;
                        }

                        sum += nodeA.Value * numberB.Value;

                        nodeA = nodeA.Next;
                        rowB = rowB.Next;
                    }

                    newRow.AddLast(sum);
                }

                result.AddLast(newRow);
            }

            return result;
        }
    }
}
