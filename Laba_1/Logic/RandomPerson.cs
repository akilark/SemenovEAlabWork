using System;


namespace Laba_1.Logic
{
	class RandomPerson
	{

		
		/// <summary>
		/// Функция создающая случайную комбинацию полей класса Person
		/// </summary>
		/// <returns>Персону с уникальной комбинацией полей класса </returns>
		public static Person CreatePerson()
		{
			int minAge = 1;
			int maxAge = 114;
			Random rand = new Random();

			Array gendervalues = Enum.GetValues(typeof(GenderType));
			
			int AgeRandom = rand.Next(minAge, maxAge);

			GenderType genderRandom = (GenderType)gendervalues.GetValue(rand.Next(gendervalues.Length));

			string firstNameRadom = RandomName();

			string secondNameRandom = RandomName();

			secondNameRandom += EndOfSecondName(genderRandom);

			firstNameRadom = Person.CorrectName(firstNameRadom);
			secondNameRandom = Person.CorrectName(secondNameRandom);

			Person returnPerson = new Person();
			returnPerson.AddInfo(firstNameRadom, secondNameRandom, AgeRandom, genderRandom);
			return returnPerson;
			
		}

		private static string RandomName()
		{
			Random rand = new Random();
			int lenght = rand.Next(1, 4);
			string[] vowels = { "а", "у", "о", "ы", "и", "э", "ю", "е", "ё", "я" }; //гласные
			string[] consonants = { "б", "в", "г", "д", "ж", "з", "й", "к", "л", "м",
				"н", "п", "р", "с", "т", "ф", "х", "ц", "ч", "ш", "щ" }; //согласные
			string nameTmp = "";
			for (int i = 0; i < lenght; i++)
			{
				nameTmp += consonants[rand.Next(consonants.Length)];
				nameTmp += vowels[rand.Next(vowels.Length)];
			}
			return nameTmp;
		}
		private static string EndOfSecondName(GenderType gender)
		{
			Random rand = new Random();
			string[] lastNameEnd= new string[3];
			switch (gender)
			{
				case GenderType.Male:
					{
						lastNameEnd[0] = "ов";
						lastNameEnd[1] = "ев";
						lastNameEnd[2] = "ин";
						break;
					}
				case GenderType.Female:
					{
						lastNameEnd[0] = "ова";
						lastNameEnd[1] = "ева";
						lastNameEnd[2] = "ина";
						break;
					}
				case GenderType.Unknown:
					{
						Array.Resize(ref lastNameEnd, 1);
						lastNameEnd[0] =  "о" ;
						break;
					}
			}
			return lastNameEnd[rand.Next(lastNameEnd.Length)];
		}


		/// <summary>
		/// Функция формирующая массив заданной размерности из случайных персон 
		/// </summary>
		/// <param name="quantity">Размер массива персон</param>
		/// <returns>Массив персон </returns>
		public static PersonList CreatePersonList(int quantity)
		{
			//TODO: RSDN
			PersonList PersonArray = new PersonList();

			for (int i = 0; i < quantity; i++)
			{
				PersonArray.AddElement(CreatePerson());
			}
			return PersonArray;
		}

	}
}
