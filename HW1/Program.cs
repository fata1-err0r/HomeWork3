using System;
using System.Collections.Generic;

namespace HW1
{
	class Program
	{
		static void Main(string[] args)
		{
			do
			{
				try
				{
					Console.Clear();
					Console.WriteLine("Введите время работы почты: ");
					int time = Convert.ToInt32(Console.ReadLine());
					if (time > 0)
					{
					VisitorsN:
						Console.WriteLine("Введите кол-во посетителей: ");
						int visitorsN = Convert.ToInt32(Console.ReadLine());
						if (visitorsN > 0)
						{
							Queue<int> visitorsT = new Queue<int>();
							for (int i = 0; i < visitorsN; i++)
							{
								Console.WriteLine($"Введите время обслуживания {i+1} посетителя: ");
								int a = Convert.ToInt32(Console.ReadLine());
								if (a > 0)
								{
									visitorsT.Enqueue(a);
								}
								else
								{
									Console.WriteLine("Время обслуживания должно быть больше 0! ");
									i--;
								}
							}
							do
							{
								time = time - visitorsT.Dequeue();
								if (visitorsT.Count == 0)
								{
									break;
								}
							}
							while (time >= 0);
							switch (visitorsT.Count)
							{
								case 0:
									Console.WriteLine("Почта успела обслужить всех! ");
									Console.WriteLine("Для продолжения нажмите любую клавишу... ");
									Console.ReadKey();
									break;
								default:
									Console.WriteLine($"Почта не успела обслужить {visitorsT.Count} посетителей ");
									Console.WriteLine("Для продолжения нажмите любую клавишу... ");
									Console.ReadKey();
									break;
							}
						}
						switch (visitorsN)
						{
							case 0:
								Console.WriteLine("Сегодня на почту никто не пришел.. ");
								goto VisitorsN;

							case < 0:
								Console.WriteLine("Сегодня на почте произошло что-то странное.. ");
								goto VisitorsN;
						}
					}
					else if (time == 0)
					{
						Console.WriteLine("Сегодня почта не работает.. ");
						Console.WriteLine("Для продолжения нажмите любую клавишу... ");
						Console.ReadKey();
					}
					else
					{
						Console.WriteLine("Время не может быть отрицательным! ");
						Console.WriteLine("Для продолжения нажмите любую клавишу... ");
						Console.ReadKey();
					}
				}
				catch
				{
					Console.WriteLine("ERROR введено не верное значение! ");
					Console.WriteLine("Для продолжения нажмите любую клавишу... ");
					Console.ReadKey();
				}
			}
			while (true);
		}
	}
}