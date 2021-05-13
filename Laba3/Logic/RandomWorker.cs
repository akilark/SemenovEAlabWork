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
			Worker workerTmp = new Worker(allowWorkHoursInDay);
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
			Worker workerTmp = WorkerWithoutWageInformation(allowWorkHoursInDay);
			DateTime LastMonth;

			if (DateTime.Now.Month - 1 != 0)
			{
				LastMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, 1);
			}
			else 
			{
				LastMonth = new DateTime(DateTime.Now.Year-1, 12, 1);
			}
			switch (_rand.Next(1,4))
			{
				case 1:
					{
						workerTmp.WageType(1);
						workerTmp.DesiredDate(LastMonth);
						workerTmp.MoneyEarnedInMonth(_rand.Next(24000, 32000), _rand.Next(0,150));
						break;
					}
				case 2:
					{
						workerTmp.WageType(2);
						workerTmp.DesiredDate(LastMonth);
						workerTmp.MoneyEarnedInMonth(_rand.Next(600, 1500), _rand.Next(0, 150));
						break;
					}
				default:
					{
						workerTmp.WageType(3);
						workerTmp.DesiredDate(LastMonth);
						workerTmp.MoneyEarnedInMonth(_rand.Next(50, 300), _rand.Next(0, 150));
						break;
					}
			}
			return workerTmp;
		}
	}
}
