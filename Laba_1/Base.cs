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
				Person person = new Person();
				person.addPerson();
				person.GetInfo();

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

