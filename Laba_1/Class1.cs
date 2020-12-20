using System;

namespace laba1
{
	class Base
	{
		static void Main(string[] args)
		{
			for (int i = 0; i< 5; i++)
			{
				Person personRand = new Person();
				personRand.GetRandomPerson();
				personRand.GetInfo();
			}
			
			
		}
	}
	class Person
	{
		public string first_name ;
		public string second_name ;
		public int? age ;
		public genderType gender = genderType.Undefined;
		public Person() { first_name = "Undefined"; second_name = "Undefined"; age = null; gender = 0; }
		public Person(string fn) { first_name = fn; second_name = "Undefined"; age = null; gender = 0; }
		public Person(string fn, string sn) { first_name = fn; second_name = sn; age = null; gender = 0; }
		public Person(string fn, string sn, int ag) { first_name = fn; second_name = sn; age = ag; gender = 0; }
		public Person(string fn, string sn, int ag, genderType gen) { first_name = fn; second_name = sn; age = ag; gender = gen; }

		public void GetRandomPerson()
		{
			first_name = "";
			second_name = "";
			age = null;
			Random rand = new Random();
			string[] vowels = { "а", "у", "о", "ы", "и", "э", "ю", "е", "ё", "я" }; //гласные
			string[] consonants = { "б", "в", "г", "д", "ж", "з", "й", "к", "л", "м", "н", "п", "р", "с", "т", "ф", "х", "ц", "ч", "ш", "щ" }; //согласные
			int lenght = rand.Next(1, 3);

			age = rand.Next(12, 101);

			Array gendervalues= Enum.GetValues(typeof(genderType));
			gender = (genderType)gendervalues.GetValue(rand.Next(gendervalues.Length));

			int firstLetter = rand.Next(0, 1);
			if (firstLetter == 0)
			{
				first_name += consonants[rand.Next(consonants.Length)].ToUpper();
				first_name += vowels[rand.Next(vowels.Length)];
			}
			if (firstLetter == 1)
			{
				first_name += vowels[rand.Next(vowels.Length)].ToUpper();
			}
			firstLetter = rand.Next(0, 1);
			if (firstLetter == 0)
			{
				second_name += consonants[rand.Next(consonants.Length)].ToUpper();
				second_name += vowels[rand.Next(vowels.Length)];
			}
			if (firstLetter == 1)
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

			if (gender == genderType.men)
			{
				string[] LastNameEnd = { "ов", "ев", "ин" };
				second_name += LastNameEnd[rand.Next(LastNameEnd.Length)];
			}

			if (gender == genderType.woman)
			{
				string[] LastNameEnd = { "ова", "ева", "ина" };
				second_name += LastNameEnd[rand.Next(LastNameEnd.Length)];
			}

			if (gender == genderType.Undefined)
			{
				string[] LastNameEnd = { "о" };
				second_name += LastNameEnd[rand.Next(LastNameEnd.Length)];
			}

		}

		public void GetInfo()
		{
			Console.WriteLine($"Имя: {first_name} Фамилия: {second_name} Возраст: {age} Пол: {gender}");
		}
	}
	enum genderType
	{
		Undefined,
		men,
		woman
	}
}
