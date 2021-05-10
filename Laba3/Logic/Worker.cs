using System;


namespace Laba3.Logic
{
	/// <summary>
	/// Класс работник
	/// </summary>
	public class Worker
	{
		/// <summary>
		/// Поле класса храниящее имя работника
		/// </summary>
		private string _name;

		/// <summary>
		/// Поле класса хранящее фамилию работника
		/// </summary>
		private string _secondName;

		/// <summary>
		/// Поле класса с типом зарплаты
		/// </summary>
		public WageBase Wage;

		/// <summary>
		/// Поле класса хранящее количество рабочих часов в дне
		/// </summary>
		private int _allowWorkHoursInDay;

		/// <summary>
		/// Поле класса хранящее количество типов начисления зарплат
		/// </summary>
		public int amountTypesWage = 3;


		/// <summary>
		/// Свойство возвращающее имя работника
		/// </summary>
		public string FirstName => _name;
		
		/// <summary>
		/// Свойство возвращающее фамилию работника
		/// </summary>
		public string SecondName => _secondName;


		/// <summary>
		/// Конструктор класса с 1 параметром
		/// </summary>
		/// <param name="allowToWorkHoursInDay">Допустимое время работы за 
		/// один день</param>
		public Worker(int allowWorkHoursInDay)
		{
			_allowWorkHoursInDay = allowWorkHoursInDay;
			_name = RandomName.RandomFirstName();
			_secondName = RandomName.RandomSecondName();
		}


		/// <summary>
		/// Метод возвращяющий строку информации о работнике
		/// </summary>
		/// <returns>Строка информации о работнике</returns>
		public string Info()
		{
			return $"Сведения о работнике: \n{FirstName} {SecondName}," +
				$" {Wage.NameOfWageType}.\nРаботник заработал {Wage.AmountMoney} " +
				$"рублей в {Wage.Date.Month}.{Wage.Date.Year}";
		}

		/// <summary>
		/// Метод предварительного занесения рассматриваемой даты
		/// </summary>
		/// <param name="date">Дата для расчета ЗП за конкретный месяц</param>
		public void DesiredDate(DateTime date)
		{
			Wage.Date = date;
		}

		/// <summary>
		/// Метод принимающий цену работы и количество часов работы и 
		/// возвращающий количество заработанных денег за определенный месяц
		/// </summary>
		/// <param name="priceOfWork">Количество денег за работу 
		/// в единицу времени</param>
		/// <param name="workHours">количество часов работы</param>
		/// <returns></returns>
		public int MoneyEarnedInMonth(int priceOfWork, int workHours)
		{
			Wage.PriceOfWork = priceOfWork;
			Wage.WorkHours = workHours;
			return Wage.AmountMoney;
		}

		/// <summary>
		/// Метод обрабатывающий вводимый тип зарплаты
		/// </summary>
		/// <param name="type">номер типа зарплаты</param>
		public void WageType(int type)
		{
			if (type > 3 || type <= 0)
			{
				throw new Exception("Необходимо ввести число в диапазоне от 1 до 3");
			}
			switch (type)
			{
				case 1:
					{
						Wage = new Salary(_allowWorkHoursInDay);
						break;
					}
				case 2:
					{
						Wage = new WageRate(_allowWorkHoursInDay);
						break;
					}
				default:
					{
						Wage = new HorlyPayment(_allowWorkHoursInDay);
						break;
					}
			}
		}
	}
}
