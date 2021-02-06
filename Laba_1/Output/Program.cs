using System;
using Laba_1.Logic;
using System.Text.RegularExpressions;

namespace Laba_1.Output
{
	class Program
	{
		static void Main(string[] args)
		{
			string exit;
			Person PersonForAdd = new Person();
			PersonList ListOfPerson1 = new PersonList(); 
            PersonList ListOfPerson2 = new PersonList(); 
			Person seelectedperson;
			RandomPersonList ListRND = new RandomPersonList();
			int index;
			int ListSize = 3;
			string FirstName;
			string SecondName;
			int Age=-1;
			GenderType Gender;
			bool NameFlag = false;
			bool SecondNameFlag = false;
			bool AgeFlag = false;
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
				string pattern = @"[^a-zа-я-]";
				Regex reg = new Regex(pattern, RegexOptions.IgnoreCase);
				while (NameFlag==false)
				{
					Console.WriteLine("Введите имя:");
					FirstName = Console.ReadLine();
					Match mat = reg.Match(FirstName);
					if (mat.Success)
					{
						Console.WriteLine("Имя может содержать только буквы");
						
					}
					else
					{
						NameFlag = true;
						for (int i = 0; i < FirstName.Length; i++)
						{
							if (FirstName.Length > 1)
								FirstName = FirstName.Substring(0, 1).ToUpper() + FirstName.Substring(1, FirstName.Length - 1).ToLower();
							else FirstName = FirstName.ToUpper();
						}
					PersonForAdd.AddName(FirstName);
					}
				}

				while (SecondNameFlag == false)
				{
					Console.WriteLine("Введите фамилию ");
					SecondName = Console.ReadLine();
					Match mat = reg.Match(SecondName);
					if (mat.Success)
					{
						Console.WriteLine("Фамилия может содержать только буквы");

					}
					else
					{
						SecondNameFlag = true;
						for (int i = 0; i < SecondName.Length; i++)
						{
							if (SecondName.Length > 1)
								SecondName = SecondName.Substring(0, 1).ToUpper() + SecondName.Substring(1, SecondName.Length - 1).ToLower();
							else SecondName = SecondName.ToUpper();
						}
						PersonForAdd.AddSecondName(SecondName);
					}
				}

				while (AgeFlag == false)
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
						if (Age <= 0 )
						{
							Console.WriteLine("Возраст должен быть неотрицательным");
							
						}
						else
						{
							AgeFlag = true;
							PersonForAdd.AddAge(Age);
						}
					}
				}

				Console.WriteLine("Введите пол (М/Ж)");
				string gen = Console.ReadLine();
				if (gen == "М" || gen == "м")
				{
					Gender = GenderType.Male;
				}
				else if (gen == "Ж" || gen == "ж")
				{
					Gender = GenderType.Female;
				}
				else
				{
					Gender = GenderType.Unknown;
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
				seelectedperson = ListOfPerson1.FindByIndex(index);
				ListOfPerson2.AddElement(seelectedperson);
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

	}

			


		


	
}

