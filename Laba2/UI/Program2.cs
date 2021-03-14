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
			var pers1 = new Person("Евгений","Семенов",23,GenderType.Male);
			Adult adult1 = new Adult();

			
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
		}
	}
}
