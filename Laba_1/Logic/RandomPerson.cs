using System;
using System.Collections.Generic;
using System.Text;

namespace Laba_1.Logic
{
	class RandomPerson
	{
		private string _localNameRadom;
		private string _localSecondNameRandom;
		private int? _localAgeRandom;
		private GenderType _localGenderRandom = GenderType.unknown;

		public Person GetPerson()
		{
			Person returnPerson = new Person();
			_localNameRadom = "";
			_localSecondNameRandom = "";
			_localAgeRandom = null;
			Random rand = new Random();
			string[] vowels = { "а", "у", "о", "ы", "и", "э", "ю", "е", "ё", "я" }; //гласные
			string[] consonants = { "б", "в", "г", "д", "ж", "з", "й", "к", "л", "м", "н", "п", "р", "с", "т", "ф", "х", "ц", "ч", "ш", "щ" }; //согласные
			Array gendervalues = Enum.GetValues(typeof(GenderType));

			int lenght = rand.Next(1, 3);
			_localAgeRandom = rand.Next(12, 101);
			_localGenderRandom = (GenderType)gendervalues.GetValue(rand.Next(gendervalues.Length));

			_localNameRadom += FirstLetter();
			_localSecondNameRandom += FirstLetter();
			

			for (int i = 0; i < lenght;i++)
			{
				_localNameRadom += consonants[rand.Next(consonants.Length)];
				_localNameRadom += vowels[rand.Next(vowels.Length)];
				_localSecondNameRandom += consonants[rand.Next(consonants.Length)];
				_localSecondNameRandom += vowels[rand.Next(vowels.Length)];
			}

			switch(_localGenderRandom)
			{
				case GenderType.male:
					{
						string[] LastNameEnd = { "ов", "ев", "ин" };
						_localSecondNameRandom += LastNameEnd[rand.Next(LastNameEnd.Length)];
						break;
					}
				case GenderType.female:
					{
						string[] LastNameEnd = { "ова", "ева", "ина" };
						_localSecondNameRandom += LastNameEnd[rand.Next(LastNameEnd.Length)];
						break;
					}
				case GenderType.unknown:
					{
						string[] LastNameEnd = { "о" };
						_localSecondNameRandom += LastNameEnd[rand.Next(LastNameEnd.Length)];
						break;
					}
			}
			returnPerson.AddName(_localNameRadom);
			returnPerson.AddSecondName(_localSecondNameRandom);
			returnPerson.AddAge(_localAgeRandom);
			returnPerson.AddGender(_localGenderRandom);
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
