using System;


namespace Laba3.Logic
{
	/// <summary>
	/// Абстрактный класс определяющий основные методы, поля и свойства,
	/// необходимые для расчета заработной платы
	/// </summary>
	public abstract class WageBase
	{
		/// <summary>
		/// Поле класса определяющее минимально допустимое время работы в часах
		/// </summary>
		protected int minTime = 1;

		/// <summary>
		/// Поле класса хранящее значение ЗП за определенный месяц
		/// </summary>
		protected int amountMoney;

		/// <summary>
		/// Поле класса хранящее значение рассматриваемой даты
		/// </summary>
		private DateTime _dateTime;

		/// <summary>
		/// Поле класса хранящее количество рабочих дней в месяце
		/// </summary>
		private int _allowToWorkDaysInMonth;

		/// <summary>
		/// Поле класса хранящее количество рабочих часов в дне
		/// </summary>
		private int _allowToWorkHoursInDay;


		/// <summary>
		/// Конструктор класса без параметров
		/// </summary>
		public WageBase() { }

		/// <summary>
		/// Конструктор класса с 1 параметром
		/// </summary>
		/// <param name="allowToWorkHoursInDay">Допустимое время работы за 
		/// один день</param>
		public WageBase(int allowToWorkHoursInDay)
		{
			AllowToWorkHoursInDay = allowToWorkHoursInDay;
		}

		/// <summary>
		/// Конструкор класса с 2 параметрами
		/// </summary>
		/// <param name="date">Дата для расчета ЗП за конкретный месяц</param>
		/// <param name="allowToWorkHoursInDay">Допустимое время работы за 
		/// один день</param>
		public WageBase(DateTime date, int allowToWorkHoursInDay)
		{
			Date = date;
			AllowToWorkHoursInDay = allowToWorkHoursInDay;
		}


		/// <summary>
		/// Свойство возвращающее значение ЗП за конкретный месяц
		/// </summary>
		public int AmountMoney
		{
			get
			{
				CalculateAmountMoney();
				return amountMoney;
			}
		}

		public abstract string NameOfWageType { get; }

		public abstract int PriceOfWork { get; set; }

		/// <summary>
		/// Свойство возвращающее дату и производящее определение корректности
		/// введенного значения даты для расчета ЗП за конкретный месяц
		/// </summary>
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

		/// <summary>
		/// Свойство возвращающее допустимое количество дней в месяце для работы
		/// </summary>
		public int WorkDaysInMonth => _allowToWorkDaysInMonth;

		public abstract int WorkHours { get; set; }


		/// <summary>
		/// Свойство принимающее с проверкой и возвращающее 
		/// допустимое количество рабочих часов в дне
		/// </summary>
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


		/// <summary>
		/// Метод проверки наличия даты и допустимогго количества часов работы в день
		/// </summary>
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


		/// <summary>
		/// Метод проверки наличия информации о количестве рабочих дней в месяцк
		/// </summary>
		protected void CheckInformationAboutWorkDaysInMounth()
		{
			if (WorkDaysInMonth == 0)
			{
				throw new Exception("Перед расчетом заработной платы введите месяц расчета");
			}
		}


		/// <summary>
		/// Метод сравнение введенной даты с текущей. Выдает исключение, 
		/// если введенная дата больше текущей
		/// </summary>
		/// <param name="dateTime">Рассматриваемая дата</param>
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


		/// <summary>
		/// Метод расчета допустимого количества рабочих дней в месяце
		/// </summary>
		/// <param name="dateTime">Рассматриваемая дата</param>
		/// <returns>количество рабочех дней в месяце</returns>
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
