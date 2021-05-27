using System;


namespace Laba3.Logic
{
	/// <summary>
	/// Статический класс для генерации рабочих
	/// </summary>
	public static class RandomWorker
	{
		/// <summary>
		/// Поле класса необходимое для случайной генерации имен
		/// </summary>
		private static Random _rand = new Random();

		/// <summary>
		/// Поле класса содержашее массив имен
		/// </summary>
		private static string[] firstName =
		{
			"Архип",
			"Добрыня",
			"Светогор",
			"Галина",
			"Изольда",
			"Казимир",
			"Евдокия",
			"Елисей",
			"Ефросинья",
			"Митрофан",
			"Марфа",
			"Терентий"
		};

		/// <summary>
		/// Поле класса содержащее массив фамилий
		/// </summary>
		private static string[] secondName =
		{
			"Ющенко",
			"Тимошенко",
			"Мудко",
			"Шнайдер",
			"Шуткевич",
			"Дубяго",
			"Сухих",
			"Белаго",
			"Соловей",
			"Хосе",
			"Пынзарь",
			"Йобманн"
		};

		/// <summary>
		/// Метод выбирающий случайное имя из соответсвующего поля класса
		/// </summary>
		/// <returns>Имя работника</returns>
		private static string RandomFirstName()
		{
			return firstName[_rand.Next(secondName.Length)];
		}

		/// <summary>
		/// Метод выбирающий случайную фамилию из соответсвующего поля класса
		/// </summary>
		/// <returns>Фамилию работника</returns>
		private static string RandomSecondName()
		{
			return secondName[_rand.Next(secondName.Length)];
		}

		/// <summary>
		/// Создание работника без информации о ЗП
		/// </summary>
		/// <param name="allowWorkHoursInDay">Сколько часов в день разрешается 
		/// работать</param>
		/// <returns>Работник без информации о работе</returns>
		public static Worker WorkerWithoutWageInformation(int allowWorkHoursInDay)
		{
			var workerTmp = new Worker(allowWorkHoursInDay);
			workerTmp.FirstName = RandomFirstName();
			workerTmp.SecondName = RandomSecondName();
			return workerTmp;
		}

		/// <summary>
		/// Создание работника с информацией о ЗП
		/// </summary>
		/// <param name="allowWorkHoursInDay">Сколько часов в день разрешается 
		/// работать</param>
		/// <returns>Работник с информацией о ЗП</returns>
		public static Worker WorkerFullInformation(int allowWorkHoursInDay)
		{
			var workerTmp = WorkerWithoutWageInformation(allowWorkHoursInDay);
			var LastMonth = DateTime.Now.Month - 1 == 0 
				? new DateTime(DateTime.Now.Year - 1, 12, 1)
				: new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, 1);
			
			Array wageTypeArray = Enum.GetValues(typeof(WageType));
			
			switch ((WageType)wageTypeArray.GetValue(_rand.Next(wageTypeArray.Length-1)))
			{
				case WageType.Salary:
					{
						workerTmp.WageType(WageType.Salary);
						workerTmp.DesiredDate(LastMonth);
						workerTmp.MoneyEarnedInMonth(_rand.Next(24000, 32000),
							_rand.Next(1,150));
						break;
					}
				case WageType.WageRate:
					{
						workerTmp.WageType(WageType.WageRate);
						workerTmp.DesiredDate(LastMonth);
						workerTmp.MoneyEarnedInMonth(_rand.Next(600, 1500), 
							_rand.Next(1, 150));
						break;
					}
				case WageType.HorlyPayment:
					{
						workerTmp.WageType(WageType.HorlyPayment);
						workerTmp.DesiredDate(LastMonth);
						workerTmp.MoneyEarnedInMonth(_rand.Next(50, 300), 
							_rand.Next(1, 150));
						break;
					}
			}
			return workerTmp;
		}
	}
}
