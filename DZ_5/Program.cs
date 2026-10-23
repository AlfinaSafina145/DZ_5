using System;
using System.Collections.Generic;

namespace Homework6_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int[]> temperature = new Dictionary<string, int[]>();
            Random ran = new Random();
            string[] monthNames = { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь","Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
            for (int i = 0; i < 12; i++)
            {
                int[] daysTemps = new int[30];
                for (int j = 0; j < 30; j++)
                {
                    daysTemps[j] = ran.Next(-35, 35);
                }
                temperature.Add(monthNames[i], daysTemps);
            }

            int[] averageTemps = CalculateAverageTemperatures(temperature, monthNames);

            Console.WriteLine("Средняя температура по месяцам:");
            for (int i = 0; i < averageTemps.Length; i++)
            {
                Console.WriteLine($"{monthNames[i]}: {averageTemps[i]}");
            }

            int yearSum = 0;
            for (int i = 0; i < averageTemps.Length; i++)
            {
                yearSum += averageTemps[i];
            }
            Console.WriteLine($"\nСредняя температура за год: {yearSum / 12}");
            Array.Sort(averageTemps);
            Console.WriteLine("\nОтсортированные средние температуры:");
            for (int i = 0; i < averageTemps.Length; i++)
            {
                Console.Write(averageTemps[i] + " ");
            }
            Console.WriteLine();
        }
        static int[] CalculateAverageTemperatures(Dictionary<string, int[]> temps, string[] names)
        {
            int[] averages = new int[12];
            for (int i = 0; i < 12; i++)
            {
                int[] currentMonth = temps[names[i]];
                int sum = 0;

                for (int j = 0; j < currentMonth.Length; j++)
                {
                    sum += currentMonth[j];
                }

                averages[i] = sum / 30;
            }
            return averages;
        }
    }
}