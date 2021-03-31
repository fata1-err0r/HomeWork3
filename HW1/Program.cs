using System;
using System.Collections.Generic;

namespace HW1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите время работы почты: ");
            int postT = CheckInt();
            Console.Write("Введите количество посетителей: ");
            int visitorsN = CheckInt();
            Queue<int> time = new Queue<int>();
            Console.WriteLine("Введите время обслуживания посетителя: ");
            for (int i = 1; i <= visitorsN; i++)
            {
                Console.Write($"На {i} посетителя будет затрачено: ");
                time.Enqueue(CheckInt());
            }
            int visitorsS = 0;
            while ((postT > 0) && (time.Count != 0))
            {
                postT -= time.Dequeue();
                visitorsS++;
            }
            Console.Write($"Почта не успела обслужить {visitorsN - visitorsS} посетителей ");
            Console.ReadKey();
        }
        static int CheckInt() // Метод для проверки целочисленного положительного числа
        {

            int n;
            while (true)
            {
                string input = Console.ReadLine();
                bool check = int.TryParse(input, out n);
                if (check)
                {
                    if (n <= 0)
                    {
                        Console.WriteLine("ERROR введено не верное значение! ");
                        Console.Write("Введите значение: ");
                    }
                    else
                        break;
                }
                else
                {
                    Console.WriteLine("ERROR введено не верное значение! ");
                    Console.Write("Введите значение: ");
                }
            }
            return n;
        }
    }
}