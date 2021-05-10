using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3.Logic
{
	public class Worker
	{
		private string _name;
		private string _secondName;
		public WageBase wage;
		private int _allowWorkHoursInDay;
		public int amountTypesWage = 3;
		public string FirstName => _name;
		public string SecondName => _secondName;


		public Worker(int allowWorkHoursInDay)
		{
			_allowWorkHoursInDay = allowWorkHoursInDay;
			_name = RandomName.RandomFirstName();
			_secondName = RandomName.RandomSecondName();
		}


		public string Info()
		{
			return $"Сведения о работнике: \n{FirstName} {SecondName}," +
				$" {wage.NameOFTypeWageCounter}.\nРаботник заработал {wage.AmountMoney} " +
				$"рублей в {wage.Date.Month}.{wage.Date.Year}";
		}

		public void DesiredDate(DateTime date)
		{
			wage.Date = date;
		}

		public int MoneyEarnedInMonth(int priceOfWork, int workHours)
		{
			wage.PriceOfWork = priceOfWork;
			wage.WorkHours = workHours;
			return wage.AmountMoney;
		}

		public void WageType(int type)
		{
			if (type > 3 || type <= 0)
			{
				throw new Exception("Необходимо ввести число в диапазоне от 1 до 3");
			}
			switch (type)
			{
				case 1:
					{
						wage = new Salary(_allowWorkHoursInDay);
						break;
					}
				case 2:
					{
						wage = new WageRate(_allowWorkHoursInDay);
						break;
					}
				default:
					{
						wage = new HorlyPayment(_allowWorkHoursInDay);
						break;
					}
			}
		}

	}
}
