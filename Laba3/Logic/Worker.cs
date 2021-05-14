using System;
using System.Text.RegularExpressions;

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
		/// Поле класса хранящее номер типа начисления зарплат
		/// </summary>
		private int _typeWage;


		/// <summary>
		/// Свойство возвращающее номер типи зарплаты
		/// </summary>
		public int NumberOfTypeWage => _typeWage;

		/// <summary>
		/// Свойство возвращающее и принимающее с проверкой имя работника
		/// </summary>
		public string FirstName
		{
			get
			{
				return _name;
			}
			set 
			{
				CheckName(value);
				_name = CorrectName(value);
			}
		}

		/// <summary>
		/// Свойство возвращающее и принимающее с проверкой фамилию работника
		/// </summary>
		public string SecondName
		{
			get
			{
				return _secondName;
			}
			set
			{
				CheckName(value);
				_secondName = CorrectName(value);
			}
		}


		/// <summary>
		/// Конструктор класса с 1 параметром
		/// </summary>
		/// <param name="allowToWorkHoursInDay">Допустимое время работы за 
		/// один день</param>
		public Worker(int allowWorkHoursInDay)
		{
			_allowWorkHoursInDay = allowWorkHoursInDay;
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
			_typeWage = type;
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


		/// <summary>
		/// Функция приводящая имена и фамилии к правильному виду
		/// </summary>
		/// <param name="name">Либо имя, либо фамилия</param>
		/// <returns>Строка содержащая слово с первой заглавной буквой, 
		/// если слова разделены через тире, 
		/// все слова начинаются с большой буквы </returns>
		public static string CorrectName(string name)
		{
			string nameTmp = "";
			string outputName = "";
			string[] subString =
				name.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

			foreach (string subTmp in subString)
			{
				for (int i = 0; i < subTmp.Length; i++)
				{
					if (subTmp.Length > 1)
					{
						nameTmp = subTmp.Substring(0, 1).ToUpper() +
							subTmp.Substring(1, subTmp.Length - 1).ToLower();
					}
					else
					{
						nameTmp = subTmp.ToUpper();
					}
				}

				if (outputName.Length == 0)
				{
					outputName += nameTmp;
				}
				else
				{
					outputName += "-" + nameTmp;
				}
			}
			return outputName;
		}


		/// <summary>
		/// Функция проверяющая имена и фамилии на наличиие ошибок, 
		/// если ошибка возникает, выдает соответствующее исключение
		/// </summary>
		/// <param name="name">Либо имя, либо фамилия</param>
		/// <returns>false- если ошибок нет. </returns>
		public static void CheckName(string name)
		{
			CheckNamelength(name);
			CheckNamePattern(name);
			CheckQuantityName(name);
		}


		/// <summary>
		/// Функция проверяющая имена и фамилии на наличие запрещенного количества
		/// составных частей
		/// </summary>
		/// <param name="name">Либо имя, либо фамилия</param>
		/// <exception cref="Недопустимо использование более {allowQuantity}
		/// составных частей имени или фамилии!"></exception>
		private static void CheckQuantityName(string name)
		{
			string[] subString = name.Split('-');
			int allowQuantity = 2;

			if (subString.Length > allowQuantity)
			{
				string mistakeInfoTmp = $"Недопустимо использование " +
					$"более {allowQuantity} составных частей имени или фамилии!";
				throw new FormatException(mistakeInfoTmp);
			}
		}


		/// <summary>
		/// Функция проверяющая имена и фамилии на выход за допустымые размеры
		/// </summary>
		/// <param name="name">Либо имя, либо фамилия</param>
		/// <exception cref="Недопустимый размер имени или фамилии!"></exception>
		private static void CheckNamelength(string name)
		{
			int nameMin = 2;
			int nameMax = 30;

			if (name.Length < nameMin || name.Length > nameMax)
			{
				string mistakeInfoTmp = "Недопустимый размер имени или фамилии!";
				throw new FormatException(mistakeInfoTmp);
			}
		}


		/// <summary>
		/// Функция проверяющая имена и фамилии на наличие запрещенных симоволов
		/// </summary>
		/// <param name="name">Либо имя, либо фамилия</param>
		/// <exception cref="Имя и Фамилия могут содержать только буквы!">
		/// </exception>
		private static void CheckNamePattern(string name)
		{
			string pattern = @"[^a-zа-яё-]";
			Regex reg = new Regex(pattern, RegexOptions.IgnoreCase);
			Match mat = reg.Match(name);

			if (mat.Success)
			{
				string mistakeInfoTmp = "Имя и Фамилия могут содержать только буквы!";
				throw new FormatException(mistakeInfoTmp);
			}
		}
	}
}
