using System;
using System.Collections.Generic;
using Laba3.Logic;


namespace Laba3UI
{
	/// <summary>
	/// Класс инициирующий работы программы
	/// </summary>
	class Program
	{
		/// <summary>
		/// Метод вызываемый при старте программы
		/// </summary>
		static void Main(string[] args)
		{
			while (true)
			{
				int allowWorkHoursInDay = 8;
				int arraySize = 3;
				var workers = WorkersArray.Create(arraySize, allowWorkHoursInDay);
				for (int i = 0; i < workers.Count; i++)
				{
					int timer = 0;
					while (true)
					{
						try
						{
							switch (timer)
							{
								case 0:
									{
										Console.WriteLine($"Выберите тип зарплаты для работника " +
											$"{workers[i].FirstName} {workers[i].SecondName}");
										Console.WriteLine("" +
											"1- Оклад \n" +
											"2- Тарифная ставка \n" +
											"3- Часовая плата");
										workers[i].WageType(Int32.Parse(Console.ReadLine()));
										timer++;
										continue;
									}
								case 1:
									{
										Console.WriteLine($"За какой месяц необходимо посмотреть " +
											$"заработок работника ? В формате ХХ");
										int month = Int32.Parse(Console.ReadLine());
										Console.WriteLine($"За какой год необходимо посмотреть " +
											$"заработок работника ? В формате ХХXX");
										int year = Int32.Parse(Console.ReadLine());
										workers[i].DesiredDate(new DateTime(year, month, 1));
										timer++;
										continue;
									}
								case 2:
									{
										(int, int) workMoneyAndHours =
											workMoneyAnHoursDependingOnWageType(
												workers[i], allowWorkHoursInDay);
										workers[i].MoneyEarnedInMonth(workMoneyAndHours.Item1,
											workMoneyAndHours.Item2);
										timer++;
										break;
									}
							}
							break;
						}
						catch (Exception e)
						{
							Console.WriteLine("Допущена ошибка");
							Console.WriteLine(e.Message);
						}
					}
				}
				ShowInfo(workers);
				Console.WriteLine();
				Console.WriteLine("для выхода из программы нажмите 'q'");
				string exit = Console.ReadLine();
				Console.WriteLine();
				if (exit == "q" || exit == "Q" || exit == "й" || exit == "Й")
				{
					break;
				}
			}
		}

		/// <summary>
		/// Метод с помощью которого выводится информация о 
		/// всех работниках из списка работников
		/// </summary>
		/// <param name="workersArray">Список работников</param>
		public static void ShowInfo(WorkersArray workersArray)
		{

			foreach (string workerInfo in workersArray.WorkerInfo())
			{
				Console.WriteLine(workerInfo);
				Console.WriteLine();
			}
			Console.WriteLine();
		}

		/// <summary>
		/// Метод запрашивающий данные в зависимости от типа 
		/// заработной платы работника
		/// </summary>
		/// <param name="worker">Работник</param>
		/// <param name="allowWorkHoursInDay">Сколько дней в день 
		/// разрешается работать</param>
		/// <returns>сколько денег зарабатывает работник за час день или месяц 
		/// (в зависимости от типа заработной платы) 
		/// и сколько часов он отработал</returns>
		private static (int, int) workMoneyAnHoursDependingOnWageType(
			Worker worker, int allowWorkHoursInDay)
		{
			int WageNumber;
			Console.WriteLine($"У работника {worker.FirstName} {worker.SecondName}" +
				$" тип зарплаты: {worker.Wage.NameOfWageType}");
			switch (worker.Wage)
			{
				case HorlyPayment horlyPayment:
					{
						WageNumber = 2;
						return СommunicateWithUser(WageNumber, allowWorkHoursInDay);
					}
				case WageRate wageRate:
					{
						WageNumber = 1;
						return СommunicateWithUser(WageNumber, allowWorkHoursInDay);
					}
				case Salary salary:
					{
						WageNumber = 0;
						return СommunicateWithUser(WageNumber, allowWorkHoursInDay);
					}
				default:
					{
						throw new Exception($"вариантов заработной " +
							$"платы всего {worker.amountTypesWage}");
					}
			}

		}

		/// <summary>
		/// Метод для опроса пользователя для получения необходимх исходных данных
		/// </summary>
		/// <param name="wageNumber">Номер типа заработной платы в листе</param>
		/// <param name="allowWorkHoursInDay">Сколько часов в день разрешается 
		/// работать</param>
		/// <returns></returns>
		private static (int, int) СommunicateWithUser(int wageNumber,
			int allowWorkHoursInDay)
		{
			List<(string, string)> stringInfo = new List<(string, string)>()
			{
			("Введите сколько денег зарабатывает работник за месяц",
			"Введите количество отработанных дней"),
			("Введите сколько денег зарабатывает работник за день",
			"Введите количество отработанных дней"),
			("Введите сколько денег зарабатывает работник за час",
			"Введите количество отработанных часов")
			};
			Console.WriteLine(stringInfo[wageNumber].Item1);
			int workMoney = Int32.Parse(Console.ReadLine());
			int workHours;
			Console.WriteLine(stringInfo[wageNumber].Item2);
			if (wageNumber == 2)
			{
				workHours = Int32.Parse(Console.ReadLine());
			}
			else
			{
				workHours = Int32.Parse(Console.ReadLine()) * allowWorkHoursInDay;
			}
			return (workMoney, workHours);
		}
	}
}
