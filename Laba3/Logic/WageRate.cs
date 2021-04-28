using System;


namespace Laba3.Logic
{
	class WageRate : IWage
	{
		private int minDay = 1;
		private int minMoneyPerDay = 200;
		private int minTime = 1;
		private int minSalary = 13000;
		private int _amountMoney;
		private int _workHours;
		private int _priceOfWork;
		private DateTime _dateTime;
		private int _allowToWorkDaysInMonth;
		private int _allowToWorkHours;
		private int _daysOfWork;


		public WageRate() { }


		public WageRate(int allowToWorkHoursInDay)
		{
			AllowToWorkHoursInDay = allowToWorkHoursInDay;
		}


		public WageRate(DateTime date, int priceOfWork, int allowToWorkHoursInDay, int workHours)
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


		public string NameOFTypeWageCounter => "Работник получает фиксированную ставку";


		public int PriceOfWork
		{
			get
			{
				return _priceOfWork;
			}
			set
			{
				if (value > minMoneyPerDay)
				{
					_priceOfWork = value;
				}
				else
				{
					throw new Exception($"Цена за день должна быть больше {minMoneyPerDay}");
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
			_amountMoney = _priceOfWork * _daysOfWork;
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

