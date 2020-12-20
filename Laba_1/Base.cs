using System;



namespace laba1
{
	class Base
	{
		static void Main(string[] args)
		{
			string exit;
			while (true)
			{
				Console.WriteLine("Cоздание массивов, для продолжение нажмите любую кнопку");
				Person[] ListOfPerson1 = new Person[3];
				Person[] ListOfPerson2 = new Person[3];
				PersonList perslist = new PersonList();
				ListOfPerson1=perslist.CreateListofPerson();
				ListOfPerson2 = perslist.CreateListofPerson();
				Console.ReadKey();

				//b
				Console.WriteLine("Первый массив:");
				perslist.Showmassive(ListOfPerson1);
				Console.WriteLine();
				Console.WriteLine("Второй массив:");
				perslist.Showmassive(ListOfPerson2);
				Console.WriteLine();
				Console.WriteLine("для продолжение нажмите любую кнопку");
				Console.ReadKey();


				//c
				int elementCount = ListOfPerson1.Length;
				Person newPerson = new Person();
				ListOfPerson1 = perslist.addElement(ListOfPerson1, newPerson.addPerson());
				Console.WriteLine();
				Console.WriteLine("Расширенный массив:");
				perslist.Showmassive(ListOfPerson1);
				Console.WriteLine();

				Console.WriteLine("для выхода из программы нажмите 'q'");
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

