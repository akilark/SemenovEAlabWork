using System;
using Laba1.Logic;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Laba1.UI
{
	/// <summary>
	/// Класс инициирующий работу программы
	/// </summary>
	public class Program
	{
		/// <summary>
		/// Метод вызываемый при старте программы
		/// </summary>
		public static void Main()
		{
			while (true)
			{
				SetConsoleColor("Cоздание массивов", ConsoleColor.Green);
				SetConsoleColor("для продолжение нажмите любую кнопку", ConsoleColor.Red);
				const int listSize = 3;
				PersonList listOfPerson1 = RandomPerson.CreatePersonList(listSize);
				PersonList listOfPerson2 = RandomPerson.CreatePersonList(listSize);
				Console.ReadKey();


				//b
				ShowInfo("Первый массив:", listOfPerson1);
				ShowInfo("Второй массив:", listOfPerson2);
				SetConsoleColor("для продолжение нажмите любую кнопку" + "\n", ConsoleColor.Red);
				Console.ReadKey();


				//c
				SetConsoleColor("Добавление человека в первый массив:", ConsoleColor.Green);
				bool flagName = true;
				bool flagSecondName = true;
				Person personForAdd = new Person();
				while (true)
				{
					try
					{
						if(flagName)
						{
							personForAdd.Name = InputName("Введите имя:");
							flagName = false;
						}
						if(flagSecondName)
						{
							personForAdd.SecondName = InputName("Введите фамилию:");
							flagSecondName = false;
						}
						personForAdd.Age = InputAge();
						personForAdd.Gender = InputGender();
						break;
					}
					catch (Exception e)
					{
						SetConsoleColor($"{e.Message}", ConsoleColor.Red);
					}
				}
				listOfPerson1.AddElement(personForAdd);
				ShowInfo("Расширенный массив:", listOfPerson1);
				Console.ReadKey();


				//d
				SetConsoleColor("Перенос человеа из первого массива во второй:", ConsoleColor.Green);
				int index = 1;
				Person selectedPerson = listOfPerson1.FindByIndex(index);
				listOfPerson2.AddElement(selectedPerson);
				ShowInfo("Первый массив:", listOfPerson1);
				ShowInfo("Второй массив:", listOfPerson2);
				Console.ReadKey();


				//e
				listOfPerson1.DeleteElement(index);
				SetConsoleColor($"Удаление элемента с индексом {index}:", ConsoleColor.Green);
				ShowInfo("Первый массив:", listOfPerson1);
				ShowInfo("Второй массив:", listOfPerson2);
				Console.ReadKey();

				SetConsoleColor("для выхода из программы нажмите 'q'", ConsoleColor.Green);
				string exit = Console.ReadLine();
				Console.WriteLine();
				if (exit == "q" || exit == "Q" || exit == "й" || exit == "Й")
				{
					break;
				}
			}
		}


		/// <summary>
		/// Функция с помощью которой выводится информация о персоне в консоль
		/// </summary>
		/// <param name="personArray">Массив данных о персоне </param>
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
		public static void SetConsoleColor(string outputInfo, ConsoleColor consoleColor)
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
				catch (System.FormatException)
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