using System;
using System.Collections.Generic;

namespace MyApp
{
    internal class Program
    {
        static void Shuffle(List<string> list) //#1
        {
            Random range = new Random();
            int n = list.Count;
            while (n > 1)
            {
                int k = range.Next(n--);
                var value = list[n];
                list[n] = list[k];
                list[k] = value;
            }
        }

        static void AddNewStudent(string[,] students, int studentCount) //СОЗДАНИЕ СТУДЕНТА
        {
            Console.Write("Введите фамилию: ");
            students[studentCount, 0] = Console.ReadLine();

            Console.Write("Введите имя: ");
            students[studentCount, 1] = Console.ReadLine();

            Console.Write("Введите год рождения: ");
            students[studentCount, 2] = Console.ReadLine();

            Console.Write("Введите экзамен: ");
            students[studentCount, 3] = Console.ReadLine();

            Console.Write("Введите баллы: ");
            students[studentCount, 4] = Console.ReadLine();

            Console.WriteLine("Студент добавлен.");
        }

        static void RemoveStudent(string[,] students, ref int studentCount) //УДАЛЕНИЕ СТУДЕНТА
        {
            Console.Write("Введите фамилию: ");
            string lastName = Console.ReadLine();
            Console.Write("Введите имя: ");
            string firstName = Console.ReadLine();

            for (int i = 0; i < studentCount; i++)
            {
                if (students[i, 0].Equals(lastName, StringComparison.OrdinalIgnoreCase) && //сравнения строк с учетом регистра
                    students[i, 1].Equals(firstName, StringComparison.OrdinalIgnoreCase))
                {
                    for (int j = i; j < studentCount - 1; j++)// Сдвигаем оставшихся студентов влево
                    {
                        for (int k = 0; k < 5; k++)
                        {
                            students[j, k] = students[j + 1, k];
                        }
                    }
                    studentCount--;
                    Console.WriteLine("Студент удален.");
                    return;
                }
            }
            Console.WriteLine("Студент не найден.");
        }

        static void SortStudents(string[,] students, int studentCount) //СОРТИРОВКА СТУДЕНТОВ
        {
            for (int i = 0; i < studentCount - 1; i++)
            {
                for (int j = i + 1; j < studentCount; j++)
                {
                    int scoreI, scoreJ; // Переменные для хранения оценок
                    bool isScoreIValid = int.TryParse(students[i, 4], out scoreI);
                    bool isScoreJValid = int.TryParse(students[j, 4], out scoreJ);
                    if (isScoreIValid && isScoreJValid && scoreI > scoreJ) // Если преобразование успешно и оценка первого студента больше второй
                    {

                        for (int k = 0; k < 5; k++)
                        {
                            string temp = students[i, k];
                            students[i, k] = students[j, k];
                            students[j, k] = temp;
                        }
                    }
                }
            }
            Console.WriteLine("Студенты отсортированы по баллам:");
        }

        static void DisplayStudents(string[,] students, int studentCount) //СПИСОК СТУДЕНТОВ
        {
            Console.WriteLine("Список студентов:");
            for (int i = 0; i < studentCount; i++)
            {
                Console.WriteLine($"{students[i, 0]} {students[i, 1]}, Год рождения: {students[i, 2]}, Экзамен: {students[i, 3]}, Оценка: {students[i, 4]}");
            }
        }

        static bool Graph(Dictionary<int, List<int>> graph, int current, int finish, HashSet<int> visited, List<int> path)
        {
            visited.Add(current);
            path.Add(current);

            if (current == finish)
            {
                return true;
            }

            foreach (var neighbor in graph[current]) //перебирает всех соседей текущей вершины current в графе graph
            {
                if (!visited.Contains(neighbor)) // посещен ли пункт
                {
                    if (Graph(graph, neighbor, finish, visited, path))
                    {
                        return true;
                    }
                }
            }
            path.RemoveAt(path.Count - 1); // Удаляем последний элемент если путь не найден
            return false;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("#1");
            string[] img = new string[]
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
            List<string> imageList = new List<string>();// для пар 
            foreach (var url in img)
            {
                imageList.Add(url);
                imageList.Add(url);
            }
            Shuffle(imageList);// перемешиваем список
            Console.WriteLine("Перемешанный список:");
            for (int i = 0; i < imageList.Count; i++)
            {
                Console.WriteLine($"{i}: {imageList[i]}");
            }

            Console.WriteLine("#4");
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>()
            {
                { 0, new List<int> { 1, 2 } },
                { 1, new List<int> { 0, 3, 4 } },
                { 2, new List<int> { 0, 5 } },
                { 3, new List<int> { 1 } },
                { 4, new List<int> { 1, 5 } },
                { 5, new List<int> { 2, 4 } }
            };

            int start = 0;
            int finish = 5;
            List<int> path = new List<int>();
            HashSet<int> visited = new HashSet<int>();


            if (Graph(graph, start, finish, visited, path))
            {
                Console.WriteLine("Путь найден: " + string.Join(" -> ", path));
            }
            else
            {
                Console.WriteLine("Путь не найден.");
            }

            // --- 1. БОЛЬНИЦЫ ---
            // Названия больниц
            List<string> hospitalNames = new List<string> { "ГКБ №1 (Терапия)", "ГКБ №2 (Кардиология)", "ГКБ №3 (Хирургия)" };

            // Вместимость больниц (сколько мест)
            List<int> hospitalCapacity = new List<int> { 2, 1, 3 };

            // Какие болезни лечат (Списки внутри списка)
            List<List<string>> hospitalCures = new List<List<string>>();
            hospitalCures.Add(new List<string> { "Грипп", "Простуда", "Ангина" });
            hospitalCures.Add(new List<string> { "Давление", "Аритмия" });
            hospitalCures.Add(new List<string> { "Перелом", "Аппендицит" });

            // Очереди пациентов в каждой больнице
            List<Queue<string>> hospitalQueues = new List<Queue<string>>();
            for (int i = 0; i < 3; i++) hospitalQueues.Add(new Queue<string>());


            // --- 2. БАБУШКИ ---
            Dictionary<string, List<string>> grandmasIllnesses = new Dictionary<string, List<string>>();
            grandmasIllnesses.Add("Клавдия Ивановна", new List<string> { "Грипп" });
            grandmasIllnesses.Add("Зинаида Петровна", new List<string> { "Давление", "Аритмия" });
            grandmasIllnesses.Add("Мария Сергеевна", new List<string> { "Грипп", "Перелом" });
            grandmasIllnesses.Add("Анна Ахматова", new List<string> { "Кариес" });

            // Общая очередь бабушек на улице
            Queue<string> streetQueue = new Queue<string>();
            streetQueue.Enqueue("Клавдия Ивановна");
            streetQueue.Enqueue("Зинаида Петровна");
            streetQueue.Enqueue("Мария Сергеевна");
            streetQueue.Enqueue("Анна Ахматова");

            // --- 3. РАСПРЕДЕЛЕНИЕ ---
            Console.WriteLine("=== НАЧАЛО РАСПРЕДЕЛЕНИЯ ===");

            while (streetQueue.Count > 0)
            {
                string currentGrandmaName = streetQueue.Dequeue(); // Берем бабушку
                List<string> currentGrandmaIllnesses = grandmasIllnesses[currentGrandmaName]; // Достаем ее болезни по имени

                bool isPlaced = false;

                // Идем по больницам
                for (int i = 0; i < hospitalNames.Count; i++)
                {
                    // 1. Проверяем, есть ли места
                    if (hospitalQueues[i].Count < hospitalCapacity[i])
                    {
                        // 2. Считаем, сколько болезней она может вылечить
                        int curableCount = 0;
                        for (int j = 0; j < currentGrandmaIllnesses.Count; j++)
                        {
                            if (hospitalCures[i].Contains(currentGrandmaIllnesses[j]))
                            {
                                curableCount++;
                            }
                        }
                        // Считаем процент
                        double percent = (double)curableCount / currentGrandmaIllnesses.Count * 100;

                        // 3. Если лечат 50% и более, кладем в очередь
                        if (percent >= 50)
                        {
                            hospitalQueues[i].Enqueue(currentGrandmaName);
                            Console.WriteLine($"Бабушка {currentGrandmaName} направлена в {hospitalNames[i]}.");
                            isPlaced = true;
                            break; // Выходим из цикла больниц, бабушка пристроена
                        }
                    }
                }

                if (!isPlaced)
                {
                    Console.WriteLine($"Бабушке {currentGrandmaName} не подошла ни одна больница. Осталась на улице.");
                }
            }

            Console.WriteLine("\n=== СТАТИСТИКА ПО БОЛЬНИЦАМ ===");
            for (int i = 0; i < hospitalNames.Count; i++)
            {
                Console.WriteLine($"\n{hospitalNames[i]}:");
                Console.WriteLine($"Заполненность: {hospitalQueues[i].Count} из {hospitalCapacity[i]} мест.");

                if (hospitalQueues[i].Count > 0)
                {
                    foreach (string patient in hospitalQueues[i])
                    {
                        Console.Write($"- {patient}. Болезни: ");

                        List<string> ills = grandmasIllnesses[patient];
                        foreach (string ill in ills)
                        {
                            Console.Write(ill + " ");
                        }
                        Console.WriteLine();
                    }
                }
            }

            // --- ЗАДАЧА 2 (СТУДЕНТЫ)---
            Console.WriteLine("#2");
            string[,] students = new string[100, 5]; // Массив для хранения информации о студентах
            int studentCount = 0;

            bool isContinue = true;
            while (isContinue)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Новый студент");
                Console.WriteLine("2. Удалить");
                Console.WriteLine("3. Сортировать");
                Console.WriteLine("4. Вывести всех студентов");
                Console.WriteLine("5. Выход");
                Console.Write("Выберите действие: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        {
                            if (studentCount < 100) // Проверка на переполнение массива
                            {
                                AddNewStudent(students, studentCount);
                                studentCount++;
                            }
                            else
                            {
                                Console.WriteLine("Достигнуто максимальное количество студентов.");
                            }
                            break;
                        }
                    case "2":
                        {
                            RemoveStudent(students, ref studentCount);
                            break;
                        }
                    case "3":
                        {
                            SortStudents(students, studentCount);
                            break;
                        }
                    case "4":
                        {
                            DisplayStudents(students, studentCount);
                            break;
                        }
                    case "5":
                        {
                            return;
                        }
                    default:
                        {
                            Console.WriteLine("Число выходит за рамки");
                            break;
                        }

                }
            }
        }
    }
}