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
		private FamilyStatus _localFamilyStatus;
		private Person _localPartner;
		private string _localJob;
		private int _localMinAge = 19;

		public string PasportSeries
		{
			get
			{
				return _localPasportSeries;
			}
			set
			{

			}
		}

		public string PasportNumber
		{
			get
			{
				return _localPasportNumber;
			}
			set
			{

			}
		}

		public FamilyStatus FamilyStatus
		{
			get
			{
				return _localFamilyStatus;
			}
			set
			{

			}
		}

		public Person Partner
		{
			get
			{
				return _localPartner;
			}
			set
			{

			}
		}

		public string Job
		{
			get
			{
				return _localJob;
			}
			set
			{

			}
		}

		public Adult() 
		{ 
			MinAge = _localMinAge;
		}

		public Adult(string name, string secondName,
			int age, GenderType gender) : base(name, secondName, age, gender)
		{
			MinAge = _localMinAge;

		}
	}
}
