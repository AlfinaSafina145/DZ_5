using System;
using System.IO;
using System.Collections.Generic;

namespace Homework6_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = args[0];
            string text = File.ReadAllText(fileName);
            List<char> charList = new List<char>();
            for (int i = 0; i < text.Length; i++)
            {
                charList.Add(text[i]);
            }
            CountLetters(charList);
            Console.ReadKey();
        }
        static void CountLetters(List<char> list)
        {
            int vowels = 0;
            int consonants = 0;
            for (int i = 0; i < list.Count; i++)
            {
                char currentChar = char.ToLower(list[i]);
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
