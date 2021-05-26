using System;


namespace Laba3.Logic
{
	/// <summary>
	/// Класс- наследник от <see cref="WageBase">, определяет методы, поля и свойства 
	/// для типа зарплаты - тарифная ставка
	/// </summary>
	public class WageRate : WageBase
	{
		/// <summary>
		/// Поле класса определяющее минимальная ставка в день
		/// </summary>
		private int minMoneyPerDay = 200;

		/// <summary>
		/// Поле класса хранящее количество отработанных часов 
		/// за определенный месяц
		/// </summary>
		private int _workHours;

		/// <summary>
		/// Поле класса хранящее значение стоимости часа работ
		/// </summary>
		private int _priceOfWork;

		/// <summary>
		/// Поле класса содержащее количество отработанных дней в месяце
		/// </summary>
		private int _daysOfWork;

		/// <summary>
		/// Конструктор класса с 1 параметром
		/// </summary>
		/// <param name="allowToWorkHoursInDay">Допустимое время работы за 
		/// один день</param>
		public WageRate(int allowToWorkHoursInDay) : base(allowToWorkHoursInDay) { }

		/// <summary>
		/// Конструкор класса с 4 параметрами
		/// </summary>
		/// <param name="date">Дата для расчета ЗП за конкретный месяц</param>
		/// <param name="priceOfWork">Стоимость часа работ</param>
		/// <param name="allowToWorkHoursInDay">Допустимое время работы за 
		/// один день</param>
		/// <param name="workHours">Количество часов отработанных за выбранный месяц</param>
		public WageRate(
			DateTime date, 
			int priceOfWork, 
			int allowToWorkHoursInDay, 
			int workHours) : base(date, allowToWorkHoursInDay)
		{
			PriceOfWork = priceOfWork;
			WorkHours = workHours;
		}

		
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override string NameOfWageType => "Работник получает ставку";

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
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

		/// <summary>
		/// Свойство принимающее с проверкой и возвращающее 
		/// количество отработанных дней
		/// </summary>
		public int DayOfWork
		{
			get
			{
				return _daysOfWork;
			}
			private set
			{
				//TODO: Не связан контекст(v)
				if (value <= WorkDaysInMonth)
				{
					_daysOfWork = value;
					_workHours = value * AllowToWorkHoursInDay;
				}
				else
				{
					throw new Exception($"Количество отработанных дней в месяце " +
						$"{Date.Month}.{Date.Year} не может быть больше {WorkDaysInMonth}");
				}
			}
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
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

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override int CalculateAmountMoney()
		{
			CheckInformationAboutWorkDaysInMounth();
			return _priceOfWork * _daysOfWork;
		}
	}
}

