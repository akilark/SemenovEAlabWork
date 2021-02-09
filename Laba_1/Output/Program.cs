using System;
using Laba_1.Logic;
using System.Text.RegularExpressions;

namespace Laba_1.Output
{
	class Program
	{
		public static void Main(string[] args)
		{
			string exit;
			Person PersonForAdd = new Person();
			PersonList ListOfPerson1; 
            PersonList ListOfPerson2; 
			Person SelectedPerson;
			RandomPersonList ListRND = new RandomPersonList();
			int index;
			int ListSize = 3;
			string FirstName="";
			string SecondName="";
			int Age=-1;
			int MinAge = 1;
			int MaxAge = 114;
			GenderType Gender;
			bool FirstNameMistakeFlag = true;
			bool SecondNameMistakeFlag = true;
			bool AgeMistakeFlag = true;
			while (true)
			{
				Console.WriteLine("Cоздание массивов, " +
					"для продолжение нажмите любую кнопку");
				
				ListOfPerson1 = RandomPersonList.Create(ListSize);
				
				ListOfPerson2 = RandomPersonList.Create(ListSize);

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
				
				while (FirstNameMistakeFlag==true)
				{
					Console.WriteLine("Введите имя:");
					FirstName = Console.ReadLine();
					FirstNameMistakeFlag=CheckName(FirstName);
				}
				FirstName = CorrectName(FirstName);
				

				while (SecondNameMistakeFlag == true)
				{
					Console.WriteLine("Введите фамилию ");
					SecondName = Console.ReadLine();
					SecondNameMistakeFlag=CheckName(SecondName);
				}
				SecondName = CorrectName(SecondName);
				

				while (AgeMistakeFlag == true)
				{
					try
					{
						Console.WriteLine("Введите возраст ");
						Age = Int32.Parse(Console.ReadLine());
					}
					catch (System.FormatException)
					{
						Console.WriteLine("Необходимо ввести число");
						
					}
					finally
					{
						if (Age < MinAge || Age > MaxAge )
						{
							Console.WriteLine($"Возраст должен быть в диапазоне" +
								$" [{MinAge}-{MaxAge}]");	
						}
						else
						{
							AgeMistakeFlag = false;
						}
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
			Console.WriteLine(GenderRussian(PersonInfoArray[i]));
		}

		/// <summary>
		/// Функция приводящая имена и фамилии к правильному виду
		/// </summary>
		/// <param name="name">Либо имя, либо фамилия</param>
		/// <returns>Строка содержащая слово с первой заглавной буквой, 
		/// если слова разделены через тире, оба слова начинаются с большой буквы </returns>
		public static string CorrectName(string name)
		{
			string NameTMP="";
			string OutputName="";
			string[] SubString = name.Split('-', StringSplitOptions.RemoveEmptyEntries);
			foreach (string SubTMP in SubString)
			{
				for (int i = 0; i < SubTMP.Length; i++)
				{
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
			string result="";
			string patternGenderMale = @"\b(Male)\b";
			string targetGenderMale = "Мужской";
			Regex regexMale = new Regex(patternGenderMale);
			if (regexMale.IsMatch(info))
			{
				result = regexMale.Replace(info, targetGenderMale);
			}
			string patternGenderFemale = @"\b(Female)\b";
			string targetGenderFemale = "Женский";
			Regex regexFemale = new Regex(patternGenderFemale);
			if (regexFemale.IsMatch(info))
			{
				result = regexFemale.Replace(info, targetGenderFemale);
			}
			string patternGenderUnknown = @"\b(Unknown)\b";
			string targetGenderUnknown = "Боевой вертолёт апачи";
			Regex regexUnknown = new Regex(patternGenderUnknown);
			if (regexUnknown.IsMatch(info))
			{
				result = regexUnknown.Replace(info, targetGenderUnknown);
			}
			return result;

		}
	}

}

