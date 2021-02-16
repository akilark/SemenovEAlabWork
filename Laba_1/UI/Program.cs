using System;
using Laba_1.Logic;
using System.Text.RegularExpressions;

namespace Laba_1.UI
{
	//TODO: RSDN
	class Program
	{
		public static void Main(string[] args)
		{
			string exit;
			//TODO: RSDN
			Person PersonForAdd = new Person();
			
			Person SelectedPerson;
			int index;
			int ListSize = 3;
			string FirstName="";
			string SecondName="";
			int Age;
			int MinAge = 1;
			int MaxAge = 114;
			GenderType Gender;
			bool FirstNameMistakeFlag;
			bool SecondNameMistakeFlag;
			bool AgeMistakeFlag;

			while (true)
			{
				Age = -1;
				FirstNameMistakeFlag = true;
				SecondNameMistakeFlag = true;
				AgeMistakeFlag = true;
				Console.WriteLine("Cоздание массивов, " +
					"для продолжение нажмите любую кнопку");
				
				PersonList ListOfPerson1 = RandomPersonList.Create(ListSize);
				
				PersonList ListOfPerson2 = RandomPersonList.Create(ListSize);

				Console.ReadKey();

				//b
				Console.WriteLine("Первый массив:");
				ShowInfo(ListOfPerson1.PersonsInfo());
				Console.WriteLine();
				Console.WriteLine("Второй массив:");
				ShowInfo(ListOfPerson2.PersonsInfo());
				Console.WriteLine();
				Console.WriteLine("для продолжение нажмите любую кнопку");
				Console.ReadKey();

				
				//c
				Console.WriteLine("Добавление человека в первый массив:");
				
				//TODO: Дублирование
				while (FirstNameMistakeFlag)
				{
					Console.WriteLine("Введите имя:");
					FirstName = Console.ReadLine();
					FirstNameMistakeFlag=CheckName(FirstName);
				}
				FirstName = CorrectName(FirstName);

				//TODO: Дублирование
				while (SecondNameMistakeFlag)
				{
					Console.WriteLine("Введите фамилию ");
					SecondName = Console.ReadLine();
					SecondNameMistakeFlag=CheckName(SecondName);
				}
				SecondName = CorrectName(SecondName);


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
				ShowInfo(ListOfPerson1.PersonsInfo());
				Console.WriteLine();
				Console.ReadKey();
				
				//d
				Console.WriteLine("Перенос человеа из первого массива во второй:");
				index = 1;
				SelectedPerson = ListOfPerson1.FindByIndex(index);
				ListOfPerson2.AddElement(SelectedPerson);
				Console.WriteLine("Первый массив:");
				ShowInfo(ListOfPerson1.PersonsInfo());
				Console.WriteLine();
				Console.WriteLine("Второй массив:");
				ShowInfo(ListOfPerson2.PersonsInfo());
				Console.WriteLine();
				Console.ReadKey();

				//e
				
				
				ListOfPerson1.DeleteElement(index);
				Console.WriteLine($"Удаление элемента с индексом {index}:");
				Console.WriteLine("Первый массив:");
				ShowInfo(ListOfPerson1.PersonsInfo());
				Console.WriteLine();
				Console.WriteLine("Второй массив:");
				ShowInfo(ListOfPerson2.PersonsInfo());
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
		/// <param name="PersonInfoArray">Массив данных о персоне </param>
		public static void ShowInfo(string[] PersonInfoArray)
		{
			for (int i = 0; i < PersonInfoArray.Length; i++)		
			{
				Console.WriteLine(GenderRussian(PersonInfoArray[i]));
			}
		}

		/// <summary>
		/// Функция приводящая имена и фамилии к правильному виду
		/// </summary>
		/// <param name="name">Либо имя, либо фамилия</param>
		/// <returns>Строка содержащая слово с первой заглавной буквой, 
		/// если слова разделены через тире, оба слова начинаются с большой буквы </returns>
		public static string CorrectName(string name)
		{
			//TODO: RSDN
			string NameTMP="";
			string OutputName="";
			string[] SubString = name.Split('-', StringSplitOptions.RemoveEmptyEntries);
			foreach (string SubTMP in SubString)
			{
				for (int i = 0; i < SubTMP.Length; i++)
				{
					//TODO: скобочки
					if (SubTMP.Length > 1)
						NameTMP = SubTMP.Substring(0, 1).ToUpper() + 
							SubTMP.Substring(1, SubTMP.Length - 1).ToLower();
					else NameTMP = SubTMP.ToUpper();
				}

				if (OutputName.Length == 0)
				{
					OutputName += NameTMP;
				}
				else
				{
					OutputName += "-" + NameTMP;
				}
			}
			return OutputName;
		}

		/// <summary>
		/// Функция проверяющая имена и фамилии на наличие запрещенных симоволов
		/// </summary>
		/// <param name="name">Либо имя, либо фамилия</param>
		/// <returns>false- если запрещенных символов нет. 
		/// true- если запрещенные символ есть </returns>
		public static bool CheckName(string name)
		{
			string pattern = @"[^a-zа-я-]";
			Regex reg = new Regex(pattern, RegexOptions.IgnoreCase);
			Match mat = reg.Match(name);
			if (mat.Success)
			{
				Console.WriteLine("Имя и Фамилия могут содержать только буквы!!!");
			}
			return mat.Success;
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
				(@"\b(Female)\b", "Женский")
				(@"\b(Unknown)\b", "Боевой вертолёт апачи")
			}

			foreach(var pattern in patterns)
			{
				var regex = new Regex(pattern.Item1);
				if (regexMale.IsMatch(info))
				{
					return regexMale.Replace(info, pattern.Item2);
				}
			}

			throw new ArgumentException("");
		}
	}

}

