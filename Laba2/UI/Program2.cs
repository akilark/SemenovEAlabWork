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

			Adult adult3 = new Adult("Человек", "Средняковский", 23, GenderType.Unknown, "1234", "123456", null, null);

			adult1.AddPartner(adult2);

			adult1.AddPartner(adult3);
			
			adult2.DelitePartner();

			adult3.DelitePartner();

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
