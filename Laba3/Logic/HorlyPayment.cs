using System;

namespace Laba3.Logic
{
	public class HorlyPayment : IWage
	{
		private int minTime = 1;
		private int minMoneyPerHour = 10;
		private int _amountMoney;
		private int _workHours;
		private int _priceOfWork;
		private DateTime _dateTime;
		private int _allowToWorkDaysInMonth;
		private int _allowToWorkHours;

		public HorlyPayment() { }

		public HorlyPayment(int allowToWorkHoursInDay)
		{
			AllowToWorkHoursInDay = allowToWorkHoursInDay;
		}

		public HorlyPayment(DateTime date, int priceOfWork, int allowToWorkHoursInDay, int workHours)
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

		
		
		public string NameOFTypeWageCounter => "Почасовая оплата";

		public int PriceOfWork
		{
			get
			{
				return _priceOfWork;
			}
			set
			{
				if (value > minMoneyPerHour)
				{
					_priceOfWork = value;
				}
				else
				{
					throw new Exception($"Цена за час должна быть больше {minMoneyPerHour}");
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
				_dateTime = value;
			}
		}


		public int WorkDaysInMonth => _allowToWorkDaysInMonth;


		public int WorkHours
		{
			get
			{
				return _workHours;
			}
			set
			{
				CheckInputInformationForWorkHours();
				if (value >= minTime && value <= WorkDaysInMonth * AllowToWorkHoursInDay)
				{
					_workHours = value;
				}
				else
				{
					throw new Exception($"Время работы в месяц {Date.Month}.{Date.Year} " +
						$"должно больше {minTime} часа и меньше " +
						$"{WorkDaysInMonth * AllowToWorkHoursInDay}");
				}
				
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
			_amountMoney = _priceOfWork * _workHours;

		}

		private void CheckInputInformationForWorkHours()
		{
			if (_allowToWorkDaysInMonth == 0)
			{
				throw new Exception($"Сначала необходимо задать дату");
			}
			if(AllowToWorkHoursInDay == 0)
			{
				throw new Exception($"Сначала необходимо задать допустимое " +
					$"количество часов работы в день");
			}
		}
	}

}
