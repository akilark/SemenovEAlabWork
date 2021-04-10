using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Laba2.Logic
{
	//TODO:  XML комментарий
	public class Adult : Person
	{
		private string _localPasportSeries;
		private string _localPasportNumber;
		private FamilyStatus _localFamilyStatus = FamilyStatus.NotMarried;
		private Adult _localPartner;
		private string _localJob;


		//TODO:  XML комментарий
		public override int MinAge => 18;


		//TODO:  XML комментарий
		public override int MaxAge => 114;


		//TODO:  XML комментарий
		public string PasportSeries
		{
			get
			{
				return _localPasportSeries;
			}
			set
			{
				//TODO: Дубль
				int passportSeriesLenght = 4;
				CheckPassportDataPattern(value);
				CheckPassportDataLength(value, passportSeriesLenght);
				_localPasportSeries = value;
			}
		}


		//TODO: XML комментарий
		public string PasportNumber
		{
			get
			{
				return _localPasportNumber;
			}
			set
			{
				//TODO: Дубль
				int passportNumberLenght = 6;
				CheckPassportDataPattern(value);
				CheckPassportDataLength(value, passportNumberLenght);
				_localPasportNumber = value;
			}
		}


		//TODO: XML комментарий
		public FamilyStatus FamilyStatus
		{
			//TODO: автосвойство
			get
			{
				return _localFamilyStatus;
			}
			private set
			{
				_localFamilyStatus = value;
			}
		}


		//TODO: XML комментарий
		public Adult Partner
		{
			//TODO: автосвойство
			get
			{
				return _localPartner;
			}
			private set
			{
				_localPartner = value;
			}

		}

		//TODO: XML комментарий
		public string Job
		{
			//TODO: автосвойство
			get
			{
				return _localJob;
			}
			set
			{
				_localJob = value;
			}
		}


		//TODO: XML комментарий
		public Adult() : this("Неизвестно", "Неизвестно", 19, GenderType.Unknown,
			"0000", "000000", null) { }



		//TODO: XML комментарий
		public Adult(string name, string secondName,
			int age, GenderType gender, string pasportSeries, string pasportNumber,
			string job) : base(name, secondName, age, gender)
		{
			PasportSeries = pasportSeries;
			PasportNumber = pasportNumber;
			Job = job;
		}


		//TODO: XML комментарий
		public void AddPartner(Adult partner)
		{
			if (partner != null)
			{
				if (_localPartner == null)
				{
					_localPartner = partner;
					_localFamilyStatus = FamilyStatus.Married;
					if (partner.Partner != (this))
					{
						partner.AddPartner(this);
						partner.FamilyStatus = FamilyStatus.Married;
					}
				}
				else
				{
					DelitePartner();
					AddPartner(partner);
				}
			}
		}

		//TODO: XML комментарий
		public override string Info()
		{
			return $"Имя: {Name};" +
					$" Фамилия: {SecondName}; " +
					$" Возраст: {Age};" +
					$" Пол: {Gender};" + "\n" +
					$" Данные паспорта: {_localPasportSeries}" +
					$" {_localPasportNumber};" + CheckMarried() + CheckJob();
		}


		//TODO: опечатка
		//TODO: XML комментарий
		private void DelitePartner()
		{
			if (_localPartner != null)
			{
				_localPartner.Partner = null;
				_localPartner.FamilyStatus = FamilyStatus.NotMarried;

				_localPartner = null;
				_localFamilyStatus = FamilyStatus.NotMarried;
			}
		}


		//TODO: XML комментарий
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


		//TODO: XML комментарий
		private string CheckJob()
		{
			if (_localJob != null)
			{
				return $" Работает: {Job};";
			}
			else
			{
				return $" Безработный;";
			}
		}


		//TODO:  XML комментарий
		private static void CheckPassportDataLength(string data, int maxLength)
		{
			if (data.Length != maxLength )
			{
				string mistakeInfoTmp = "Недопустимый размер данных паспорта !";
				throw new FormatException(mistakeInfoTmp);
			}
		}


		//TODO:  XML комментарий
		private static void CheckPassportDataPattern(string data)
		{
			string pattern = @"\D";
			Regex reg = new Regex(pattern, RegexOptions.IgnoreCase);
			//TODO: RSDn
			Match mat = reg.Match(data);

			if (mat.Success)
			{
				string mistakeInfoTmp = "Серия и номер паспорта могут " +
					"содержать только цифры!";
				throw new FormatException(mistakeInfoTmp);
			}
		}
	}
}
