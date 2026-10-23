using System;
using System.IO;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = args[0];
            string text = File.ReadAllText(fileName);
            char[] charArray = text.ToCharArray();
            CountLetters(charArray);
        }
        static void CountLetters(char[] array)
        {
            int vowels = 0;
            int consonants = 0;
            for (int i = 0; i < array.Length; i++)
            {
                char currentChar = char.ToLower(array[i]);
                if (char.IsLetter(currentChar))
                {
                    if ("аеёиоуыэюяaeiouy".Contains(currentChar))
                    {
                        vowels++;
                    }
                    else
                    {
                        consonants++;
                    }
                }
            }
            Console.WriteLine($"Гласных букв: {vowels}");
            Console.WriteLine($"Согласных букв: {consonants}");
        }
    }
}
