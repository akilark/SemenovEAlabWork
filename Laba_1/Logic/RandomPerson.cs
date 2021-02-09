using System;
using System.Collections.Generic;
using System.Text;

namespace Laba_1.Logic
{
	class RandomPerson
	{

		
		/// <summary>
		/// Функция создающая случайную комбинацию полей класса Person
		/// </summary>
		/// <returns>Персону с уникальной комбинацией полей класса </returns>
		public static Person Create()
		{
			string NameRadom;
			string SecondNameRandom;
			int AgeRandom;
			GenderType GenderRandom = GenderType.Unknown;
			Person returnPerson = new Person();
			NameRadom = "";
			SecondNameRandom = "";
			Random rand = new Random();
			string[] vowels = { "а", "у", "о", "ы", "и", "э", "ю", "е", "ё", "я" }; //гласные
			string[] consonants = { "б", "в", "г", "д", "ж", "з", "й", "к", "л", "м",
				"н", "п", "р", "с", "т", "ф", "х", "ц", "ч", "ш", "щ" }; //согласные
			Array gendervalues = Enum.GetValues(typeof(GenderType));

			int lenght = rand.Next(1, 3);
			AgeRandom = rand.Next(12, 101);
			GenderRandom = (GenderType)gendervalues.GetValue(rand.Next(gendervalues.Length));

			NameRadom += FirstLetter();
			SecondNameRandom += FirstLetter();
			

			for (int i = 0; i < lenght;i++)
			{
				NameRadom += consonants[rand.Next(consonants.Length)];
				NameRadom += vowels[rand.Next(vowels.Length)];
				SecondNameRandom += consonants[rand.Next(consonants.Length)];
				SecondNameRandom += vowels[rand.Next(vowels.Length)];
			}

			switch(GenderRandom)
			{
				case GenderType.Male:
					{
						string[] LastNameEnd = { "ов", "ев", "ин" };
						SecondNameRandom += LastNameEnd[rand.Next(LastNameEnd.Length)];
						break;
					}
				case GenderType.Female:
					{
						string[] LastNameEnd = { "ова", "ева", "ина" };
						SecondNameRandom += LastNameEnd[rand.Next(LastNameEnd.Length)];
						break;
					}
				case GenderType.Unknown:
					{
						string[] LastNameEnd = { "о" };
						SecondNameRandom += LastNameEnd[rand.Next(LastNameEnd.Length)];
						break;
					}
			}
			returnPerson.AddInfo(NameRadom, SecondNameRandom, AgeRandom, GenderRandom);
			return returnPerson;
			
		}

		/// <summary>
		/// Функций для генерации первой заглавной буквы имени
		/// </summary>
		/// <returns>Строку с первой гласной или парой согласная-гласная </returns>
		public static string FirstLetter()
		{
			Random rand = new Random();
			string[] vowels = { "а", "у", "о", "ы", "и", "э", "ю", "е", "ё", "я" }; //гласные
			string[] consonants = { "б", "в", "г", "д", "ж", "з", "й", "к", "л", "м",
				"н", "п", "р", "с", "т", "ф", "х", "ц", "ч", "ш", "щ" }; //согласные
			int IndexFirstLetter = rand.Next(0, 100);
			string FirstLetter = "";
			if (IndexFirstLetter > 50)
			{
				FirstLetter += consonants[rand.Next(consonants.Length)].ToUpper();
				FirstLetter += vowels[rand.Next(vowels.Length)];
			}
			if (IndexFirstLetter <= 50)
			{
				FirstLetter += vowels[rand.Next(vowels.Length)].ToUpper();
			}
			
			return FirstLetter;
		}

	}
}
