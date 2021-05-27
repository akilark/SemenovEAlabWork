using System;

namespace Laba3.Logic
{
	/// <summary>
	/// Класс- наследник от WageBase, определяет методы, поля и свойства 
	/// для типа зарплаты - почасовая оплата
	/// </summary>
	[Serializable]
	public class HorlyPayment : WageBase
	{
		/// <summary>
		/// Поле класса определяющее минимально допустимую ставку за час
		/// </summary>
		private int _minMoneyPerHour = 10;

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
		/// <inheritdoc/>
		/// </summary>
		public override WageType WageType => WageType.HorlyPayment;

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public HorlyPayment()
		{

		}

		/// <summary>
		/// Конструктор класса с 1 параметром
		/// </summary>
		/// <param name="allowToWorkHoursInDay">Допустимое время работы за 
		/// один день</param>
		public HorlyPayment(int allowToWorkHoursInDay) : 
			base(allowToWorkHoursInDay) { }

		/// <summary>
		/// Конструкор класса с 4 параметрами
		/// </summary>
		/// <param name="date">Дата для расчета ЗП за конкретный месяц</param>
		/// <param name="priceOfWork">Стоимость часа работ</param>
		/// <param name="allowToWorkHoursInDay">Допустимое время работы за 
		/// один день</param>
		/// <param name="workHours">Количество часов отработанных за выбранный месяц</param>
		public HorlyPayment(
			DateTime date, 
			int priceOfWork, 
			int allowToWorkHoursInDay, 
			int workHours): base(date,allowToWorkHoursInDay)
		{
			PriceOfWork = priceOfWork;
			WorkHours = workHours;
		}


		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override string NameOfWageType => "Почасовая оплата";


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
				if (value > _minMoneyPerHour)
				{
					_priceOfWork = value;
				}
				else
				{
					throw new Exception($"Цена за час должна быть больше" +
						$" {_minMoneyPerHour}");
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
				if (value >= MinTime && value <= WorkDaysInMonth * AllowToWorkHoursInDay)
				{
					_workHours = value;
				}
				else
				{
					throw new Exception($"Время работы в месяц {Date.Month}.{Date.Year} " +
						$"должно больше {MinTime} часа и меньше " +
						$"{WorkDaysInMonth * AllowToWorkHoursInDay}");
				}
			}
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override int CalculateAmountMoney()
		{
			CheckInformationAboutWorkDaysInMounth();
			return _priceOfWork * _workHours;

		}
	}
}
