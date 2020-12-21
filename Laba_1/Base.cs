using System;



namespace laba1
{
	class Base
	{
		static void Main(string[] args)
		{
			string exit;
			Person newPerson = new Person();
			PersonList perslist = new PersonList();
			PersonList ListOfPerson1;
            PersonList ListOfPerson2;
			Person seelectedperson;
			int index;
			while (true)
			{
				Console.WriteLine("Cоздание массивов, для продолжение нажмите любую кнопку");
				
				
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
				Console.WriteLine("Добавление человека в первый массив:");
				ListOfPerson1 = perslist.addElement(ListOfPerson1, newPerson.addPerson());
				Console.WriteLine();
				Console.WriteLine("Расширенный массив:");
				perslist.Showmassive(ListOfPerson1);
				Console.WriteLine();
				Console.ReadKey();

				//d
				Console.WriteLine("Перенос человеа из первого массива во второй:");
				
				seelectedperson = perslist.selectPerson(ListOfPerson1,1);
				ListOfPerson2 = perslist.addElement(ListOfPerson2, seelectedperson);
				Console.WriteLine("Первый массив:");
				perslist.Showmassive(ListOfPerson1);
				Console.WriteLine();
				Console.WriteLine("Второй массив:");
				perslist.Showmassive(ListOfPerson2);
				Console.WriteLine();
				Console.ReadKey();

				//e
				
				index = 1;
				ListOfPerson1 = perslist.deleteElement(ListOfPerson1, index);
				Console.WriteLine($"Удаление элемента с индексом {index}:");
				Console.WriteLine("Первый массив:");
				perslist.Showmassive(ListOfPerson1);
				Console.WriteLine();
				Console.WriteLine("Второй массив:");
				perslist.Showmassive(ListOfPerson2);
				Console.WriteLine();
				Console.ReadKey();





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

