using System;


namespace Laba2.Logic
{
	/// <summary>
	/// Класс позволяющий создавать уникальных персон и уникальные списки персон
	/// </summary>
	public class RandomPerson
	{
		/// <summary>
		/// Объект класса Random
		/// </summary>
		private static Random _rand = new Random();


		/// <summary>
		/// Метод создания случайной взрослой персоны
		/// </summary>
		/// <returns>Взрослую персону</returns>
		public static Adult CreateAdult()
		{
			var adultTmp = new Adult();
			CreateAtributes(adultTmp);
			Partner(adultTmp);
			return adultTmp;
		}


		/// <summary>
		/// Метод создания случайного ребенка
		/// </summary>
		/// <returns>Ребенка</returns>
		public static Child CreateChild()
		{
			var childTmp = new Child();
			CreateAtributes(childTmp);
			AtributesForChild(childTmp);
			return childTmp;
		}

		/// <summary>
		/// Метод добавления случайного партнера
		/// </summary>
		/// <param name="adultTmp">Взрослый, которому добавляют партнера</param>
		public static void Partner(Adult adultTmp)
		{

			switch (_rand.Next(1, 3))
			{
				case 1:
					{
						var partner = new Adult();
						CreateAtributes(partner);
						adultTmp.AddPartner(partner);
						break;
					}
				case 2:
					{
						adultTmp.AddPartner(null);
						break;
					}
			}
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
				switch (_rand.Next(1, 3))
				{
					case 1:
						{
							personArray.AddElement(CreateAdult());
							break;
						}
					case 2:
						{
							personArray.AddElement(CreateChild());
							break;
						}
				}
			}
			return personArray;
		}


		/// <summary>
		/// Функция создающая случайную комбинацию полей класса Child или Adult
		/// </summary>
		/// <param name="personAdd">Персона в которую добавляем случайную 
		/// комбинацию полей </param>
		private static void CreateAtributes(PersonBase personAdd)
		{
			Array gendervalues = Enum.GetValues(typeof(GenderType));
			personAdd.Age = _rand.Next(personAdd.MinAge, personAdd.MaxAge);
			personAdd.Gender =
				(GenderType)gendervalues.GetValue(_rand.Next(gendervalues.Length));
			personAdd.Name = RandomName();
			string secondNameRandom = RandomName();
			secondNameRandom += EndOfSecondName(personAdd.Gender);
			personAdd.SecondName = secondNameRandom;

			if (personAdd is Adult)
			{
				AtributesForAdult((Adult)personAdd);
			}

			if (personAdd is Child)
			{
				AtributesForChild((Child)personAdd);
			}
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
		/// Метод добавления взрослой персоне атрибутов,
		/// таких как серия/номер паспорта, работа
		/// </summary>
		/// <param name="adultTmp">Взрослая персона которой необходимо 
		/// добавить случайные значения атрибутов</param>
		private static void AtributesForAdult(Adult adultTmp)
		{
			adultTmp.PasportSeries = _rand.Next(1000, 9999).ToString();
			adultTmp.PasportNumber = _rand.Next(100000, 999999).ToString();

			string[] jobs =
			{
				"Российский алюминий",
				"УГМК",
				"ГК «ТАИФ»",
				"Металлоинвест",
				"Группа ГАЗ",
				"Русснефть",
				"МегаФон",
				"Эльдорадо",
				"Евросеть",
				"Объединенная металлургическая компания",
			};

			adultTmp.Job = jobs[_rand.Next(jobs.Length)];
		}


		/// <summary>
		/// Метод добавления ребенку случайное место учебы
		/// </summary>
		/// <param name="childTmp">Ребенок которому необходимо добавить 
		/// случайное место учебы</param>
		private static void AtributesForChild(Child childTmp)
		{
			if (childTmp.Age > 6)
			{
				childTmp.StudyPlace = StudyPlaceType.School;
			}
			else
			{
				childTmp.StudyPlace = StudyPlaceType.Kindergarten;
			}

			childTmp.StudyPlaceName = "№" + _rand.Next(1, 100).ToString();

			Parents(childTmp);
		}


		/// <summary>
		/// Метод добавления ребенку случайные сведения о родителях
		/// </summary>
		/// <param name="childTmp">Ребенок которому необходимо добавить 
		/// случайные сведения о родителях</param>
		private static void Parents(Child childTmp)
		{
			switch (_rand.Next(1, 5))
			{
				case 1:
					{
						childTmp.Mother = CreateParentValidGender(GenderType.Female);
						childTmp.Father = CreateParentValidGender(GenderType.Male);
						childTmp.Mother.AddPartner(childTmp.Father);
						break;
					}
				case 2:
					{
						childTmp.Mother = CreateParentValidGender(GenderType.Female);
						break;
					}
				case 3:
					{
						childTmp.Father = CreateParentValidGender(GenderType.Male);
						break;
					}
				default:
					{

						break;
					}
			}
		}


		/// <summary>
		/// Метод проверки пола родителей
		/// </summary>
		/// <param name="gender">Пол, который является правильным</param>
		private static Adult CreateParentValidGender(GenderType gender)
		{
			Adult adultTmp = CreateAdult();
			while (adultTmp.Gender != gender && adultTmp.Gender != GenderType.Unknown)
			{
				CreateAtributes(adultTmp);
			}
			return adultTmp;
		}
	}
}
