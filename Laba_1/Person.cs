using System;
using System.Text.RegularExpressions;


namespace laba1
{
	class Person
	{
		public string first_name;
		public string second_name;
		public int? age;
		public genderType gender = (genderType)Enum.GetValues(typeof(genderType)).GetValue(0);


		public Person GetRandomPerson()
		{
			Person returnPerson = new Person();
			first_name = "";
			second_name = "";
			age = null;
			Random rand = new Random();
			string[] vowels = { "а", "у", "о", "ы", "и", "э", "ю", "е", "ё", "я" }; //гласные
			string[] consonants = { "б", "в", "г", "д", "ж", "з", "й", "к", "л", "м", "н", "п", "р", "с", "т", "ф", "х", "ц", "ч", "ш", "щ" }; //согласные
			Array gendervalues = Enum.GetValues(typeof(genderType));

			int lenght = rand.Next(1, 3);
			age = rand.Next(12, 101);
			gender = (genderType)gendervalues.GetValue(rand.Next(gendervalues.Length));

			int firstLetter = rand.Next(0, 100);
			if (firstLetter > 50)
			{
				first_name += consonants[rand.Next(consonants.Length)].ToUpper();
				first_name += vowels[rand.Next(vowels.Length)];
			}
			if (firstLetter <= 50)
			{
				first_name += vowels[rand.Next(vowels.Length)].ToUpper();
			}
			firstLetter = rand.Next(0, 100);
			if (firstLetter > 50)
			{
				second_name += consonants[rand.Next(consonants.Length)].ToUpper();
				second_name += vowels[rand.Next(vowels.Length)];
			}
			if (firstLetter <= 50)
			{
				second_name += vowels[rand.Next(vowels.Length)].ToUpper();
			}

			int i = 0;
			while (i < lenght)
			{
				first_name += consonants[rand.Next(consonants.Length)];
				first_name += vowels[rand.Next(vowels.Length)];
				second_name += consonants[rand.Next(consonants.Length)];
				second_name += vowels[rand.Next(vowels.Length)];
				i++;
			}

			if (gender == (genderType)Enum.GetValues(typeof(genderType)).GetValue(1))
			{
				string[] LastNameEnd = { "ов", "ев", "ин" };
				second_name += LastNameEnd[rand.Next(LastNameEnd.Length)];
			}

			if (gender == (genderType)Enum.GetValues(typeof(genderType)).GetValue(2))
			{
				string[] LastNameEnd = { "ова", "ева", "ина" };
				second_name += LastNameEnd[rand.Next(LastNameEnd.Length)];
			}

			if (gender == (genderType)Enum.GetValues(typeof(genderType)).GetValue(0))
			{
				string[] LastNameEnd = { "о" };
				second_name += LastNameEnd[rand.Next(LastNameEnd.Length)];
			}
			returnPerson.first_name = first_name;
			returnPerson.second_name = second_name;
			returnPerson.gender = gender;
			returnPerson.age = age;
			return returnPerson;

		}

		public void GetInfo()
		{
			Console.WriteLine($"Имя: {first_name}; Фамилия: {second_name}; Возраст: {age}; Пол: {gender}");
		}

		public Person addPerson()
		{
			Person returnPerson = new Person();
			first_name = "Неизвестно";
			second_name = "Неизвестно";
			age = null;
			gender = (genderType)Enum.GetValues(typeof(genderType)).GetValue(0);
			string pattern = @"[^a-zа-я-]";
			Regex reg = new Regex(pattern, RegexOptions.IgnoreCase);

			Console.WriteLine("Введите имя ");
			first_name = Console.ReadLine();
			Match mat = reg.Match(first_name);
			if (mat.Success)
			{
				Console.WriteLine("Имя может содержать только буквы");
				first_name = "Неизвестно";
			}
			else
			{
				for (int i = 0; i < first_name.Length; i++)
				{
					if (first_name.Length > 1)
						first_name = first_name.Substring(0, 1).ToUpper() + first_name.Substring(1, first_name.Length - 1).ToLower();
					else first_name = first_name.ToUpper();
				}

				Console.WriteLine("Введите фамилию ");
				second_name = Console.ReadLine();
				mat = reg.Match(second_name);
				if (mat.Success)
				{
					Console.WriteLine("Фамилия может содержать только буквы");
					second_name = "Неизвестно";
				}
				else
				{

					for (int i = 0; i < second_name.Length; i++)
					{
						if (second_name.Length > 1)
							second_name = second_name.Substring(0, 1).ToUpper() + second_name.Substring(1, second_name.Length - 1).ToLower();
						else second_name = second_name.ToUpper();
					}

					try
					{
						Console.WriteLine("Введите возраст ");
						age = Int32.Parse(Console.ReadLine());
					}
					catch (System.FormatException)
					{
						Console.WriteLine("Необходимо ввести число");
						age = null;
					}
					finally
					{
						if (age <= 0 && age != null)
						{
							Console.WriteLine("Возраст должен быть неотрицательным");
							age = null;
						}
						else
						{
							Console.WriteLine("Введите пол (М/Ж)");
							string gen = Console.ReadLine();
							if (gen == "М" || gen == "м")
							{
								gender = (genderType)Enum.GetValues(typeof(genderType)).GetValue(1);
							}
							else if (gen == "Ж" || gen == "ж")
							{
								gender = (genderType)Enum.GetValues(typeof(genderType)).GetValue(2);
							}
							else
							{
								gender = (genderType)Enum.GetValues(typeof(genderType)).GetValue(0);
							}
						}
					}
				}
			}
			returnPerson.first_name = first_name;
			returnPerson.second_name = second_name;
			returnPerson.gender = gender;
			returnPerson.age = age;
			return returnPerson;
		}
	}
}
