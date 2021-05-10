using System;


namespace Laba3.Logic
{
	public abstract class WageBase
	{
		protected int minTime = 1;
		protected int amountMoney;
		private DateTime _dateTime;
		private int _allowToWorkDaysInMonth;
		private int _allowToWorkHoursInDay;


		public WageBase() { }


		public WageBase(int allowToWorkHoursInDay)
		{
			AllowToWorkHoursInDay = allowToWorkHoursInDay;
		}


		public WageBase(DateTime date, int allowToWorkHoursInDay)
		{
			Date = date;
			AllowToWorkHoursInDay = allowToWorkHoursInDay;
		}

		//
		public int AmountMoney
		{
			get
			{
				CalculateAmountMoney();
				return amountMoney;
			}
		}

		public abstract string NameOFTypeWageCounter { get; }
		
		public abstract int PriceOfWork { get; set; }


		public DateTime Date
		{
			get
			{
				return _dateTime;
			}
			set
			{
				DateValidate(value);
				_allowToWorkDaysInMonth = AllowToWorkDaysInMonth(value);
				_dateTime = value;
			}
		}


		public int WorkDaysInMonth => _allowToWorkDaysInMonth;

		public abstract int WorkHours { get; set; }

		public int AllowToWorkHoursInDay
		{
			get
			{
				return _allowToWorkHoursInDay;
			}
			set
			{
				if (value >= minTime && value <= 24)
				{
					_allowToWorkHoursInDay = value;
				}
			}
		}


		public abstract void CalculateAmountMoney();



		protected void CheckInputInformationForWorkHours()
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


		protected void CheckInformationAboutWorkDaysInMounth()
		{
			if (WorkDaysInMonth == 0)
			{
				throw new Exception("Перед расчетом заработной платы введите месяц расчета");
			}
		}


		protected static void DateValidate(DateTime dateTime)
		{
			if (dateTime.Month >= DateTime.Now.Month)
			{
				if (dateTime.Year >= DateTime.Now.Year)
				{
					throw new Exception("Доступна информация о зарплате только за предыдущие месяцы");
				}
			}
		}


		protected static int AllowToWorkDaysInMonth(DateTime dateTime)
		{
			int Month = dateTime.Month;
			int Count = 0;
			while (true)
			{
				if (dateTime.DayOfWeek != DayOfWeek.Saturday && dateTime.DayOfWeek != DayOfWeek.Sunday)
				{
					Count += 1;
				}
				dateTime = dateTime.AddDays(1.0);
				if (dateTime.Month != Month)
				{
					break;
				}
			}
			return Count;
		}
	}

}
