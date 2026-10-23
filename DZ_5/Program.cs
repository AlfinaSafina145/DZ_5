using System;
using System.Collections.Generic;

namespace MyApp
{
    internal class Program
    {
        static void Shuffle(List<string> list)
        {
            Random rnd = new Random();
            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = rnd.Next(i + 1);
                string temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
        }
        static void AddNewStudent(string[,] students, int count)
        {
            Console.Write("Фамилия: ");
            students[count, 0] = Console.ReadLine();
            Console.Write("Имя: ");
            students[count, 1] = Console.ReadLine();
            Console.Write("Год рождения: ");
            students[count, 2] = Console.ReadLine();
            Console.Write("Название экзамена: ");
            students[count, 3] = Console.ReadLine();
            Console.Write("Количество баллов: ");
            students[count, 4] = Console.ReadLine();
            Console.WriteLine("-> Данные успешно сохранены.");
        }

        static void RemoveStudent(string[,] students, ref int count)
        {
            Console.Write("Введите фамилию для удаления: ");
            string surname = Console.ReadLine();
            Console.Write("Введите имя для удаления: ");
            string name = Console.ReadLine();

            for (int i = 0; i < count; i++)
            {
                if (students[i, 0].ToLower() == surname.ToLower() &&
                    students[i, 1].ToLower() == name.ToLower())
                {
                    for (int j = i; j < count - 1; j++)
                    {
                        for (int k = 0; k < 5; k++)
                        {
                            students[j, k] = students[j + 1, k];
                        }
                    }
                    count--;
                    Console.WriteLine("-> Студент удален из базы.");
                    return;
                }
            }
            Console.WriteLine("-> Студент с такими данными не найден.");
        }

        static void SortStudents(string[,] students, int count)
        {
            for (int i = 0; i < count - 1; i++)
            {
                for (int j = i + 1; j < count; j++)
                {
                    int score1, score2;
                    if (int.TryParse(students[i, 4], out score1) && int.TryParse(students[j, 4], out score2))
                    {
                        if (score1 > score2)
                        {
                            for (int k = 0; k < 5; k++)
                            {
                                string tmp = students[i, k];
                                students[i, k] = students[j, k];
                                students[j, k] = tmp;
                            }
                        }
                    }
                }
            }
            Console.WriteLine("-> Сортировка завершена (по возрастанию баллов).");
        }

        static void DisplayStudents(string[,] students, int count)
        {
            Console.WriteLine("--- Текущий список студентов ---");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"[{i + 1}] {students[i, 0]} {students[i, 1]} | {students[i, 2]} г.р. | Экзамен: {students[i, 3]} | Баллы: {students[i, 4]}");
            }
            if (count == 0) Console.WriteLine("Список пуст.");
        }

        static bool FindPath(Dictionary<int, List<int>> graph, int current, int target, HashSet<int> visited, List<int> path)
        {
            visited.Add(current);
            path.Add(current);

            if (current == target) return true;

            foreach (var neighbor in graph[current])
            {
                if (!visited.Contains(neighbor))
                {
                    if (FindPath(graph, neighbor, target, visited, path)) return true;
                }
            }
            path.RemoveAt(path.Count - 1);
            return false;
        }

        static void Main(string[] args)
        {
            // ЗАДАЧА 1
            Console.WriteLine("Задание 1: Картинки");
            string[] picturePaths = new string[]
            {
                "C:\\Users\\User\\Desktop\\си шарпик\\1.avif\"",
                "C:\\Users\\User\\Desktop\\си шарпик\\2.jpg\"",
                "\"C:\\Users\\User\\Desktop\\си шарпик\\3.jpg\"",
                "\"C:\\Users\\User\\Desktop\\си шарпик\\4.jpg\"",
                "\"C:\\Users\\User\\Desktop\\си шарпик\\5.jpg\"",
                "\"C:\\Users\\User\\Desktop\\си шарпик\\6.jpg\"",
                "\"C:\\Users\\User\\Desktop\\си шарпик\\7.jpg\"",
                "\"C:\\Users\\User\\Desktop\\си шарпик\\8.jpg\"",
                "\"C:\\Users\\User\\Desktop\\си шарпик\\9.jpg\"",
                "\"C:\\Users\\User\\Desktop\\си шарпик\\10.jpg\"",
                "\"C:\\Users\\User\\Desktop\\си шарпик\\11.jpg\"",
                "\"C:\\Users\\User\\Desktop\\си шарпик\\12.jpg\"",
                "\"C:\\Users\\User\\Desktop\\си шарпик\\13.jpg\"",
                "\"C:\\Users\\User\\Desktop\\си шарпик\\14.jpg\"",
                "\"C:\\Users\\User\\Desktop\\си шарпик\\15.jpg\"",
                "\"C:\\Users\\User\\Desktop\\си шарпик\\16.jpg\"",
                "\"C:\\Users\\User\\Desktop\\си шарпик\\17.jpg\"",
                "\"C:\\Users\\User\\Desktop\\си шарпик\\18.jpg\"",
                "\"C:\\Users\\User\\Desktop\\си шарпик\\19jpg\"",
                "\"C:\\Users\\User\\Desktop\\си шарпик\\20.jpg\"",
                "\"C:\\Users\\User\\Desktop\\си шарпик\\21.jpg\"",
                "\"C:\\Users\\User\\Desktop\\си шарпик\\22.jpg\"",
                "\"C:\\Users\\User\\Desktop\\си шарпик\\23.jpg\"",
                "\"C:\\Users\\User\\Desktop\\си шарпик\\24.jpg\"",
                "\"C:\\Users\\User\\Desktop\\си шарпик\\25.jpg\"",
                "\"C:\\Users\\User\\Desktop\\си шарпик\\26.jpg\"",
                "\"C:\\Users\\User\\Desktop\\си шарпик\\27.jpg\"",
                "\"C:\\Users\\User\\Desktop\\си шарпик\\28.jpg\"",
                "\"C:\\Users\\User\\Desktop\\си шарпик\\29.jpg\"",
                "\"C:\\Users\\User\\Desktop\\си шарпик\\30.jpg\"",
                "\"C:\\Users\\User\\Desktop\\си шарпик\\31.jpg\"",
                "\"C:\\Users\\User\\Desktop\\си шарпик\\32.jpg\"",
            };

            List<string> cardDeck = new List<string>();
            foreach (string path in picturePaths)
            {
                cardDeck.Add(path);
                cardDeck.Add(path);
            }

            Shuffle(cardDeck);

            Console.WriteLine("Перемешанная колода:");
            for (int i = 0; i < cardDeck.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {cardDeck[i]}");
            }

            // ЗАДАЧА 4
            Console.WriteLine("\nЗадание 4: Поиск пути в графе");
            Dictionary<int, List<int>> adjList = new Dictionary<int, List<int>>()
            {
                { 0, new List<int> { 1, 2 } },
                { 1, new List<int> { 0, 3, 4 } },
                { 2, new List<int> { 0, 5 } },
                { 3, new List<int> { 1 } },
                { 4, new List<int> { 1, 5 } },
                { 5, new List<int> { 2, 4 } }
            };

            int startNode = 0;
            int endNode = 5;
            List<int> route = new List<int>();
            HashSet<int> usedNodes = new HashSet<int>();

            if (FindPath(adjList, startNode, endNode, usedNodes, route))
            {
                Console.WriteLine("Найденный маршрут: " + string.Join(" -> ", route));
            }
            else
            {
                Console.WriteLine("Маршрут не существует.");
            }

            // ЗАДАЧА 3
            Console.WriteLine("\nЗадание 3: Распределение пожилых людей");

            List<string> clinicNames = new List<string> { "Госпиталь Св. Марии", "Клиника Здоровья", "Городской Травмпункт" };
            List<int> bedsAvailable = new List<int> { 3, 1, 2 };

            List<List<string>> clinicSpecialization = new List<List<string>>();
            clinicSpecialization.Add(new List<string> { "Ангина", "Остеохондроз", "Гастрит" });
            clinicSpecialization.Add(new List<string> { "Мигрень", "Бессонница" });
            clinicSpecialization.Add(new List<string> { "Вывих", "Ушиб" });

            List<Queue<string>> clinicQueues = new List<Queue<string>>();
            for (int i = 0; i < 3; i++) clinicQueues.Add(new Queue<string>());

            Dictionary<string, List<string>> diagnoses = new Dictionary<string, List<string>>();
            diagnoses.Add("Серафима Федоровна", new List<string> { "Гастрит" });
            diagnoses.Add("Тамара Николаевна", new List<string> { "Мигрень", "Бессонница" });
            diagnoses.Add("Евгения Павловна", new List<string> { "Ангина", "Вывих" });
            diagnoses.Add("Ольга Дмитриевна", new List<string> { "Аллергия" });

            Queue<string> streetWaiting = new Queue<string>();
            streetWaiting.Enqueue("Серафима Федоровна");
            streetWaiting.Enqueue("Тамара Николаевна");
            streetWaiting.Enqueue("Евгения Павловна");
            streetWaiting.Enqueue("Ольга Дмитриевна");

            Console.WriteLine("Начало распределения пациентов...");
            while (streetWaiting.Count > 0)
            {
                string currentPerson = streetWaiting.Dequeue();
                List<string> currentDiagnoses = diagnoses[currentPerson];
                bool placed = false;

                for (int i = 0; i < clinicNames.Count; i++)
                {
                    if (clinicQueues[i].Count < bedsAvailable[i])
                    {
                        int matchedIllnesses = 0;
                        foreach (string illness in currentDiagnoses)
                        {
                            if (clinicSpecialization[i].Contains(illness)) matchedIllnesses++;
                        }

                        double matchPercentage = (double)matchedIllnesses / currentDiagnoses.Count * 100;

                        if (matchPercentage >= 50)
                        {
                            clinicQueues[i].Enqueue(currentPerson);
                            Console.WriteLine($"-> {currentPerson} направлена в {clinicNames[i]}.");
                            placed = true;
                            break;
                        }
                    }
                }

                if (!placed)
                {
                    Console.WriteLine($"-> {currentPerson} не подошла ни одна клиника. Ожидает на улице.");
                }
            }

            Console.WriteLine("\n--- Отчет по клиникам ---");
            for (int i = 0; i < clinicNames.Count; i++)
            {
                Console.WriteLine($"\n{clinicNames[i]}. Занято мест: {clinicQueues[i].Count} из {bedsAvailable[i]}");
                foreach (string patient in clinicQueues[i])
                {
                    Console.Write($"   Пациент: {patient}. Диагнозы: ");
                    foreach (string illness in diagnoses[patient])
                    {
                        Console.Write(illness + " ");
                    }
                    Console.WriteLine();
                }
            }

            // ЗАДАЧА 2
            Console.WriteLine("\nЗадание 2: Студенты");
            string[,] studentData = new string[100, 5];
            int totalStudents = 0;
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n[ Меню ]");
                Console.WriteLine("1 - Добавить");
                Console.WriteLine("2 - Удалить");
                Console.WriteLine("3 - Отсортировать");
                Console.WriteLine("4 - Показать всех");
                Console.WriteLine("5 - Завершить");
                Console.Write("Ваш выбор: ");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        if (totalStudents < 100)
                        {
                            AddNewStudent(studentData, totalStudents);
                            totalStudents++;
                        }
                        else Console.WriteLine("-> База данных переполнена.");
                        break;
                    case "2":
                        RemoveStudent(studentData, ref totalStudents);
                        break;
                    case "3":
                        SortStudents(studentData, totalStudents);
                        break;
                    case "4":
                        DisplayStudents(studentData, totalStudents);
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("-> Неверный пункт меню.");
                        break;
                }
            }
        }
    }
}