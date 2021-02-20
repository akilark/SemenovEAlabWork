using System;
using Laba_1.Logic;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Laba_1.UI
{
	//TODO: RSDN
	class Program
	{
		public static void Main()
		{
			string exit;
			//TODO: RSDN
			Person PersonForAdd = new Person();
			
			Person SelectedPerson;
			int index;
			int ListSize = 3;
			string FirstName="";
			string SecondName="";
			int MinAge = 1;
			int MaxAge = 114;
			GenderType Gender;


			while (true)
			{
				Console.WriteLine("Cоздание массивов, " +
					"для продолжение нажмите любую кнопку");
				
				PersonList ListOfPerson1 = RandomPerson.CreatePersonList(ListSize);
				
				PersonList ListOfPerson2 = RandomPerson.CreatePersonList(ListSize);

				Console.ReadKey();

				//b
				Console.WriteLine("Первый массив:");
				ShowInfo(ListOfPerson1);
				Console.WriteLine();
				Console.WriteLine("Второй массив:");
				ShowInfo(ListOfPerson2);
				Console.WriteLine();
				Console.WriteLine("для продолжение нажмите любую кнопку");
				Console.ReadKey();

				
				//c
				Console.WriteLine("Добавление человека в первый массив:");

				//TODO: Дублирование
				bool FirstNameMistakeFlag = true;
				while (FirstNameMistakeFlag)
				{
					Console.WriteLine("Введите имя:");
					FirstName = Console.ReadLine();
					FirstNameMistakeFlag=Person.CheckName(FirstName);
				
				}
				FirstName = Person.CorrectName(FirstName);

				bool SecondNameMistakeFlag = true;
				while (SecondNameMistakeFlag)
				{
					Console.WriteLine("Введите фамилию ");
					SecondName = Console.ReadLine();
					SecondNameMistakeFlag=Person.CheckName(SecondName);
				}
				SecondName = Person.CorrectName(SecondName);
				
				int Age = -1;
				bool AgeMistakeFlag = true;
				while (AgeMistakeFlag)
				{
					try
					{
						Console.WriteLine("Введите возраст ");
						Age = Int32.Parse(Console.ReadLine());
						if (Age < MinAge || Age > MaxAge)
						{
							Console.WriteLine($"Возраст должен быть в диапазоне" +
								$" [{MinAge}-{MaxAge}]");
						}
						else
						{
							AgeMistakeFlag = false;
						}
					}
					catch (System.FormatException)
					{
						Console.WriteLine("Необходимо ввести число");
						
					}

				}


				Console.WriteLine("Введите пол (М/Ж)");
				string gen = Console.ReadLine();
				switch (gen)
				{
					case "М":
					case "м":
						{
							Gender = GenderType.Male;
							break;
						}
					case "Ж":
					case "ж":
						{
							Gender = GenderType.Female;
							break;
						}
					default:
						{
							Gender = GenderType.Unknown;
							break;
						}
				}
				PersonForAdd.AddInfo(FirstName,SecondName,Age,Gender);
				ListOfPerson1.AddElement(PersonForAdd);
				Console.WriteLine();
				Console.WriteLine("Расширенный массив:");
				ShowInfo(ListOfPerson1);
				Console.WriteLine();
				Console.ReadKey();
				
				//d
				Console.WriteLine("Перенос человеа из первого массива во второй:");
				index = 1;
				SelectedPerson = ListOfPerson1.FindByIndex(index);
				ListOfPerson2.AddElement(SelectedPerson);
				Console.WriteLine("Первый массив:");
				ShowInfo(ListOfPerson1);
				Console.WriteLine();
				Console.WriteLine("Второй массив:");
				ShowInfo(ListOfPerson2);
				Console.WriteLine();
				Console.ReadKey();

				//e
				
				
				ListOfPerson1.DeleteElement(index);
				Console.WriteLine($"Удаление элемента с индексом {index}:");
				Console.WriteLine("Первый массив:");
				ShowInfo(ListOfPerson1);
				Console.WriteLine();
				Console.WriteLine("Второй массив:");
				ShowInfo(ListOfPerson2);
				Console.WriteLine();
				Console.ReadKey();



				Console.WriteLine("для выхода из программы нажмите 'q'");
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
		public static void ShowInfo(PersonList personArray)
		{
			foreach (string personInfo in personArray.PersonsInfo())
			{
				Console.WriteLine(GenderRussian(personInfo));
			}

		}



		/// <summary>
		/// Фукнция переводящая на русский язык информацию о гендере из строки с информацией о персоне
		/// </summary>
		/// <param name="info">Строка информации о персоне</param>
		/// <returns> Русский перевод гендера конкретной персоны</returns>
		public static string GenderRussian(string info)
		{
			List<(string, string)> patterns = new List<(string, string)>()
			{
				(@"\b(Male)\b", "Мужской"),
				(@"\b(Female)\b", "Женский"),
				(@"\b(Unknown)\b", "Боевой вертолёт апачи")
			};


			foreach(var pattern in patterns)
			{
				var regex = new Regex(pattern.Item1);
				if (regex.IsMatch(info))
				{
					return regex.Replace(info, pattern.Item2);
				}
			}

			throw new ArgumentException("");
		}
	}

}

