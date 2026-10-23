using System;
namespace Task6_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] temperature = new int[12, 30];
            Random ran = new Random();
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    temperature[i, j] = ran.Next(-35, 35);
                }
            }
            int[] averageTemps = CalculateAverageTemp(temperature);
            Console.WriteLine("Средняя температура по месяцам:");
            for (int i = 0; i < averageTemps.Length; i++)
            {
                Console.WriteLine($"Месяц{i}: средняя температура: {averageTemps[i]}");
            }
            Console.WriteLine();

            int sumOfMonths = 0;
            for (int i = 0; i < averageTemps.Length; i++)
            {
                sumOfMonths = sumOfMonths + averageTemps[i];
            }
            int averageForYear = sumOfMonths / 12;

            Console.WriteLine($"Средняя температура за год: {averageForYear}");

            SortArray(averageTemps);

            Console.WriteLine("Средние температуры, отсортированные по возрастанию:");
            for (int i = 0; i < averageTemps.Length; i++)
            {
                Console.Write(averageTemps[i] + " ");
            }
            Console.WriteLine();
        }
        static int[] CalculateAverageTemp(int[,] temps)
        {
            int months = temps.GetLength(0);
            int days = temps.GetLength(1);
            int[] averages = new int[months];

            for (int i = 0; i < months; i++)
            {
                int sum = 0;
                for (int j = 0; j < days; j++)
                {
                    sum = sum + temps[i, j];
                }
                averages[i] = sum / days;
            }

            return averages;
        }
        static void SortArray(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }
    }
}
