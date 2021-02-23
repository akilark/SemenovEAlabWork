using System;
using Laba1.Logic;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Laba1.UI
{

	public class Program
	{
		public static void Main()
		{
			while (true)
			{
				string exit;
				Person personForAdd = new Person();
				int listSize = 3;
				

				GreenConsole("Cоздание массивов");

				RedConsole("для продолжение нажмите любую кнопку");

				PersonList ListOfPerson1 = RandomPerson.CreatePersonList(listSize);

				PersonList ListOfPerson2 = RandomPerson.CreatePersonList(listSize);

				Console.ReadKey();

				//b
				ShowInfo("Первый массив:", ListOfPerson1);

				ShowInfo("Второй массив:", ListOfPerson2);

				RedConsole("для продолжение нажмите любую кнопку" + "\n");

				Console.ReadKey();


				//c
				GreenConsole("Добавление человека в первый массив:");

				string FirstName = InputName("Введите имя:");

				string SecondName = InputName("Введите фамилию:");

				int Age = InputAge();

				GenderType Gender = InputGender();

				personForAdd.AddInfo(FirstName, SecondName, Age, Gender);

				ListOfPerson1.AddElement(personForAdd);

				ShowInfo("Расширенный массив:", ListOfPerson1);

				Console.ReadKey();


				//d
				GreenConsole("Перенос человеа из первого массива во второй:");

				int index = 1;

				Person SelectedPerson = ListOfPerson1.FindByIndex(index);

				ListOfPerson2.AddElement(SelectedPerson);

				ShowInfo("Первый массив:", ListOfPerson1);

				ShowInfo("Второй массив:", ListOfPerson2);

				Console.ReadKey();


				//e
				ListOfPerson1.DeleteElement(index);

				GreenConsole($"Удаление элемента с индексом {index}:");

				ShowInfo("Первый массив:", ListOfPerson1);

				ShowInfo("Второй массив:", ListOfPerson2);

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
		private static void ShowInfo(string message, PersonList personArray)
		{
			Console.WriteLine("\n" + message);

			foreach (string personInfo in personArray.PersonsInfo())
			{
				Console.WriteLine(GenderRussian(personInfo));
			}

			Console.WriteLine();
		}


		/// <summary>
		/// Фукнция переводящая на русский язык информацию о гендере 
		/// из строки с информацией о персоне
		/// </summary>
		/// <param name="info">Строка информации о персоне</param>
		/// <returns> Русский перевод гендера конкретной персоны</returns>
		private static string GenderRussian(string info)
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
		private static void RedConsole(string outputInfo)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(outputInfo);
			Console.ResetColor();
		}


		/// <summary>
		/// Функция с помощью которой выводится информация в консоль зеленым цветом
		/// </summary>
		/// <param name="outputInfo">Строка которую необходимо вывести </param>
		private static void GreenConsole(string outputInfo)
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
		private static string InputName(string infoForUser)
		{
			bool nameMistakeFlag = true;
			string nameTmp = "";


			while (nameMistakeFlag)
			{
				Console.WriteLine("\n" + infoForUser);

				nameTmp = Console.ReadLine();

				Tuple<bool, string> checkResult = InputPersonInfo.CheckName(nameTmp);

				nameMistakeFlag = checkResult.Item1;

				if (nameMistakeFlag)
				{
					string mistakeInfo = checkResult.Item2;

					string[] subString =
						mistakeInfo.Split(new char[] { '!' }, 
						StringSplitOptions.RemoveEmptyEntries);

					foreach (string subst in subString)
					{
						RedConsole(subst + "!");
					}

				}
			}

			nameTmp = InputPersonInfo.CorrectName(nameTmp);

			return nameTmp;
		}


		/// <summary>
		/// Функция с помощью которой происходит проверка возраста на соответствие
		/// Если введено не правильное число выводит информацию об этом
		/// </summary>
		/// /// <returns>Проверенный возраст</returns>
		private static int InputAge()
		{
			int ageTmp = -1;
			bool AgeMistakeFlag = true;

			while (AgeMistakeFlag)
			{
				try
				{
					Console.WriteLine("\n" + "Введите возраст ");

					ageTmp = Int32.Parse(Console.ReadLine());

					AgeMistakeFlag = InputPersonInfo.CheckAge(ageTmp).Item1;

					if (AgeMistakeFlag)
					{
						RedConsole(InputPersonInfo.CheckAge(ageTmp).Item2);
					}
				}
				catch (System.FormatException)
				{
					RedConsole("Необходимо ввести целое число");
				}
			}
			return ageTmp;
		}


		/// <summary>
		/// Функция в которой есть четкое соответсвие 
		/// введенной информации с клавиатуры и соответсвующему гендеру персоны
		/// </summary>
		/// /// <returns>Проверенный гендер</returns>
		private static GenderType InputGender()
		{
			GenderType gender;
			Console.WriteLine("\n" + "Введите пол (М/Ж)");

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


