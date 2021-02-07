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
				Console.WriteLine("Cоздание массивов, для продолжение нажмите любую кнопку");
				
				
				
				ListOfPerson1 = ListRND.Create(ListSize);
				
				ListOfPerson2 = ListRND.Create(ListSize);

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
				PersonForAdd.AddName(FirstName);

				while (SecondNameMistakeFlag == true)
				{
					Console.WriteLine("Введите фамилию ");
					SecondName = Console.ReadLine();
					SecondNameMistakeFlag=CheckName(SecondName);
				}
				SecondName = CorrectName(SecondName);
				PersonForAdd.AddSecondName(SecondName);

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
							Console.WriteLine($"Возраст должен быть в диапазоне [{MinAge}-{MaxAge}]");	
						}
						else
						{
							AgeMistakeFlag = false;
							PersonForAdd.AddAge(Age);
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
				PersonForAdd.AddGender(Gender);
				
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

		public static void ShowInfo(string[] PersonInfoArray)
		{
			for (int i = 0; i < PersonInfoArray.Length; i++)
				Console.WriteLine(PersonInfoArray[i]);
		}
		
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
						NameTMP = SubTMP.Substring(0, 1).ToUpper() + SubTMP.Substring(1, SubTMP.Length - 1).ToLower();
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
	}

}

