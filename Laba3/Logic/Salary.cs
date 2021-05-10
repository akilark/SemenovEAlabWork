using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3.Logic
{
	public class Salary : WageBase
	{
		private int _minSalary = 13000;
		private int _workHours;
		private int _priceOfWork;
		private int _daysOfWork;


		public Salary(): base() { }


		public Salary(int allowToWorkHoursInDay) : base(allowToWorkHoursInDay) { }


		public Salary(DateTime date, int priceOfWork, int allowToWorkHoursInDay, int workHours): base(date, allowToWorkHoursInDay) 
		{
			PriceOfWork = priceOfWork;
			WorkHours = workHours;
		}


		public override string NameOFTypeWageCounter => "Работник получает оклад";


		public override int PriceOfWork
		{
			get
			{
				return _priceOfWork;
			}
			set
			{
				if (value > _minSalary)
				{
					_priceOfWork = value;
				}
				else
				{
					throw new Exception($"В месяц оклад работника должен составлять не менее {_minSalary} рублей");
				}
			}
		}


		public int DayOfWork
		{
			get
			{
				return _daysOfWork;
			}
			private set
			{
				if (value <= WorkDaysInMonth)
				{
					_daysOfWork = value;
				}
				else
				{
					throw new Exception($"Количество отработанных дней в месяце " +
						$"{Date.Month}.{Date.Year} не может быть больше {WorkDaysInMonth}");
				}
			}
		}


		public override int WorkHours
		{
			get
			{
				return _workHours;
			}
			set
			{
				CheckInputInformationForWorkHours();
				_workHours = value;
				DayOfWork = _workHours / AllowToWorkHoursInDay;
			}
		}


		public override void CalculateAmountMoney()
		{
			CheckInformationAboutWorkDaysInMounth();
			amountMoney = _priceOfWork * _daysOfWork / WorkDaysInMonth;
		}

	}
}
