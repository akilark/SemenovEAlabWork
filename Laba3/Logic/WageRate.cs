using System;


namespace Laba3.Logic
{
	public class WageRate : WageBase
	{
		private int minMoneyPerDay = 200;
		private int _workHours;
		private int _priceOfWork;
		private int _daysOfWork;


		public WageRate():base() { }


		public WageRate(int allowToWorkHoursInDay) : base(allowToWorkHoursInDay) { }



		public WageRate(DateTime date, int priceOfWork, int allowToWorkHoursInDay, int workHours) : base(date, allowToWorkHoursInDay)
		{
			PriceOfWork = priceOfWork;
			WorkHours = workHours;
		}



		public override string NameOFTypeWageCounter => "Работник получает фиксированную ставку";


		public override int PriceOfWork
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
			amountMoney = _priceOfWork * _daysOfWork;
		}

	}
}

