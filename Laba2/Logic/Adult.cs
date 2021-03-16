using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laba1.Logic;

namespace Laba2.Logic
{
	public class Adult : Person
	{
		private string _localPasportSeries;
		private string _localPasportNumber;
		private FamilyStatus _localFamilyStatus = FamilyStatus.NotMarried;
		private Adult _localPartner;
		private string _localJob;


		public override int MinAge => 19;
		public override int MaxAge => 114;


		//TODO: проверка введенного значения и XML комментарий
		public string PasportSeries
		{
			get
			{
				return _localPasportSeries;
			}
			set
			{
				_localPasportSeries = value;
			}
		}


		//TODO: проверка введенного значения и XML комментарий
		public string PasportNumber
		{
			get
			{
				return _localPasportNumber;
			}
			set
			{
				_localPasportNumber = value;
			}
		}


		//TODO: XML комментарий
		public FamilyStatus FamilyStatus
		{
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
			get
			{
				return _localJob;
			}
			set
			{
				_localJob = value;
			}
		}

		public Adult() : this("Неизвестно", "Неизвестно", 19, GenderType.Unknown,
			"0000", "000000", null,"Неизвестно") { }


		public Adult(string name, string secondName,
			int age, GenderType gender, string pasportSeries, string pasportNumber,
			Adult partner, string job) : base(name, secondName, age, gender)
		{
			PasportSeries = pasportSeries;
			PasportNumber = pasportNumber;
			AddPartner(partner);
			Job = job;
		}


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


		public void DelitePartner()
		{
			if (_localPartner != null)
			{
				_localPartner.Partner = null;
				_localPartner.FamilyStatus = FamilyStatus.NotMarried;

				_localPartner = null;
				_localFamilyStatus = FamilyStatus.NotMarried;
			}
		}
	}
}
