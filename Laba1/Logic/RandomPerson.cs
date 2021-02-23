using System;


namespace Laba1.Logic
{
	class RandomPerson
	{
		private static Random _rand = new Random();


		/// <summary>
		/// Функция создающая случайную комбинацию полей класса Person
		/// </summary>
		/// <returns>Персону с уникальной комбинацией полей класса </returns>
		public static Person CreatePerson()
		{
			int minAge = 1;
			int maxAge = 114;
			
			Person returnPerson = new Person();


			Array gendervalues = Enum.GetValues(typeof(GenderType));

			int ageRandom = _rand.Next(minAge, maxAge);

			GenderType genderRandom =
				(GenderType)gendervalues.GetValue(_rand.Next(gendervalues.Length));

			string firstNameRadom = RandomName();

			string secondNameRandom = RandomName();

			secondNameRandom += EndOfSecondName(genderRandom);

			firstNameRadom = InputPersonInfo.CorrectName(firstNameRadom);

			secondNameRandom = InputPersonInfo.CorrectName(secondNameRandom);

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
			
			int length = _rand.Next(lengthMin, lengthMax);
			string[] vowels = { "а", "у", "о", "ы", "и", "э", "ю", "е", "ё", "я" };
			string[] consonants = { "б", "в", "г", "д", "ж", "з", "й", "к", "л", "м",
				"н", "п", "р", "с", "т", "ф", "х", "ц", "ч", "ш", "щ" };
			string nameTmp = "";
			for (int i = 0; i < length; i++)
			{
				nameTmp += consonants[_rand.Next(consonants.Length)];
				nameTmp += vowels[_rand.Next(vowels.Length)];
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
			
			string[] lastNameEnd = new string[3];
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
						lastNameEnd[0] = "о";
						break;
					}
			}
			return lastNameEnd[_rand.Next(lastNameEnd.Length)];
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
