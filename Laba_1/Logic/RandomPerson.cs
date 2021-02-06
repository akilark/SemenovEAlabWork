using System;
using System.Collections.Generic;
using System.Text;

namespace Laba_1.Logic
{
	class RandomPerson
	{
		
		public Person GetPerson()
		{
			Person returnPerson = new Person();
			returnPerson.first_name = "";
			returnPerson.second_name = "";
			returnPerson.age = null;
			Random rand = new Random();
			string[] vowels = { "а", "у", "о", "ы", "и", "э", "ю", "е", "ё", "я" }; //гласные
			string[] consonants = { "б", "в", "г", "д", "ж", "з", "й", "к", "л", "м", "н", "п", "р", "с", "т", "ф", "х", "ц", "ч", "ш", "щ" }; //согласные
			Array gendervalues = Enum.GetValues(typeof(GenderType));

			int lenght = rand.Next(1, 3);
			returnPerson.age = rand.Next(12, 101);
			returnPerson.gender = (GenderType)gendervalues.GetValue(rand.Next(gendervalues.Length));

			returnPerson.first_name += FirstLetter();
			returnPerson.second_name += FirstLetter();
			

			for (int i = 0; i < lenght;i++)
			{
				returnPerson.first_name += consonants[rand.Next(consonants.Length)];
				returnPerson.first_name += vowels[rand.Next(vowels.Length)];
				returnPerson.second_name += consonants[rand.Next(consonants.Length)];
				returnPerson.second_name += vowels[rand.Next(vowels.Length)];
			}

			switch(returnPerson.gender)
			{
				case GenderType.male:
					{
						string[] LastNameEnd = { "ов", "ев", "ин" };
						returnPerson.second_name += LastNameEnd[rand.Next(LastNameEnd.Length)];
						break;
					}
				case GenderType.female:
					{
						string[] LastNameEnd = { "ова", "ева", "ина" };
						returnPerson.second_name += LastNameEnd[rand.Next(LastNameEnd.Length)];
						break;
					}
				case GenderType.unknown:
					{
						string[] LastNameEnd = { "о" };
						returnPerson.second_name += LastNameEnd[rand.Next(LastNameEnd.Length)];
						break;
					}
			}
			
			return returnPerson;

		}

		public string FirstLetter()
		{
			Random rand = new Random();
			string[] vowels = { "а", "у", "о", "ы", "и", "э", "ю", "е", "ё", "я" }; //гласные
			string[] consonants = { "б", "в", "г", "д", "ж", "з", "й", "к", "л", "м", "н", "п", "р", "с", "т", "ф", "х", "ц", "ч", "ш", "щ" }; //согласные
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
