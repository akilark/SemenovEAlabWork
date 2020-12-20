using System;
using System.Collections.Generic;
using System.Text;


namespace laba1
{

	class PersonList
	{
		public void CreateListofPerson()
		{
			int quantity = 3;
			Person personRnd = new Person();
			Person[] ListOfPerson1 = new Person[quantity];
			Person[] ListOfPerson2 = new Person[quantity];
			for(int i=0;i< quantity;i++)
			{
				ListOfPerson1[i] = personRnd.GetRandomPerson();
				ListOfPerson1[i].GetInfo();
			}

		}
		

		
					
		
	}
}
