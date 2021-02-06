using System;
using System.Collections.Generic;
using System.Text;

namespace Laba_1.Logic
{
	class RandomPersonList
	{
		public PersonList Create(int quantity)
		{
			PersonList PersonArray = new PersonList();
			RandomPerson personRnd = new RandomPerson();
			

			for (int i = 0; i < quantity; i++)
			{
				PersonArray.addElement(personRnd.GetPerson());
			}
			return PersonArray;
		}
	}
}
