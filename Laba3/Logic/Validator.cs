using System;

namespace Laba3.Logic
{
	public static class Validator
	{
		public static void DateValidate(DateTime dateTime)
		{
			if (dateTime.Month >= DateTime.Now.Month)
			{
				if (dateTime.Year >= DateTime.Now.Year)
				{
					throw new Exception("Доступна информация о зарплате только за предыдущие месяцы");
				}
			}
		}

		public static void CheckInformationAboutWorkDaysInMounth(IWage wage)
		{
			if(wage.WorkDaysInMonth == 0)
			{
				throw new Exception("Перед расчетом заработной платы введите месяц расчета");
			}
		}

		public static int AllowToWorkDaysInMonth(DateTime dateTime)
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
