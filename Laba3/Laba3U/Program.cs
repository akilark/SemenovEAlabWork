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
					PersonInformationAdd(workers[i], allowWorkHoursInDay);
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
		/// Метод производящий получение корректных данных о персоне с клавиатуры 
		/// </summary>
		/// <param name="outputMessage">Запрос пользователю</param>
		/// <param name="validationAction">действие, которое необходимо выполнить
		/// после запроса пользователю</param>
		private static void ValidateInputInfo(
			string outputMessage, 
			Action validationAction)
		{
			while (true)
			{
				try
				{
					Console.WriteLine(outputMessage);
					validationAction.Invoke();
					return;
				}
				catch (Exception e)
				{
					Console.WriteLine("Допущена ошибка");
					Console.WriteLine(e.Message);
				}
			}
		}

		/// <summary>
		/// Метод добавления всей информации о работнике с клавиатуры 
		/// (Кроме имени и фамилии)
		/// </summary>
		/// <param name="workerTmp">Работник</param>
		/// <param name="allowWorkHoursInDay">Допустимое число часов 
		/// работы в день</param>
		private static void PersonInformationAdd(
			Worker workerTmp, 
			int allowWorkHoursInDay)
		{
			while (true)
			{
				try
				{
					Console.WriteLine("Выберите тип зарплаты для работника " +
						$"{workerTmp.FirstName} {workerTmp.SecondName}" +
						"\n1- Оклад \n" +
						"2- Тарифная ставка \n" +
						"3- Часовая плата");

					WageType wageType;
					switch (Int32.Parse(Console.ReadLine()))
					{
						case 1:
							{
								wageType = WageType.Salary;
								break;
							}
						case 2:
							{
								wageType = WageType.WageRate;
								break;
							}
						case 3:
							{
								wageType = WageType.HorlyPayment;
								break;
							}
						default:
							{
								throw new Exception("Такого типа зарплаты нет");
							}

					}
					workerTmp.WageType(wageType);
					break;
				}
				catch (Exception e)
				{
					Console.WriteLine("Допущена ошибка");
					Console.WriteLine(e.Message);
				}
			}
			
			var validationActions = new List<Tuple<string, Action>>()
			{
				
				new Tuple<string, Action>
				(
					"За какой месяц необходимо посмотреть " +
						"заработок работника ? В формате ХХ",
					() =>
					{
						(int,int) yearMonth = YearMonth();
						workerTmp.dateTime = new DateTime(
							yearMonth.Item1, yearMonth.Item2, 1);
					}
				),
				new Tuple<string, Action>
				(
					MoneyRequest(workerTmp.TypeOfWage),
					() =>
					{
						workerTmp.Wage.PriceOfWork = Int32.Parse(Console.ReadLine());
					}
				),
				new Tuple<string, Action>
				(
					TimeRequest(workerTmp.TypeOfWage),
					() =>
					{
						int hours = workerTmp.TypeOfWage == WageType.HorlyPayment
							? Int32.Parse(Console.ReadLine())
							: Int32.Parse(Console.ReadLine()) * allowWorkHoursInDay;
						workerTmp.Wage.WorkHours = hours;

					}
				)
			};

			foreach(var action in validationActions)
			{
				ValidateInputInfo(action.Item1, action.Item2);
			}
		}

		/// <summary>
		/// Метод запроса даты у пользователя
		/// </summary>
		/// <returns>Год, месяц</returns>
		private static (int,int) YearMonth()
		{
			int month = Int32.Parse(Console.ReadLine());
			if(month<1 || month >12)
			{
				throw new Exception("необходимо ввести номер месяца (от 1 до 12)");
			}
			Console.WriteLine($"За какой год необходимо посмотреть " +
				$"заработок работника ? В формате ХХXX");
			int year = Int32.Parse(Console.ReadLine());
			if (year < 1900 || year > DateTime.Now.Year)
			{
				throw new Exception("недопустимая дата");
			}
			return (year, month);
		}

		/// <summary>
		/// Метод возвращающий строку с соответсвующим запросом количества 
		/// денег за единицу времени для конкретного типа зарплаты
		/// </summary>
		/// <param name="wageType">Тип зарплаты</param>
		/// <returns>Строка с запросом ЗП за единицу времени</returns>
		private static string MoneyRequest(WageType wageType)
		{
			var moneyRequest = new Dictionary<WageType, string>
			{
				{WageType.HorlyPayment, "Введите сколько денег зарабатывает работник за час"},
				{WageType.Salary,"Введите сколько денег зарабатывает работник за месяц" },
				{WageType.WageRate, "Введите сколько денег зарабатывает работник за день"}
			};
			return moneyRequest[wageType];
		}

		/// <summary>
		/// Метод возвращающий строку с соответсвующим запросом временного 
		/// отрезка для конкретного типа зарплаты
		/// </summary>
		/// <param name="wageType">Тип зарплаты</param>
		/// <returns>Строка с запросом временного отрезка</returns>
		private static string TimeRequest(WageType wageType)
		{
			var timeRequest = new Dictionary<WageType, string>
			{
				{WageType.HorlyPayment, "Введите количество отработанных часов"},
				{WageType.Salary,"Введите количество отработанных дней" },
				{WageType.WageRate, "Введите количество отработанных дней"}
			};
			return timeRequest[wageType];
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
	}
}
