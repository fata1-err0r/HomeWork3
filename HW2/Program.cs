using System;
using System.Collections.Generic;

namespace HW2
{
	class Program
	{
		static public string[] MenuStrings =
		{
			"1 - Вывод списка форматов",
			"2 - Добавление нового формата",
			"3 - Поиск формата по расширению",
			"4 - Удаление формата из списка",
			"5 - Выход"
		};
		static void Main(string[] args)
		{
			Dictionary<string, string> extension = new Dictionary<string, string>();
			extension.Add(".dll", "Dynamic Link Library");
			extension.Add(".exe", "Executable file");
			extension.Add(".ini", "Initialization file");
			extension.Add(".zip", "Archive file");
			extension.Add(".cs", "C Sharp file");
			ConsoleKey key = ConsoleKey.Enter;
			do
			{
				PrintMenu();
				key = Console.ReadKey().Key;
				switch (key)
				{
					case ConsoleKey.D1:
						PrintDictionary(extension);
						break;
					case ConsoleKey.D2:
						AddForm(extension);
						break;
					case ConsoleKey.D3:
						FindForm(extension);
						break;
					case ConsoleKey.D4:
						DelForm(extension);
						break;
					default: continue;
				}
			} while (key != ConsoleKey.D5);
			Console.WriteLine("Удачи!");
		}
		static public void PrintMenu()
		{
			Console.Clear();
			foreach (var menuString in MenuStrings)
			{
				Console.WriteLine(menuString);
			}
			Console.WriteLine("Нажмите цифру, соответствующую номеру меню. ");
		}
		static public void PrintDictionary(Dictionary<string,string> dictionary)
		{
			Console.Clear();
			if (dictionary.Count == 0)
			{
				Console.WriteLine("Список пуст. ");
			}
			else
			{
				foreach (KeyValuePair<string, string> elem in dictionary)
				{
					Console.WriteLine(elem);
				}
			}
			Console.WriteLine("Для прехода в меню нажмите любую клавишу... ");
			Console.ReadKey();
		}
		static public void AddForm(Dictionary<string, string> dictionary)
		{
			try
			{
				Console.Clear();
				Console.WriteLine("Введите формат файла: ");
				string extension = Console.ReadLine();
				while (extension.Trim() == "")
				{
					Console.WriteLine("Вы ничего не ввели, попробуйте снова: ");
					extension = Console.ReadLine();
				}
			Description:
				Console.WriteLine("Введите описание формата: ");
				string description = Console.ReadLine();
				if (description == "")
				{
					Console.WriteLine("Вы ничего не ввели, попробуйте снова: ");
					goto Description;
				}
				else
				{
					dictionary.Add(extension, description);
					Console.WriteLine("Формат добавлен в список! ");
					Console.WriteLine("Для прехода в меню нажмите любую клавишу... ");
					Console.ReadKey();
				}
			}
			catch
			{
				Console.WriteLine("Такой формат уже существует! ");
				Console.WriteLine("Для прехода в меню нажмите любую клавишу... ");
				Console.ReadKey();
			}
		}
		static public void FindForm(Dictionary<string, string> dictionary)
		{
			Console.Clear();
		FindForm:
			Console.WriteLine("Введите формат для поиска: ");
			string extension = Console.ReadLine();
			if (extension != "")
			{
				if (dictionary.ContainsKey(extension))
				{
					Console.WriteLine(dictionary[extension]);
				}
				else
				{
					Console.WriteLine("Такой формат не найден! ");
				}
			}
			else
			{
				Console.WriteLine("Вы ничего не ввели, попробуйте снова: ");
				goto FindForm;
			}
			Console.WriteLine("Для прехода в меню нажмите любую клавишу...");
			Console.ReadKey();
		}
		static public void DelForm(Dictionary<string, string> dictionary)
		{
			Console.Clear();
		DelForm:
			Console.WriteLine("Введите формат для удаления: ");
			string extension = Console.ReadLine();
			if (extension != "")
			{
				if (dictionary.ContainsKey(extension))
				{
					dictionary.Remove(extension);
					Console.WriteLine("Формат удален ");
				}
				else
				{
					Console.WriteLine("Такого формата не существует! ");
				}
			}
			else
			{
				Console.WriteLine("Вы ничего не ввели, попробуйте снова: ");
				goto DelForm;
			}
			Console.WriteLine("Для прехода в меню нажмите любую клавишу... ");
			Console.ReadKey();
		}
	}
}