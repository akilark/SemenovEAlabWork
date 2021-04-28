using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3.Logic
{
	public class Salary : IWage
	{
		private int minTime = 1;
		private int minSalary = 13000;
		private int _amountMoney;
		private int _workHours;
		private int _priceOfWork;
		private DateTime _dateTime;
		private int _allowToWorkDaysInMonth;
		private int _allowToWorkHours;
		private int _daysOfWork;


		public Salary() { }


		public Salary(int allowToWorkHoursInDay) 
		{
			AllowToWorkHoursInDay = allowToWorkHoursInDay;
		}


		public Salary(DateTime date, int priceOfWork, int allowToWorkHoursInDay, int workHours)
		{
			Date = date;
			PriceOfWork = priceOfWork;
			AllowToWorkHoursInDay = allowToWorkHoursInDay;
			WorkHours = workHours;
		}


		public int AmountMoney
		{
			get
			{
				CalculateAmountMoney();
				return _amountMoney;
			}
		}


		public string NameOFTypeWageCounter => "Работник получает оклад";


		public int PriceOfWork
		{
			get
			{
				return _priceOfWork;
			}
			set
			{
				if (value > minSalary)
				{
					_priceOfWork = value;
				}
				else
				{
					throw new Exception($"В месяц оклад работника должен составлять не менее {minSalary} рублей");
				}
			}
		}


		public DateTime Date
		{
			get
			{
				return _dateTime;
			}
			set
			{
				Validator.DateValidate(value);
				_allowToWorkDaysInMonth = Validator.AllowToWorkDaysInMonth(value);
			}
		}

		public int WorkDaysInMonth => _allowToWorkDaysInMonth;


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


		public int WorkHours
		{
			get
			{
				return _workHours;
			}
			set
			{
				CheckInputInformationForWorkHours();
				_workHours = value;
				_daysOfWork = _workHours / AllowToWorkHoursInDay;
			}
		}


		public int AllowToWorkHoursInDay
		{
			get
			{
				return _allowToWorkHours;
			}
			set
			{
				if (value >= minTime)
				{
					_allowToWorkHours = value;
				}
			}
		}


		public void CalculateAmountMoney()
		{
			Validator.CheckInformationAboutWorkDaysInMounth(this);
			_amountMoney = _priceOfWork * _daysOfWork / WorkDaysInMonth;
		}


		private void CheckInputInformationForWorkHours()
		{
			if (_allowToWorkDaysInMonth == 0)
			{
				throw new Exception($"Сначала необходимо задать дату");
			}
			if (AllowToWorkHoursInDay == 0)
			{
				throw new Exception($"Сначала необходимо задать допустимое " +
					$"количество часов работы в день");
			}
		}
	}
}
