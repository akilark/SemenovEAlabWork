using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Laba1.Logic;
using Laba1.UI;
using Laba2.Logic;

namespace Laba2.UI
{
	class Program2
	{
		static void Main(string[] args)
		{
			
			Adult adult1 = new Adult("Человек", "Женщинский", 23, GenderType.Female,"1234","123456",null,null);

			Adult adult2 = new Adult("Человек", "Мужиковский", 23, GenderType.Male, "1234", "123456", adult1, null);

			Adult adult3 = new Adult();

			PersonList perslist= new PersonList();

			perslist.AddElement(adult1);
			perslist.AddElement(adult2);
			perslist.AddElement(adult3);

			Program.ShowInfo("Вывод в консоль эдалтов",perslist);

			Console.ReadKey();

			/*
			while (true)
			{
				string exit;
				int listSize = 7;
				PersonList listOfPerson1 = RandomPerson.CreatePersonList(listSize);
				Console.ReadKey();

				Program.ShowInfo("Первый массив:", listOfPerson1);
				int index = 3;
				Person selectedPerson = listOfPerson1.FindByIndex(index);
				Program.ShowInfo("Первый массив:", listOfPerson1);
				Console.ReadKey();


				Program.GreenConsole("для выхода из программы нажмите 'q'");
				exit = Console.ReadLine();
				Console.WriteLine();
				if (exit == "q" || exit == "Q" || exit == "й" || exit == "Й")
				{
					break;
				}
			}
			*/
		}
	}
}
