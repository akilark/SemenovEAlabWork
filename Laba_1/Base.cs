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
				PersonList perslist = new PersonList();
				perslist.CreateListofPerson();
				

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

