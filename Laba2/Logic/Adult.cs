using System;
using System.Text.RegularExpressions;


namespace Laba2.Logic
{
	/// <summary>
	/// Класс позволяющий хранить информацию о взрослой персоне, 
	/// выводить эту информацию и проверять ее на наличие ошибок при введении.
	/// </summary>
	public class Adult : PersonBase
	{
		/// <summary>
		/// Серия паспорта
		/// </summary>
		private string _localPasportSeries;


		/// <summary>
		/// Номер паспорта
		/// </summary>
		private string _localPasportNumber;


		/// <summary>
		/// Метод возвращающий минимально возможный возраст персоны 
		/// </summary>
		public override int MinAge => 18;


		/// <summary>
		/// Метод возвращающий максимально возможный возраст персоны 
		/// </summary>
		public override int MaxAge => 114;


		/// <summary>
		/// Метод возвращающий серию паспорта персоны и принимающий 
		/// серию паспорта с проверкой правильности введенных данных
		/// </summary>
		public string PasportSeries
		{
			get
			{
				return _localPasportSeries;
			}
			set
			{
				//TODO: Дубль(V)
				int passportSeriesLenght = 4;
				CheckPassportData(value, passportSeriesLenght);
				_localPasportSeries = value;
			}
		}


		/// <summary>
		/// Метод возвращающий номер паспорта персоны и принимающий 
		/// номер паспорта с проверкой правильности введенных данных
		/// </summary>
		public string PasportNumber
		{
			get
			{
				return _localPasportNumber;
			}
			set
			{
				//TODO: Дубль(v)
				int passportNumberLenght = 6;
				CheckPassportData(value, passportNumberLenght);
				_localPasportNumber = value;
			}
		}


		/// <summary>
		/// Метод возвращающий и принимающий семейный статус персоны  
		/// </summary>
		public FamilyStatus FamilyStatus { get; set; }
		//TODO: автосвойство(v)



		/// <summary>
		/// Метод возвращающий и принимающий партнера персоны  
		/// </summary>
		public Adult Partner { get; set; }
		//TODO: автосвойство(v)


		/// <summary>
		/// Метод возвращающий и принимающий работу персоны  
		/// </summary>
		public string Job { get; set; }
		//TODO: автосвойство(v)



		/// <summary>
		/// Конструктор для создания объекта типа Adult с дефолтными полями
		/// </summary>
		public Adult() : this("Неизвестно", "Неизвестно", 19, GenderType.Unknown,
			"0000", "000000", "Неизвестно") { }



		/// <summary>
		/// Конструктор для создания объекта типа Adult
		/// с полным набором информации
		/// </summary>
		/// <param name="name">Имя персоны</param>
		/// <param name="secondName">Фамилия персоны</param>
		/// <param name="age">Возраст персоны</param>
		/// <param name="gender">Пол персоны</param>
		/// <param name="pasportSeries">Серия паспорта персоны</param>
		/// <param name="pasportNumber">Номер паспорта персоны</param>
		/// <param name="job">Работа персоны</param>
		public Adult(string name, string secondName,
			int age, GenderType gender, string pasportSeries, string pasportNumber,
			string job) : base(name, secondName, age, gender)
		{
			PasportSeries = pasportSeries;
			PasportNumber = pasportNumber;
			Job = job;
			FamilyStatus = FamilyStatus.NotMarried;
		}


		/// <summary>
		/// Метод позволяющий добавить партнера с контролем добавления 
		/// у партнера
		/// </summary>
		/// <param name="partner">объект класса Adult, 
		/// партнер данного Adult</param>
		public void AddPartner(Adult partner)
		{
			if (partner != null)
			{
				if (Partner == null)
				{
					Partner = partner;
					FamilyStatus = FamilyStatus.Married;
					if (partner.Partner != (this))
					{
						partner.AddPartner(this);
						partner.FamilyStatus = FamilyStatus.Married;
					}
				}
				else
				{
					DeletePartner();
					AddPartner(partner);
				}
			}
		}


		/// <summary>
		/// Метод позволяющий получить информацию о Персоне
		/// </summary>
		/// <returns>Строка типа "Имя: ; Фамилия: ; Возраст: ; Пол: ;
		/// Данные паспорта ; Брак ; Работа;"</returns>
		public override string Info()
		{
			return $"Имя: {Name};" +
					$" Фамилия: {SecondName}; " +
					$" Возраст: {Age};" +
					$" Пол: {Gender};" + "\n" +
					$" Данные паспорта: {_localPasportSeries}" +
					$" {_localPasportNumber};" + CheckMarried() + CheckJob();
		}


		/// <summary>
		/// Метод взаимодействия с работой
		/// </summary>
		/// <param name="dayOfWeek">День недели</param>
		/// <returns>Строка что делать с работой</returns>
		public string InteractionWithJob(DayOfWeek dayOfWeek)
		{
			switch (dayOfWeek)
			{
				case DayOfWeek.Sunday:
				case DayOfWeek.Saturday:
					{
						return $"Сегодня выходной, можно отдохнуть";
					}
				default:
					{
						if(Job == "Неизвестно")
						{
							return $"Пора искать работу";
						}
						else
						{
							return $"Пора работать";
						}
					}
			}
		}


		//TODO: опечатка(V)
		/// <summary>
		/// Метод позволяющий удалить партнера с контролем удаления
		/// у партнера
		/// </summary>
		private void DeletePartner()
		{
			if (Partner != null)
			{
				Partner.Partner = null;
				Partner.FamilyStatus = FamilyStatus.NotMarried;

				Partner = null;
				FamilyStatus = FamilyStatus.NotMarried;
			}
		}


		/// <summary>
		/// Метод проверки семейного положения
		/// </summary>
		/// <returns>Строка семейного положения</returns>
		private string CheckMarried()
		{
			switch (FamilyStatus)
			{
				case FamilyStatus.Married:
					{
						return $" В браке с {Partner.Name} {Partner.SecondName};";
					}
				case FamilyStatus.NotMarried:
					{
						return 	$" В браке не состоит;";
					}
				default:
					{
						throw new Exception("Семейное положение должно быть задано");
					}
			}
		}


		/// <summary>
		/// Метод проверки места работы
		/// </summary>
		/// <returns>Строка информации о месте работы</returns>
		private string CheckJob()
		{
			if (Job != null)
			{
				return $" Работает: {Job};";
			}
			else
			{
				return $" Безработный;";
			}
		}


		/// <summary>
		/// Метод проверки паспортных данных
		/// </summary>
		/// <param name="data">Данные</param>
		/// <param name="maxLength">необходимая длина данных</param>
		private static void CheckPassportData(string data, int maxLength)
		{
			CheckPassportDataLength(data, maxLength);
			CheckPassportDataPattern(data);
		}


		/// <summary>
		/// Метод проверки длинны паспортных данных
		/// </summary>
		/// <param name="data">Данные</param>
		/// <param name="maxLength">необходимая длина данных</param>
		private static void CheckPassportDataLength(string data, int maxLength)
		{
			if (data.Length != maxLength )
			{
				string mistakeInfoTmp = "Недопустимый размер данных паспорта !";
				throw new FormatException(mistakeInfoTmp);
			}
		}


		/// <summary>
		/// Метод проверки паспортных данных на отсутствие посторонних символов
		/// </summary>
		/// <param name="data">Данные</param>
		private static void CheckPassportDataPattern(string data)
		{
			string pattern = @"\D";
			Regex reg = new Regex(pattern, RegexOptions.IgnoreCase);
			//TODO: RSDn(V)
			Match match = reg.Match(data);

			if (match.Success)
			{
				string mistakeInfoTmp = "Серия и номер паспорта могут " +
					"содержать только цифры!";
				throw new FormatException(mistakeInfoTmp);
			}
		} 
	}
}
