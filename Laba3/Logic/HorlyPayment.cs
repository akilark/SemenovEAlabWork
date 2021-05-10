using System;

namespace Laba3.Logic
{
	public class HorlyPayment : WageBase
	{
		private int minMoneyPerHour = 10;
		private int _workHours;
		private int _priceOfWork;


		public HorlyPayment():base() { }

		public HorlyPayment(int allowToWorkHoursInDay) : base(allowToWorkHoursInDay) { }


		public HorlyPayment(DateTime date, int priceOfWork, int allowToWorkHoursInDay, int workHours): base(date,allowToWorkHoursInDay)
		{
			PriceOfWork = priceOfWork;
			WorkHours = workHours;
		}

	
		
		public override string NameOFTypeWageCounter => "Почасовая оплата";

		public override int PriceOfWork
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



		public override int WorkHours
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


		public override void CalculateAmountMoney()
		{
			CheckInformationAboutWorkDaysInMounth();
			amountMoney = _priceOfWork * _workHours;

		}
	}

}
