using System;

using Laba3.Logic;


namespace Laba3UI
{
	class Program
	{
		static void Main(string[] args)
		{
			int arraySize = 1;
			int wageType;
			
			var workers = WorkersArray.Create(arraySize);
			for (int i = 0; i < workers.Count; i++)
			{

				while (true)
				{
					try
					{
						Console.WriteLine($"Выберите тип зарплаты для работника " +
							$"{workers.Workers[i].FirstName} {workers.Workers[i].SecondName}");
						Console.WriteLine("1- Оклад \n" +
							"2- Тарифная ставка \n" +
							"3- Часовая плата");
						wageType = Int32.Parse(Console.ReadLine());
						workers.Workers[i].WageType(wageType);

						Console.WriteLine($"За какой месяц необходимо посмотреть заработок работника ? В формате ХХ");
						int month = Int32.Parse(Console.ReadLine());
						Console.WriteLine($"За какой год необходимо посмотреть заработок работника ? В формате ХХXX");
						int year = Int32.Parse(Console.ReadLine());
						workers.Workers[i].DesiredDate(new DateTime(year, month, 1));

						Console.WriteLine($"Часовая оплата");
						int workMoney = Int32.Parse(Console.ReadLine());
						Console.WriteLine($"Cколько часов");
						workers.Workers[i].MoneyEarnedInMonth(workMoney, Int32.Parse(Console.ReadLine()));
						break;
					}
					//TODO: Сделать switch на виды работ
					catch (Exception e)
					{
						Console.WriteLine("Допущена ошибка");
						Console.WriteLine(e.Message);
					}
				}
			}

			ShowInfo(workers);
			Console.ReadLine();
		}


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
