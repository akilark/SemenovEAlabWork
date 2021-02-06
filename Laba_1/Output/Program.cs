using System;
using Laba_1.Logic;


namespace Laba_1.Output
{
	class Program
	{
		static void Main(string[] args)
		{
			string exit;
			Person newPerson = new Person();
			PersonList ListOfPerson1 = new PersonList(); 
            PersonList ListOfPerson2 = new PersonList(); 
			Person seelectedperson;
			RandomPersonList ListRND = new RandomPersonList();
			int index;
			while (true)
			{
				Console.WriteLine("Cоздание массивов, для продолжение нажмите любую кнопку");
				
				
				
				ListOfPerson1 = ListRND.Create(3);
				
				ListOfPerson2 = ListRND.Create(3);

				Console.ReadKey();

				//b
				Console.WriteLine("Первый массив:");
				ListOfPerson1.Showmassive();
				Console.WriteLine();
				Console.WriteLine("Второй массив:");
				ListOfPerson2.Showmassive();
				Console.WriteLine();
				Console.WriteLine("для продолжение нажмите любую кнопку");
				Console.ReadKey();


				//c
				Console.WriteLine("Добавление человека в первый массив:");
				ListOfPerson1.addElement(newPerson.addPerson());
				Console.WriteLine();
				Console.WriteLine("Расширенный массив:");
				ListOfPerson1.Showmassive();
				Console.WriteLine();
				Console.ReadKey();

				//d
				Console.WriteLine("Перенос человеа из первого массива во второй:");
				index = 1;
				seelectedperson = ListOfPerson1.FindByIndex(index);
				ListOfPerson2.addElement(seelectedperson);
				Console.WriteLine("Первый массив:");
				ListOfPerson1.Showmassive();
				Console.WriteLine();
				Console.WriteLine("Второй массив:");
				ListOfPerson2.Showmassive();
				Console.WriteLine();
				Console.ReadKey();

				//e
				
				
				ListOfPerson1.deleteElement(index);
				Console.WriteLine($"Удаление элемента с индексом {index}:");
				Console.WriteLine("Первый массив:");
				ListOfPerson1.Showmassive();
				Console.WriteLine();
				Console.WriteLine("Второй массив:");
				ListOfPerson2.Showmassive();
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

