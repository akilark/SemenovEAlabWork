using System;
using Laba1.Logic;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Laba1.UI
{

	//TODO: XML(v)
	/// <summary>
	/// Класс инициирующий работу программы
	/// </summary>
	public class Program
	{
		public static void Main()
		{
			while (true)
			{
				string exit;
				int listSize = 3;
				GreenConsole("Cоздание массивов");
				RedConsole("для продолжение нажмите любую кнопку");
				//TODO: RSDN (v)
				PersonList listOfPerson1 = RandomPerson.CreatePersonList(listSize);
				PersonList listOfPerson2 = RandomPerson.CreatePersonList(listSize);
				Console.ReadKey();


				//b
				ShowInfo("Первый массив:", listOfPerson1);
				ShowInfo("Второй массив:", listOfPerson2);
				RedConsole("для продолжение нажмите любую кнопку" + "\n");
				Console.ReadKey();


				//c
				GreenConsole("Добавление человека в первый массив:");
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
						RedConsole($"{e.Message}");
					}
				}
				listOfPerson1.AddElement(personForAdd);
				ShowInfo("Расширенный массив:", listOfPerson1);
				Console.ReadKey();


				//d
				GreenConsole("Перенос человеа из первого массива во второй:");
				int index = 1;
				Person selectedPerson = listOfPerson1.FindByIndex(index);
				listOfPerson2.AddElement(selectedPerson);
				ShowInfo("Первый массив:", listOfPerson1);
				ShowInfo("Второй массив:", listOfPerson2);
				Console.ReadKey();


				//e
				listOfPerson1.DeleteElement(index);
				GreenConsole($"Удаление элемента с индексом {index}:");
				ShowInfo("Первый массив:", listOfPerson1);
				ShowInfo("Второй массив:", listOfPerson2);
				Console.ReadKey();

				GreenConsole("для выхода из программы нажмите 'q'");
				exit = Console.ReadLine();
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
			string infoRussian = "";

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
					infoRussian = regex.Replace(info, pattern.Item2);
				}
			}

			return infoRussian;
		}


		/// <summary>
		/// Функция с помощью которой выводится информация в консоль красным цветом
		/// </summary>
		/// <param name="outputInfo">Строка которую необходимо вывести </param>
		public static void RedConsole(string outputInfo)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(outputInfo);
			Console.ResetColor();
		}


		/// <summary>
		/// Функция с помощью которой выводится информация в консоль зеленым цветом
		/// </summary>
		/// <param name="outputInfo">Строка которую необходимо вывести </param>
		public static void GreenConsole(string outputInfo)
		{
			Console.ForegroundColor = ConsoleColor.Green;
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
			//TODO: (v)
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
					//TODO: (v)
					return Int32.Parse(Console.ReadLine());
				}
				catch (System.FormatException)
				{
					RedConsole("Необходимо ввести целое число");
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


