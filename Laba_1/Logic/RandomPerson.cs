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
			Person returnPerson = new Person();


			Array gendervalues = Enum.GetValues(typeof(GenderType));
			
			int ageRandom = rand.Next(minAge, maxAge);

			GenderType genderRandom = 
				(GenderType)gendervalues.GetValue(rand.Next(gendervalues.Length));

			string firstNameRadom = RandomName();

			string secondNameRandom = RandomName();

			secondNameRandom += EndOfSecondName(genderRandom);

			firstNameRadom = Person.CorrectName(firstNameRadom);

			secondNameRandom = Person.CorrectName(secondNameRandom);

			returnPerson.AddInfo(firstNameRadom, 
				secondNameRandom, ageRandom, genderRandom);

			return returnPerson;
		}

		/// <summary>
		/// Функция создающая случайное имя или фамилию
		/// </summary>
		/// <returns>Имя или фамилию(без характерного окончания) </returns>
		private static string RandomName()
		{
			int lengthMin = 1;
			int lengthMax = 4;
			Random rand = new Random();
			int length = rand.Next(lengthMin, lengthMax);
			string[] vowels = { "а", "у", "о", "ы", "и", "э", "ю", "е", "ё", "я" };
			string[] consonants = { "б", "в", "г", "д", "ж", "з", "й", "к", "л", "м",
				"н", "п", "р", "с", "т", "ф", "х", "ц", "ч", "ш", "щ" };
			string nameTmp = "";
			for (int i = 0; i < length; i++)
			{
				nameTmp += consonants[rand.Next(consonants.Length)];
				nameTmp += vowels[rand.Next(vowels.Length)];
			}
			return nameTmp;
		}

		/// <summary>
		/// Функция выдающая правильное оканчание фамилии 
		/// в зависимости от пола персоны
		/// </summary>
		/// <param name="gender">Гендер персоны</param>
		/// <returns>Характерное окончание фамилии</returns>
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
			PersonList personArray = new PersonList();

			for (int i = 0; i < quantity; i++)
			{
				personArray.AddElement(CreatePerson());
			}
			return personArray;
		}
	}
}
