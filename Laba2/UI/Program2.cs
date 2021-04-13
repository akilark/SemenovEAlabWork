using System;
using System.Collections.Generic;
using Laba2.Logic;
using System.Text.RegularExpressions;

namespace Laba2.UI
{
	//TODO: RSDN(v)
	/// <summary>
	/// Класс инициирующий работу программы
	/// </summary>
	public class Program2
	{
		/// <summary>
		/// Метод вызываемый при старте программы
		/// </summary>
		static void Main(string[] args)
		{
			int peopleNumber = 3;
			PersonList persList = RandomPerson.CreatePersonList(7);
			ShowInfo("Список персон",persList);
			SetConsoleColor($"{peopleNumber + 1}" +
				$" человек в списке это:",ConsoleColor.Red);
			PersonBase[] personArray= persList.Persons;	
			//TODO: Сделать приведение к конкретному типу и вызвать соответтсвующий типу метод.(V)
			switch(personArray[peopleNumber])
			{
				case Adult adult:
					{
						SetConsoleColor("Взрослый", ConsoleColor.Green);
						SetConsoleColor(adult.InteractionWithJob(DayOfWeek.Monday), 
							ConsoleColor.Green);
						break;
					}
				case Child child:
					{
						SetConsoleColor("Ребенок", ConsoleColor.Green);
						SetConsoleColor(child.Graduate(), ConsoleColor.Green);
						break;
					}
			}
 			Console.ReadKey();
		}


		/// <summary>
		/// Функция с помощью которой выводится информация о персоне в консоль
		/// </summary>
		/// <param name="personArray">Массив данных о персоне </param>
		/// <param name="message">Строка, которая должна выводится 
		/// перед выводом массива</param>
		public static void ShowInfo(string message, PersonList personArray)
		{
			Console.WriteLine("\n" + message);
			foreach (string personInfo in personArray.PersonsInfo())
			{
				Console.WriteLine(GenderRussian(personInfo));
				Console.WriteLine();
			}
			Console.WriteLine();
		}


		/// <summary>
		/// Фукнция переводящая на русский язык информацию о гендере 
		/// из строки с информацией о персоне
		/// </summary>
		/// <param name="info">Строка информации о персоне</param>
		/// <returns> Русский перевод гендера конкретной персоны</returns>
		public static string GenderRussian(string info)
		{
			List<(string, string)> patterns = new List<(string, string)>()
			{
				(@"\b(Male)\b", "Мужской"),
				(@"\b(Female)\b", "Женский"),
				(@"\b(Unknown)\b", "Боевой вертолёт Апачи")
			};
			foreach (var pattern in patterns)
			{
				var regex = new Regex(pattern.Item1);
				if (regex.IsMatch(info))
				{
					return regex.Replace(info, pattern.Item2);
				}
			}
			throw new Exception("Гендер задан не правильно");
		}


		/// <summary>
		/// Функция с помощью которой выводится информация в консоль заданным
		/// </summary>
		/// <param name="outputInfo">Строка которую необходимо вывести </param>
		/// <param name="consoleColor"> Цвет надписи в консоли </param>
		public static void SetConsoleColor(string outputInfo, 
			ConsoleColor consoleColor)
		{
			Console.ForegroundColor = consoleColor;
			Console.WriteLine(outputInfo);
			Console.ResetColor();
		}


		/// <summary>
		/// Функция с помощью которой происходит проверка и обработка
		/// введенных имени и фамилии
		/// </summary>
		/// <param name="infoForUser">Строка которую увидет пользователь, 
		/// нужна для того чтобы попросить имя или фамилию персоны </param>
		/// <returns>Обработанное имя или фамилию</returns>
		public static string InputName(string infoForUser)
		{
			Console.WriteLine("\n" + infoForUser);
			return Console.ReadLine();
		}


		/// <summary>
		/// Функция с помощью которой происходит проверка возраста на соответствие
		/// Если введено не правильное число выводит информацию об этом
		/// </summary>
		/// /// <returns>Проверенный возраст</returns>
		public static int InputAge()
		{
			while (true)
			{
				try
				{
					Console.WriteLine("\n" + "Введите возраст ");
					return Int32.Parse(Console.ReadLine());
				}
				catch (FormatException)
				{
					SetConsoleColor("Необходимо ввести целое число", ConsoleColor.Red);
				}
			}
		}


		/// <summary>
		/// Функция в которой есть четкое соответсвие 
		/// введенной информации с клавиатуры и соответсвующему гендеру персоны
		/// </summary>
		/// /// <returns>Проверенный гендер</returns>
		public static GenderType InputGender()
		{
			Console.WriteLine("\n" + "Введите пол (М/Ж)");
			GenderType gender;
			string gen = Console.ReadLine();
			switch (gen)
			{
				case "М":
				case "м":
					{
						gender = GenderType.Male;
						break;
					}
				case "Ж":
				case "ж":
					{
						gender = GenderType.Female;
						break;
					}
				default:
					{
						gender = GenderType.Unknown;
						break;
					}
			}
			return gender;
		}
	}
}
